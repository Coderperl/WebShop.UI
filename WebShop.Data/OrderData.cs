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
        string path = @"C:\Users\pelle\source\repos\WebShop.UI\WebShop.Data\json\Orders.json";
        public bool Delete(OrderDTO _object)
        {
            if (null != LoadById(_object.OrderId))
            {
                OrderDTO newOrder = _object;
                List<OrderDTO> orders = LoadAll().ToList();
                orders.RemoveAll(oldOrder => oldOrder.OrderId == newOrder.OrderId);
                orders.Sort();
                File.WriteAllText(path, JsonConvert.SerializeObject(orders));
                return true;
            }
            else return false;
        }

        public IEnumerable<OrderDTO> LoadAll()
        {
            return JsonConvert.DeserializeObject<IEnumerable<OrderDTO>>(File.ReadAllText(path));
        }

        public OrderDTO LoadById(int Id)
        {
            return JsonConvert.DeserializeObject<List<OrderDTO>>(File.ReadAllText(path)).Find(o => o.OrderId == Id);
        }

        public void Save(OrderDTO _object)
        {
            List<OrderDTO> orders = LoadAll().ToList();
            
            if (orders.Count() == 0)
            {
                _object.OrderId = 0;
            }
            else
            {
                _object.OrderId = (orders.Max(x=> x.OrderId) + 1);
            }
            orders.Add(_object);
            File.WriteAllText(path, JsonConvert.SerializeObject(orders, Formatting.Indented));
        }

        public OrderDTO Update(OrderDTO _object)
        {
            List<OrderDTO> orders = LoadAll().ToList();
            orders.RemoveAll(oldOrder => oldOrder.OrderId == _object.OrderId);
            orders.Add(_object);
            File.WriteAllText(path, JsonConvert.SerializeObject(orders));
            return _object;
        }
    }
}
