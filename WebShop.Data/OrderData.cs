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
    public class OrderData : IDataSource<OrderDTO>
    {
        string path = @"C:\Users\pelle\source\repos\WebShop.UI\WebShop.Data\Orders.json";
        public bool Delete(OrderDTO _object)
        {
            if (null != LoadById(_object.OrderID))
            {
                OrderDTO newOrder = _object;
                List<OrderDTO> orders = LoadAll().ToList();
                orders.RemoveAll(OldUser => OldUser.OrderID == newOrder.OrderID);
                orders.Sort();
                File.WriteAllText(path, JsonConvert.SerializeObject(orders));
                return true;
            }
            else return false;
        }

        public IEnumerable<OrderDTO> LoadAll()
        {
            return JsonConvert.DeserializeObject<List<OrderDTO>>(path);
        }

        public OrderDTO LoadById(int Id)
        {
            return JsonConvert.DeserializeObject<List<OrderDTO>>(File.ReadAllText(path)).Find(o => o.OrderID == Id);
        }

        public void Save(OrderDTO _object)
        {
            OrderDTO newOrder = _object;
            List<OrderDTO> orders = LoadAll().ToList();
            int currentId = (orders.Last().OrderID + 1);
            newOrder.OrderID = currentId;
            orders.Add(newOrder);
            orders.Sort();
            File.WriteAllText(path, JsonConvert.SerializeObject(orders));
        }

        public OrderDTO Update(OrderDTO _object)
        {
            OrderDTO newOrder = _object;
            List<OrderDTO> orders = LoadAll().ToList();
            orders.RemoveAll(oldOrder => oldOrder.OrderID == newOrder.OrderID);
            orders.Add(newOrder);
            orders.Sort();
            File.WriteAllText(path, JsonConvert.SerializeObject(orders));
            return newOrder;

        }
    }
}
