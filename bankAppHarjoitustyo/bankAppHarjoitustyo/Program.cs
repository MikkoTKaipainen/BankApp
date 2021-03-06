﻿using System;
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

            //AddCustomer("Mikko", "Kaipainen", 1);

            //AddAccount("FI2345670987213456", "Säästötili", 1, 3, 0);

            //RemoveAccount("FI2345670987213456", "Säästötili", 1, 3, 0);

            //AddBank("Linnapankki", "LINNFIHH");

            //UpdateBank("Linnapankki", "LINAFIHH");

            //RemoveBank(8);

            //BankView();

            //UpdateCustomer("Paul", "McDingelson", 1);

            //RemoveCustomer(12);

            //PrintCustomerData("Dirk", "McTullamore");

            //PrintCustomerTransactions("Dirk", "McTullamore");


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

        static void AddCustomer(string firstName, string lastName, long bankId)
        {
            Customer customer = new Customer(firstName, lastName, bankId);
            CustomerRepository customerRepository = new CustomerRepository();
            customerRepository.AddCustomer(customer);
        }

        static void BankView()
        {
            BankView bankView = new BankView();
            bankView.PrintAllBanks();
        }

        static void AddAccount(string iban, string name, long bankId, long customerId, decimal balance)
        {
            Account account = new Account(iban, name, bankId, customerId, balance);
            AccountRepository accountRepository = new AccountRepository();
            accountRepository.AddAccount(account);
        }

        static void RemoveAccount(string iban, string name, long bankId, long customerId, decimal balance)
        {
            Account account = new Account(iban, name, bankId, customerId, balance);
            AccountRepository accountRepository = new AccountRepository();
            accountRepository.RemoveAccount(account);
        }

        static void AddBank(string name, string bic)
        {
            Bank bank = new Bank(name, bic);
            BankRepository bankRepository = new BankRepository();
            bankRepository.AddBank(bank);
        }

        static void RemoveBank(long id)
        {
            Bank bank = new Bank(id);
            BankRepository bankRepository = new BankRepository();
            bankRepository.RemoveBank(bank);
        }

        static void UpdateBank(string name, string bic)
        {
            Bank bank = new Bank(name, bic);
            BankRepository bankRepository = new BankRepository();
            bankRepository.UpdateBank(bank);
        }

        static void UpdateCustomer(string firstName, string lastName, long bankId)
        {
            Customer customer = new Customer(firstName, lastName, bankId);
            CustomerRepository customerRepository = new CustomerRepository();
            customerRepository.UpdateCustomer(customer);
        }

        static void RemoveCustomer(long id)
        {
            Customer customer = new Customer(id);
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
