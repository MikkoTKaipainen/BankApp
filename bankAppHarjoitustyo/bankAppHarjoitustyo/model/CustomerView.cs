using System;
using System.Collections.Generic;
using System.Text;
using bankAppHarjoitustyo.repositories;
using Microsoft.EntityFrameworkCore;

namespace bankAppHarjoitustyo.model
{
    class CustomerView
    {
        public void PrintCustomerData(string FirstName, string LastName)
        {
            CustomerRepository customerRepository = new CustomerRepository();
            Customer customer = customerRepository.GetCustomer(FirstName, LastName);
            var customerdata = customerRepository.GetCustomerAccounts(customer);
            
            foreach (var cD in customerdata)
            {
                Console.WriteLine(cD.ToString());
                foreach (var c in cD.Account)
                {
                    Console.WriteLine($"\t{c.ToString()}");
                }
            }
        }

        public void PrintCustomerTransactions(string FirstName, string LastName)
        {

            CustomerRepository customerRepository = new CustomerRepository();
            Customer customer = customerRepository.GetCustomer(FirstName, LastName);
            var customerdata = customerRepository.GetCustomerTransactions(customer);

            foreach (var cD in customerdata)
            {
                Console.WriteLine(cD.ToString());
                foreach (var cAccount in cD.Account)
                {
                    Console.WriteLine($"\t{cAccount.ToString()}");
                    foreach (var a in cAccount.Transaction)
                    {
                        Console.WriteLine($"\t{a.ToString()}");
                    }
                }
            }
        }
    }
}
