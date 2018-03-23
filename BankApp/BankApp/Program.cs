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
            Console.WriteLine("BankApp v1.0");
            Bank bank = new Bank("The Bank of Texas");


            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer(bank.CreateAccount(), "Johnson", "McDick"));
            customers.Add(new Customer(bank.CreateAccount(), "Jack", "McHammer"));
            customers.Add(new Customer(bank.CreateAccount(), "Dick", "MacMace"));

            bank.AddTransactionForCustomer(customers[0].AccountNumber, new Transaction(1234, new DateTime(2018,03,23)));
            PrintBalance(bank, customers[0]);
            Console.WriteLine("Press any key to exit monitoring...");
            Console.ReadKey();
        }

        public static void PrintBalance(Bank bank, Customer customer)
        {
            var balance = bank.GetBalanceForCustomer(customer.AccountNumber);
            Console.WriteLine("{0} - balance: {1}{2:0.00}",
                customer.ToString(), balance >= 0 ? "+" : "", balance);
        }


    }
}
