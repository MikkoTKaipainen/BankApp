using System;
using System.Collections.Generic;
using System.Text;
using bankAppHarjoitustyo.model;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace bankAppHarjoitustyo.repositories
{
    class CustomerRepository
    {
        public void AddCustomer(Customer customer)
        {
            using (var context = new BankdbContext())
            {
                try
                {
                    //Lisätään tapahtumatauluun rivi
                    context.Add(customer);
                    //Tallennetaan muutokset tietokantaan
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException($"{ex.Message}\n{ex.InnerException.Message}");
                }
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            using (var context = new BankdbContext())
            {
                try
                {
                    //Lisätään tapahtumatauluun rivi
                    context.Update(customer);
                    //Tallennetaan muutokset tietokantaan
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException($"{ex.Message}\n{ex.InnerException.Message}");
                }
            }
        }

        public void RemoveCustomer(Customer customer)
        {
            using (var context = new BankdbContext())
            {
                try
                {
                    //Lisätään tai poistetaan tapahtumataulun rivi
                    context.Remove(customer);
                    //Tallennetaan muutokset tietokantaan
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException($"{ex.Message}\n{ex.InnerException.Message}");
                }
            }
        }

        public List<Customer> GetCustomerAccounts(Customer customer)
        {
            using (var context = new BankdbContext())
            {
                try
                {
                    List<Customer> customers = context.Customer
                        .Include(c => c.Account)
                        .Where(c => c.Id == customer.Id)
                        .ToListAsync().Result;
                    return customers;
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException(ex.Message);
                }
            }
        }

        public Customer GetCustomer(string firstname, string lastname)
        {
            using (var context = new BankdbContext())
                try
                {
                    var customer = context.Customer.FirstOrDefault(a => a.FirstName == firstname && a.LastName == lastname);
                    return customer;
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException($"{ex.Message}\n{ex.InnerException.Message}");
                }
        }

        public List<Customer> GetCustomerTransactions(Customer customer)
        {
            using (var context = new BankdbContext())
            {
                try
                {
                    List<Customer> customers = context.Customer
                        .Include(c => c.Account)
                        .ThenInclude(c => c.Transaction)
                        .Where(c => c.Id == customer.Id)
                        .ToListAsync().Result;
                    return customers;
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException(ex.Message);
                }
            }
        }
    }
}
