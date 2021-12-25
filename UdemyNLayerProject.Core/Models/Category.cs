using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace UdemyNLayerProject.Core.Models
{
    public class Category
    {
        public Category()
        {
            //Boş bir collection nesnesi oluşması için
            Products = new Collection<Product>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isDeleted { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
