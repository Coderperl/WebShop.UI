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
    public class CustomerData : IDataSource<CustomerDTO>
    {
        string path = @"C:\Users\pelle\source\repos\WebShop.UI\WebShop.Data\Customers.json";
        public bool Delete(CustomerDTO _object)
        {
            if (null != LoadById(_object.CustomerID))
            {
                CustomerDTO newCustomer = _object;
                List<CustomerDTO> customers = LoadAll().ToList();
                customers.Remove(newCustomer);
                File.WriteAllText(path, JsonConvert.SerializeObject(customers));
                return true;
            }
            else return false;
        }

        public IEnumerable<CustomerDTO> LoadAll()
        {
            return JsonConvert.DeserializeObject<List<CustomerDTO>>(File.ReadAllText(path));
        }

        public CustomerDTO LoadById(int Id)
        {
            return JsonConvert.DeserializeObject<List<CustomerDTO>>(File.ReadAllText(path)).Find(u => u.CustomerID == Id);
        }

        public void Save(CustomerDTO _object)
        {
            CustomerDTO newCustomer = _object;
            List<CustomerDTO> customers = LoadAll().ToList();
            int currentId = (customers.Last().CustomerID + 1);
            newCustomer.CustomerID = currentId;
            customers.Add(newCustomer);
            customers.Sort();
            File.WriteAllText(path, JsonConvert.SerializeObject(customers));
        }

        public CustomerDTO Update(CustomerDTO _object)
        {
            throw new NotImplementedException();
        }
    }
}
