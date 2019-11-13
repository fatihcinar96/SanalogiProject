using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sanalogi.Models
{
    public class InvoiceModel
    {
        [Key]
        public int InvoiceID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [MaxLength(30)]
        [Required]
        public string Email { get; set; }
        [MaxLength(25)]
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceNo { get; set; }
        public List<ProductListModel> Products { get; set; }
        public decimal TotalPrice { get; set; }
    }


    [NotMapped]
    public class InvoiceCreateModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceNo { get; set; }
        public List<ProductListModel> Products { get; set; }
    }

    [NotMapped]
    public class ProductListModel
    {
        public string Name { get; set; }
        public int Piece { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
