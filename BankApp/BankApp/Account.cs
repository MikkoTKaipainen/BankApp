using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    class Account
    {
        private string _accountNumber;
        private double _balance;
        private List<Transaction> _transactions;

        public Account(string accountNumber, double balance, List<Transaction> transactions)
        {
            _accountNumber = accountNumber;
            _balance = balance;
            _transactions = transactions;
        }
    }
}
