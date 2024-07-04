using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarysCandyShop.Models.Enums;

namespace MarysCandyShop.Models
{
    public class ChocolateBar : Product
    {
        public int CocoaPercentage { get; set; }

        public ChocolateBar() 
        {
            Type = ProductType.ChocolateBar;
        }

        public ChocolateBar(int id) : base(id)
        {
            Type = ProductType.ChocolateBar;
        }

        public override string GetProductForCsv(int id)
        {
            return $"{id}, {(int) Type}, {Name}, {Price}, {CocoaPercentage}"; 
        }
    }
}
