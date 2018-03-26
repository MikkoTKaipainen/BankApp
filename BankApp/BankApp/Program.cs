using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            Console.WriteLine("BankApp v1.0 \n" +
                "The Bank of Texas \n");
            Bank bank = new Bank("The Bank of Texas");

            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer(bank.CreateAccount(), "Johnson", "McDick"));
            customers.Add(new Customer(bank.CreateAccount(), "Jack", "McHammer"));
            customers.Add(new Customer(bank.CreateAccount(), "Dick", "MacMace"));

            var endTime = DateTime.Today;
            var time = new TimeSpan(24 * 30 * 6, 0, 0);
            var startTime = endTime.Date - time;
            Console.WriteLine($"\nTilitapahtumat viimeisen kuuden kuukauden ajalta: {startTime.ToShortDateString()} - {endTime.ToShortDateString()}");

            for (int i = 0; i < 50; i++)
            {
                bank.AddTransactionForCustomer(customers[rnd.Next(0, 3)].AccountNumber, new Transaction(rnd.Next(-5000, 5000), new DateTime(2018, rnd.Next(1, 3), rnd.Next(1, 28))));
            }

            for (int i = 0; i < customers.Count; i++)
            {
                PrintBalance(bank, customers[i]);
                PrintTransactions(bank.PrintTransactionsForCustomerForTimeSpan(customers[i].AccountNumber, startTime, endTime), customers[i]);
            }

            Console.WriteLine("\nPress any key to exit monitoring...");
            Console.ReadKey();

        }
        public static void PrintBalance(Bank bank, Customer customer)
        {
            var balance = bank.GetBalanceForCustomer(customer.AccountNumber);
            Console.WriteLine("\n{0} - balance: {1}{2:0.00}",
                customer.ToString(), balance >= 0 ? "+" : "", balance);
        }

        public static void PrintTransactions(List<Transaction> transactions, Customer customer)
        {
            Console.WriteLine($"\nTilitapahtumat {customer.FirstName} {customer.LastName}: \n");

            for (int i = 0; i < transactions.Count(); i++)
            {
                Console.WriteLine("{0}\t{1}{2:0.00}",
                    transactions[i].Timestamp.ToShortDateString(),
                    transactions[i].Sum >= 0 ? "+" : "",
                    transactions[i].Sum);
            }
        }
    }

}
