using System;
using System.Collections.Generic;
using System.Text;
using bankAppHarjoitustyo.model;

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
    }
}
