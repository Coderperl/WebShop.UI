using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WebShop.Data;
using WebShop.DTO;

namespace WebShop.Access
{
    public class ShoppingCartData : IDataSource<ShoppingCartDTO>
    {
        string path = @"C:\Users\pelle\source\repos\WebShop.UI\WebShop.Data\ShoppingCarts.json";
        public bool Delete(ShoppingCartDTO _object)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ShoppingCartDTO> LoadAll()
        {
            return JsonConvert.DeserializeObject<List<ShoppingCartDTO>>(File.ReadAllText(path));
        }

        public ShoppingCartDTO LoadById(int Id)
        {
            return JsonConvert.DeserializeObject<List<ShoppingCartDTO>>(File.ReadAllText(path)).Find(s => s.Customer.CustomerID == Id);
        }

        public void Save(ShoppingCartDTO _object)
        {
            ShoppingCartDTO newCart = _object;
            List<ShoppingCartDTO> carts = LoadAll().ToList();
            int currentId = (carts.Last().Customer.CustomerID + 1);
            newCart.Customer.CustomerID = currentId;
            carts.Add(newCart);
            carts.Sort();
            File.WriteAllText(path, JsonConvert.SerializeObject(carts));
           
        }

        public ShoppingCartDTO Update(ShoppingCartDTO _object)
        {
            ShoppingCartDTO newCart = _object;
            List<ShoppingCartDTO> cart = LoadAll().ToList();
            cart.RemoveAll(oldCart => oldCart.Customer.CustomerID == newCart.Customer.CustomerID);
            cart.Add(newCart);
            cart.Sort();
            File.WriteAllText(path, JsonConvert.SerializeObject(cart));
            return newCart;
        }
    }
}
