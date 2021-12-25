using System;
using System.Collections.Generic;
using System.Text;

namespace UdemyNLayerProject.Core.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string InnerBarcode { get; set; }
        //Entity FW tracking yapabilmesi için veriliyor
        public virtual Category Category { get; set; }
        public bool isDeleted { get; set; }
    }
}
