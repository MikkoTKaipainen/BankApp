using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bankAppHarjoitustyo.model
{
    public partial class Transaction
    {
        public long Id { get; set; }
        [Required]
        [Column("IBAN")]
        [StringLength(18)]
        public string Iban { get; set; }
        [Column(TypeName = "date")]
        public DateTime TimeStamp { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal Amount { get; set; }

        [ForeignKey("Iban")]
        [InverseProperty("Transaction")]
        public Account IbanNavigation { get; set; }

        public override string ToString()
        {
            string plusMinus = Amount >= 0 ? "+" : "";
            return $"{plusMinus}{Amount}\t{TimeStamp:dd.MM.yyyy}";
        }
    }
}
