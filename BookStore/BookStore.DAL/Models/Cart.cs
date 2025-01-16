using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Models
{
    public class Cart
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; } = 1;
        public decimal TotalPrice { get; set; }
        public DateTime AddedAt { get; set; } = DateTime.Now;
        public string Status { get; set; } = "Added";

        public virtual User? User { get; set; }
        public virtual Book? Book { get; set; }
    }
}
