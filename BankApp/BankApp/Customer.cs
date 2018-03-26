using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }

        public override string ToString()
        {
            return $"{_firstName} {_lastName} {_accountNumber}";
        }
    }
}
