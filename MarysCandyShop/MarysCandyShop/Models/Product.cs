using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarysCandyShop.Models.Enums;

namespace MarysCandyShop.Models
{
    public abstract class Product
    {

        public int Id { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }  
        public ProductType Type { get; set; }

        public Product(){ }
        public Product(int id) 
        { 
            this.Id = id;
        }

        public Product(int id, string name, decimal price) 
        { 
            this.Id=id;
            this.Name = name;
            this.Price = price;
        }

        public abstract string GetProductForCsv(int id);
       /* private string name;

        internal String Name
        { 
            get 
            { 
                return name; 
            }
            set 
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    name = value;
                }
                else 
                {
                    Console.WriteLine("Invalid name. Must be a non-empty string");
                }
            }
        }*/
    }
}
