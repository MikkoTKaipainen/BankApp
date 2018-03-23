using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    class Transaction
    {
        private double _sum;
        private DateTime _timestamp;

        public Transaction(double sum, DateTime timestamp)
        {
            _sum = sum;
            _timestamp = timestamp;
        }

        public double Sum
        {
            get => _sum;
            set => _sum = value;
        }

    }
}
