using System;
using System.Collections.Generic;
using System.Text;
using bankAppHarjoitustyo.model;
using System.Linq;

namespace bankAppHarjoitustyo.repositories
{
    class AccountRepository
    {
        public Account GetAccountByIban(string iban)
        {
            using (var context = new BankdbContext())
                try
                {
                    var account = context.Account.FirstOrDefault(a => a.Iban == iban);
                    return account;
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException($"{ex.Message}\n{ex.InnerException.Message}");
                }
        }

        public void AddTransaction(Transaction transaction)
        {
            using (var context = new BankdbContext())
            {
                try
                {
                    //Lisätään tapahtumatauluun rivi
                    context.Add(transaction);

                    //Etsitään tili, jolle tietoja päivitetään
                    var account = GetAccountByIban(transaction.Iban);
                    //Lasketaan tilille uutta saldoa
                    account.Balance += transaction.Amount;
                    //Päivitetään tili
                    context.Account.Update(account);
                    //Tallennetaan muutokset tietokantaan
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException($"{ex.Message}\n{ex.InnerException.Message}");
                }
            }
        }

        public void AddAccount(Account account)
        {
            using (var context = new BankdbContext())
                try
                {
                    context.Add(account);

                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException($"{ex.Message}\n{ex.InnerException.Message}");
                }
        }

        public void RemoveAccount(Account account)
        {
            using (var context = new BankdbContext())
                try
                {
                    context.Remove(account);

                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException($"{ex.Message}\n{ex.InnerException.Message}");
                }
        }




    }
}
