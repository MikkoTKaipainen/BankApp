﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BankApp
{
    class Bank
    {
        private string _name;
        private List<Account> _accounts;

        public Bank(string name)
        {
            _name = name;
            _accounts = new List<Account>();
        }

        public string CreateAccount()
        {
            Random rnd = new Random();
            string rndAccount = "FI";
            for (int i = 0; i < 16; i++)
            {
                rndAccount += rnd.Next(0, 10);
            }
            _accounts.Add(new Account (rndAccount));
            return rndAccount;
        }

        public bool AddTransactionForCustomer(string accountNumber, Transaction transaction)
        {
            return (from account in _accounts
                    where account.AccountNumber == accountNumber
                    select account).First().AddTransaction(transaction);
        }

        public double GetBalanceForCustomer(string accountNumber)
        {
            return (from account in _accounts
                    where account.AccountNumber == accountNumber
                    select account).FirstOrDefault().Balance;
        }

        public List<Transaction> PrintTransactionsForCustomerForTimeSpan(string accountNumber,
            DateTime startTime, DateTime endTime)
        {
            //return _accounts.FirstOrDefault(a => a.AccountNumber == accountNumber)
            //    .GetTransactionsForTimeSpan(startTime, endTime);

            return (from account in _accounts
                    where account.AccountNumber == accountNumber
                    select account).FirstOrDefault().GetTransactionForTimeSpan(startTime, endTime);
        }
    }
}
