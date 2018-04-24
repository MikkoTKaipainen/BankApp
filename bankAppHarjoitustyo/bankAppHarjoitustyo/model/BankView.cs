using System;
using System.Collections.Generic;
using System.Text;
using bankAppHarjoitustyo.repositories;
using Microsoft.EntityFrameworkCore;

namespace bankAppHarjoitustyo.model
{
    class BankView
    {
        public void PrintAllBanks()
        {
            BankRepository bankRepository = new BankRepository();
            var bankCustomer = bankRepository.GetTransactionsFromBankCustomersAccounts();

            foreach (var bC in bankCustomer)
            {
                Console.WriteLine(bC.ToString());
                foreach (var c in bC.Customer)
                {
                    Console.WriteLine(c.ToString());
                    foreach (var cAccount in c.Account)
                    {
                        Console.WriteLine($"\t{cAccount.ToString()}");
                        foreach (var trn in cAccount.Transaction)
                        {
                            Console.WriteLine($"\t{trn.ToString()}");
                        }
                    }
                }
            }

        }
    }
}
