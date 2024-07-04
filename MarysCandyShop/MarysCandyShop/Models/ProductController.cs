using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static MarysCandyShop.Models.Enums;

namespace MarysCandyShop.Models
{
    public  class ProductController
    {
        public static List<Product> GetProducts()
        { 
            var products = new List<Product>();

            try
            {
                using (StreamReader reader = new StreamReader(Configuration.DocPath))
                {
                    reader.ReadLine(); // Ignore the first line
                    var line = reader.ReadLine();

                    while (line != null)
                    {
                        string[] parts = line.Split(',');

                        if (int.Parse(parts[1]) == (int)ProductType.ChocolateBar)
                        {
                            var product = new ChocolateBar(int.Parse(parts[0]));
                            product.Name = parts[2];
                            product.Price = decimal.Parse(parts[3]);
                            product.CocoaPercentage = int.Parse(parts[4]);
                            products.Add(product);
                        }
                        else
                        {
                            var product = new Lollipop(int.Parse(parts[0]));
                            product.Name = parts[2];
                            product.Price = decimal.Parse(parts[3]);
                            product.Shape = parts[5];
                            products.Add(product);

                        }


                        line = reader.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return products;
        }

        public static void DeleteProduct(string name) 
        { 
            Console.WriteLine(name); 
        }

        public static void UpdateProduct(string name)
        { 
            Console.WriteLine($"Product {name}");   
        }

        public static void ViewProducts(List<Product> products)
        {
            Console.WriteLine("=============================");
            
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Id}: {product.Name} {product.Price}");
            }

            Console.WriteLine("=============================");
        }

        public static void AddProduct(Product product)
        {
            try {

                var id =  GetProducts().Count;

                Console.WriteLine("Product Name: ");
                var name = Console.ReadLine();

                Console.WriteLine("Product Price: ");
                var price = decimal.Parse(Console.ReadLine());

                using (StreamWriter outputFile = (File.Exists(Configuration.DocPath)) ? File.AppendText(Configuration.DocPath) : File.CreateText(Configuration.DocPath))
                {

                    if (outputFile.BaseStream.Length == 0)
                    {
                        outputFile.WriteLine("Id, Type, Name, Price, CocoaPercentage, Shape");
                    }

                    var csvFile = product.GetProductForCsv(id);
                    
                    outputFile.WriteLine(csvFile);
                    
                    Console.WriteLine("Products saved\n");
                    outputFile.Close();
                }
            } 
            catch (Exception ex)
            {
                Console.WriteLine($"There was an error saving products: {ex.Message}");
            }
        }

        public static void AddProducts(List<Product> products)
        {
            try
            {
              
                using (StreamWriter writer = new StreamWriter(Configuration.DocPath))
                {
                    foreach (var product in products)
                    {
                        writer.WriteLine($"{product.Id}, {product.Name}, {product.Price}", true);
                    }
                    
                    Console.WriteLine("Products saved\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There was an error saving products: {ex.Message}");
            }
        }

        public static void LoadData()
        {
            List<Product> products = new List<Product>();

            try {
                using (StreamReader reader = new StreamReader(Configuration.DocPath))
                { 
                    var line = reader.ReadLine();
                    
                    while (line != null)
                    {
                        string[] parts = line.Split(',');
                        products.Add(new Product(int.Parse(parts[0]), parts[1], decimal.Parse(parts[2])));
                        line = reader.ReadLine();
                    }
                }
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
