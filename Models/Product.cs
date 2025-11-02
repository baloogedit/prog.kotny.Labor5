using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Labor_5.Models
{
    public class Product
    {
        [Key] // Marks this as the unique identifier (Primary Key)
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; } // Note: string is nullable by default in .NET Framework

        public DateTime StoreEntryDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int Quantity { get; set; }
    }
}
