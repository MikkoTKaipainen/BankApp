﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace bankAppHarjoitustyo.model
{
    public partial class Account
    {
        public Account()
        {
            Transaction = new HashSet<Transaction>();
        }

        public Account(string iban, string name, long bankId, long customerId, decimal balance)
        {
            Iban = iban;
            Name = name;
            BankId = bankId;
            CustomerId = customerId;
            Balance = balance;
        }

        [Key]
        [Column("IBAN")]
        [StringLength(18)]
        public string Iban { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public long BankId { get; set; }
        public long CustomerId { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal Balance { get; set; }

        [ForeignKey("BankId")]
        [InverseProperty("Account")]
        public Bank Bank { get; set; }
        [ForeignKey("CustomerId")]
        [InverseProperty("Account")]
        public Customer Customer { get; set; }
        [InverseProperty("IbanNavigation")]
        public ICollection<Transaction> Transaction { get; set; }

        public override string ToString()
        {
            string plusMinus = Balance >= 0 ? "+" : "";
            return $"{Iban} - {Name} - {plusMinus}{Balance}";
        }

    }
}
