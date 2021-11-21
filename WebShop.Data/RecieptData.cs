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
    public class RecieptData : IDataSource<RecieptDTO>
    {
        string path = @"C:\Users\pelle\source\repos\WebShop.UI\WebShop.Data\json\Reciepts.json";
        public bool Delete(RecieptDTO _object)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RecieptDTO> LoadAll()
        {
            return JsonConvert.DeserializeObject<List<RecieptDTO>>(File.ReadAllText(path));
        }

        public RecieptDTO LoadById(int i)
        {
            throw new NotImplementedException();
        }

        public void Save(RecieptDTO _object)
        {
            RecieptDTO newReciept = _object; ;
            List<RecieptDTO> reciepts = LoadAll().ToList();
            string currentReciept = (reciepts.Last().Reciept + 1);
            newReciept.Reciept = currentReciept;
            reciepts.Add(newReciept);
            reciepts.Sort();
            File.WriteAllText(path, JsonConvert.SerializeObject(reciepts));
        }

        public RecieptDTO Update(RecieptDTO _object)
        {
            throw new NotImplementedException();
        }
    }
}
