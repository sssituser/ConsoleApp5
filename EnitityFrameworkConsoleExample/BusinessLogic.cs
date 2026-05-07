using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnitityFrameworkConsoleExample
{
    internal class BusinessLogic
    {
        ProjectDbEntites Pdb;
        Table_Product Product;
        public BusinessLogic() {
        
            Pdb = new ProjectDbEntites();
            Product = new Table_Product();
        
        }
        public bool AddProduct(Table_Product product)
        {
            Pdb.Table_Product.Add(product);
            int res = Pdb.SaveChanges();
            return res == 1;
        }
        public bool DeleteProduct(Table_Product product)
        {
         product= Pdb.Table_Product.Find(product.ProductId);
            int res = 0;
            if (product != null)
            {
                Pdb.Table_Product.Remove(product);
                res = Pdb.SaveChanges();
                return res == 1;
            }
            return false;

        }
        public bool UpdateProduct(Table_Product updatedProduct) // OldId newproname,newproprice
        {
            Table_Product exProduct = Pdb.Table_Product.Find(updatedProduct.ProductId);
            exProduct = updatedProduct;
            int res = Pdb.SaveChanges();
            return res == 1;
            
        }
        public Table_Product FindProduct(Table_Product product)
        {
            return Pdb.Table_Product.Find(product.ProductId);
        }
        public List<Table_Product> FindAll()
        {
            return Pdb.Table_Product.ToList();
        }
    }
}
