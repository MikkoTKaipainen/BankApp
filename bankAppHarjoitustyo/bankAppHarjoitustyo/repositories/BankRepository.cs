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
                        //.Where(b => b.Id == 13)
                        .ToListAsync().Result;
                    return banks;
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException($"{ex.Message}");
                }
            }
        }


    }
        
}
