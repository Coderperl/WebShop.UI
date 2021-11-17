using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Data;
using WebShop.DTO;

namespace WebShop.Access
{
    public class ProductData : IDataSource<ProductDTO>
    {
        string path = @"C:\Users\pelle\source\repos\WebShop.UI\WebShop.Data\Products.json";
        public bool Delete(ProductDTO _object)
        {
            if (null != LoadById(_object.ProductID))
            {
                ProductDTO newProduct = _object;
                List<ProductDTO> products = LoadAll().ToList();
                products.RemoveAll(oldProduct => oldProduct.ProductID == newProduct.ProductID);
                products.Sort();
                File.WriteAllText(path, JsonConvert.SerializeObject(products));
                return true;
            }
            else return false;
        }

        public IEnumerable<ProductDTO> LoadAll()
        {
            return JsonConvert.DeserializeObject<List<ProductDTO>>(File.ReadAllText(path));
        }

        public ProductDTO LoadById(int Id)
        {
            return JsonConvert.DeserializeObject<List<ProductDTO>>(File.ReadAllText(path)).Find(p => p.ProductID == Id);
        }


        public void Save(ProductDTO _object)
        {
            ProductDTO newProduct = _object;
            List<ProductDTO> products = LoadAll().ToList();
            int currentId = (products.Last().ProductID + 1);
            newProduct.ProductID = currentId;
            products.Add(newProduct);
            products.Sort();
            File.WriteAllText(path, JsonConvert.SerializeObject(products));

        }

        public ProductDTO Update(ProductDTO _object)
        {
            ProductDTO newProduct = _object;
            List<ProductDTO> products = LoadAll().ToList();
            products.RemoveAll(oldProduct => oldProduct.ProductID == newProduct.ProductID);
            products.Add(newProduct);
            products.Sort();
            File.WriteAllText(path, JsonConvert.SerializeObject(products));
            return newProduct;
        }
        
    }
}
