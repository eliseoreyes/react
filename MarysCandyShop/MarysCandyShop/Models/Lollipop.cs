using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarysCandyShop.Models
{
    public class Lollipop : Product
    {
        public string Shape {  get; set; }

        public Lollipop() 
        {
            Type = Enums.ProductType.Lollipop;
        }
        public Lollipop(int id) : base(id)
        {
            Type = Enums.ProductType.Lollipop;
        }

        public override string GetProductForCsv(int id)
        {
            return $"{id}, {(int) Type}, {Name}, {Price}, {Shape}";
        }
    }
}
