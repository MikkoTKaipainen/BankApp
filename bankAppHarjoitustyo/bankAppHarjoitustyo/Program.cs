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

            //AddAccount();

            //RemoveAccount();

            //AddBank();

            //UpdateBank();

            //RemoveBank();

            //BankView();

            //UpdateCustomer();

            //RemoveCustomer();

            PrintCustomerData("Dirk", "McTullamore");

            PrintCustomerTransactions("Dirk", "McTullamore");


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
            Customer customer = new Customer("Paul", "McDingelson", 1);
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
            Account account = new Account("FI2345670987213456", "Säästötili", 1, 3, 0);
            AccountRepository accountRepository = new AccountRepository();
            accountRepository.AddAccount(account);
        }

        static void RemoveAccount()
        {
            Account account = new Account("FI2345670987213456", "Säästötili", 1, 3, 0);
            AccountRepository accountRepository = new AccountRepository();
            accountRepository.RemoveAccount(account);
        }

        static void AddBank()
        {
            Bank bank = new Bank("Linnapankki", "LINNFIHH", 5);
            BankRepository bankRepository = new BankRepository();
            bankRepository.AddBank(bank);
        }

        static void RemoveBank()
        {
            Bank bank = new Bank("Linnapankki", "LINNFIHH", 5);
            BankRepository bankRepository = new BankRepository();
            bankRepository.RemoveBank(bank);
        }

        static void UpdateBank()
        {
            Bank bank = new Bank("Linnapankki", "LINAFIHH", 5);
            BankRepository bankRepository = new BankRepository();
            bankRepository.UpdateBank(bank);
        }

        static void UpdateCustomer()
        {
            Customer customer = new Customer("Paul", "McDingelson", 1);
            CustomerRepository customerRepository = new CustomerRepository();
            customerRepository.UpdateCustomer(customer);
        }

        static void RemoveCustomer()
        {
            Customer customer = new Customer("Paul", "McDingelson", 1);
            CustomerRepository customerRepository = new CustomerRepository();
            customerRepository.RemoveCustomer(customer);
        }

        static void PrintCustomerData(string FirstName, string LastName)
        {
            CustomerView customerView = new CustomerView();
            customerView.PrintCustomerData(FirstName, LastName);
        }

        static void PrintCustomerTransactions(string FirstName, string LastName)
        {
            CustomerView customerView = new CustomerView();
            customerView.PrintCustomerTransactions(FirstName, LastName);
        }


    }
}
