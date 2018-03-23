using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    class Customer
    {
        private string _accountNumber;
        private string _firstName;
        private string _lastName;

        public Customer(string accountNumber, string firstName, string lastName)
        {
            _accountNumber = accountNumber;
            _firstName = firstName;
            _lastName = lastName;
        }

        public string AccountNumber
        {
            get => _accountNumber;
            set => _accountNumber = value;
        }

        public override string ToString()
        {
            return $"{_firstName} {_lastName} {_accountNumber}";
        }
    }
}
