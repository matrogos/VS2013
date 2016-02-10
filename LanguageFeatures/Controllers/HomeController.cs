using LanguageFeatures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LanguageFeatures.Controllers
{
    public class Product
    {
        public int ProductID { get; set; }
        //public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }

        private string name;
        public string Name
        {
            get { return ProductID + name; }
            set { name = value; }
        }
    }
    public class HomeController : Controller
    {
        //
        // GET: /Home/
       

        public string Index()
        {
            return "Przejście do adresu URL pokazującego przykład";
        }

        public ViewResult AutoProperty()
        {
            Product myProduct = new Product();
            myProduct.Name = "produkt";

            string productName = myProduct.Name;

            return View("Result", (object)String.Format("Nazwa produktu: {0}", productName));
        }

        public ViewResult CreateProduct()
        {
            Product myProduct = new Product
            {
                ProductID = 1,
                Name = "Kajak",
                Price = 275M,
                Category = "Sporty wodne",
                Description = "Łódka jednoosobowa"
            };

            return View("Result", (object)String.Format("Kategoria: {0}", myProduct.Category));
        }

        public ViewResult CreateCollection()
        {
            ShoppingCart cart = new ShoppingCart
            {
                Products = new List<Product> {
                    new Product {Name="Kajak", Price=100M},
                    new Product{Name = "Kamizelka ratunkowa", Price=50M},
                    new Product {Name="Wiosło", Price=75.5M}
                }
            };

            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product> {
                    new Product {Name="Kajak", Price=100M, Category="Łódki"},
                    new Product{Name = "Kamizelka ratunkowa", Price=50M, Category = "Sprzęt"},
                    new Product {Name="Wiosło", Price=75.5M, Category="Sprzęt"}
                }
            };

            decimal cartTotal = cart.TotalPrices();

            decimal total = 0;
            foreach (Product prod in products.FilterByCategory("Sprzęt"))
            {
                total += prod.Price;
            }
            return View("Result", (object)String.Format("Suma: {0}", total));
        }
    }
}
