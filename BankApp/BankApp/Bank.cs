using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    class Bank
    {
        private List<Account> _accounts;
        private string _name;
        private string _rnd;

        public Bank(List<Account> accounts, string name, string rnd)
        {
            _accounts = accounts;
            _name = name;
            _rnd = rnd;
        }
    }
}
