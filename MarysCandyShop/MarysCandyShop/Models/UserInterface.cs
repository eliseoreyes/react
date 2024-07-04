using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarysCandyShop.Models.Enums;

namespace MarysCandyShop.Models
{
    public static class UserInterface
    {
        public static void RunMainMenu()
        {
            var isMenuRunning = true;
            
            while (isMenuRunning) 
            {
                PrintHeader();

                var usersChoice = AnsiConsole.Prompt(new SelectionPrompt<MainMenuOptions>()
                    .Title("What would you like to do?")
                    .AddChoices(
                            MainMenuOptions.AddProduct,
                            MainMenuOptions.ViewProducts, 
                            MainMenuOptions.UpdateProduct, 
                            MainMenuOptions.DeleteProduct, 
                            MainMenuOptions.QuitProgram));

                var menuMessage = "Press any key to go back to Menu";

                switch (usersChoice)
                {
                    case MainMenuOptions.AddProduct:
                        var product = GetProductInput();
                        ProductController.AddProduct(product);
                        break;
                    case MainMenuOptions.DeleteProduct:
                        ProductController.DeleteProduct("User choose D");    
                        break;
                    case MainMenuOptions.ViewProducts:
                        var produts = ProductController.GetProducts();
                        ViewProducts(produts);
                        break;
                    case MainMenuOptions.UpdateProduct:
                        ProductController.UpdateProduct("User chose U");
                        break;
                    case MainMenuOptions.QuitProgram:
                        menuMessage = "GoodBye";
                        isMenuRunning = false;
                        //ProductController.SaveProducts();
                        break;
                    default: 
                        Console.WriteLine();
                        break; 
                }
            }
        }

        static void PrintHeader()
        {
            
        }

        static void ViewProducts(List<Product> products)
        {
            Console.WriteLine("======================\n");
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Id}, {product.Name}, {product.Price}\n");
            }
        }

        private static Product GetProductInput()
        {
            Console.WriteLine("Product Name:");
            var name = Console.ReadLine();

            Console.WriteLine("Product Price:");
            var price = decimal.Parse(Console.ReadLine());

            var type = AnsiConsole.Prompt(new SelectionPrompt<ProductType>()
                                            .Title("Product Type")
                                            .AddChoices(ProductType.ChocolateBar, 
                                                        ProductType.Lollipop));

            if (type == ProductType.ChocolateBar)
            {
                Console.WriteLine("Cocoa %");
                var cocoa = int.Parse(Console.ReadLine());

                return new ChocolateBar() { Name = name, Price = price, CocoaPercentage = cocoa};
            }

            Console.WriteLine("Shape: ");
            var shape = Console.ReadLine();

            return new Lollipop()
            {
                Name = name,
                Price = price,
                Shape = shape
            };
        }
    }
}
