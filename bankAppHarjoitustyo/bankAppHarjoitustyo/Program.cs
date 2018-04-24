using System;
using bankAppHarjoitustyo.repositories;
using bankAppHarjoitustyo.model;
namespace bankAppHarjoitustyo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("BankApp Harjoitustyö");

            //AddTransaction();

            //AddCustomer();

            //BankView();

            //AddAccount();


            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static void AddTransaction()
        {
            AccountRepository accountRepository = new AccountRepository();
            var account = accountRepository.GetAccountByIban("FI1352270820033352");
            Transaction transaction = new Transaction
            {
                Iban = "FI1352270820033352",
                Amount = 100,
                TimeStamp = DateTime.Today
            };
            accountRepository.AddTransaction(transaction);
        }

        static void AddCustomer()
        {
            Customer customer = new Customer("Paul", "McDingelson", 2);
            CustomerRepository customerRepository = new CustomerRepository();
            customerRepository.AddCustomer(customer);
        }

        static void BankView()
        {
            BankView bankView = new BankView();
            bankView.PrintAllBanks();
        }

        static void AddAccount()
        {
            Account account = new Account("FI2345670987213456","Säästötili",1,5,0);
            AccountRepository accountRepository = new AccountRepository();
            accountRepository.AddAccount(account);
        }

    }
}
