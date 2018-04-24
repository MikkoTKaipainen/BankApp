using System;
using System.Collections.Generic;
using System.Text;
using bankAppHarjoitustyo.model;
using System.Linq;
using bankAppHarjoitustyo.repositories;
using Microsoft.EntityFrameworkCore;

namespace bankAppHarjoitustyo.repositories
{
    public class BankRepository
    {
        public List<Bank> GetTransactionsFromBankCustomersAccounts()
        {

            using (var context = new BankdbContext())
            {
                try
                {
                    List<Bank> banks = context.Bank
                        .Include(b => b.Customer)
                        .Include(b => b.Account)
                        .Include(b => b.Account).ThenInclude(a => a.Transaction)
                        .Where(b => b.Id == 2)
                        .ToListAsync().Result;
                    return banks;
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException($"{ex.Message}");
                }
            }
        }

        public void AddBank(Bank bank)
        {
            using (var context = new BankdbContext())
            {
                try
                {
                    //Lisätään tapahtumatauluun rivi
                    context.Add(bank);
                    //Tallennetaan muutokset tietokantaan
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException($"{ex.Message}\n{ex.InnerException.Message}");
                }
            }
        }

        public void RemoveBank(Bank bank)
        {
            using (var context = new BankdbContext())
            {
                try
                {
                    //Lisätään tai poistetaan tapahtumataulun rivi
                    context.Remove(bank);
                    //Tallennetaan muutokset tietokantaan
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException($"{ex.Message}\n{ex.InnerException.Message}");
                }
            }
        }

        public void UpdateBank(Bank bank)
        {
            using (var context = new BankdbContext())
            {
                try
                {
                    //Lisätään tapahtumatauluun rivi
                    context.Update(bank);
                    //Tallennetaan muutokset tietokantaan
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException($"{ex.Message}\n{ex.InnerException.Message}");
                }
            }
        }

        public Bank GetBank(string name)
        {
            using (var context = new BankdbContext())
            {
                try
                {
                    //hakee pankin tiedot
                    var bank = context.Bank.FirstOrDefault(b => b.Name == name);
                    //palauttaa pankin tiedot
                    return bank;
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException(ex.Message);
                }
            }
        }

    }
        
}
