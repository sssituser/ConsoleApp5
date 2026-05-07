using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnitityFrameworkConsoleExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BusinessLogic bl = new BusinessLogic();
            Table_Product prod = new Table_Product();
            Console.Write("Enter Product ID : ");
            prod.ProductId = int.Parse(Console.ReadLine());
            Console.Write("Enter Product Name : ");
            prod.ProductName= Console.ReadLine();
            Console.Write("Enter Product Price : ");
            prod.ProductPrice = int.Parse(Console.ReadLine());
            if (bl.AddProduct(prod)) {

                Console.WriteLine("Product Inserted....");

            }
            else
            {
                Console.WriteLine("Product  Insertion Failed...");
            }



        }
    }
}
