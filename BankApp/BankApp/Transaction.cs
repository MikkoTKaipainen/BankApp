using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    class Transaction
    {
        private double _sum;
        private string _timestamp;

        public Transaction(double sum, string timestamp)
        {
            _sum = sum;
            _timestamp = timestamp;
        }

    }
}
