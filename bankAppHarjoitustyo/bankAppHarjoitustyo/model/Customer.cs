using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bankAppHarjoitustyo.model
{
    public partial class Customer
    {
        public Customer()
        {
            Account = new HashSet<Account>();
        }

        public Customer(long id, string firstName, string lastName, long bankId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BankId = bankId;
        }

        public long Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        public long BankId { get; set; }

        [ForeignKey("BankId")]
        [InverseProperty("Customer")]
        public Bank Bank { get; set; }
        [InverseProperty("Customer")]
        public ICollection<Account> Account { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
