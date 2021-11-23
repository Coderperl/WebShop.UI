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
            {
                List<RecieptDTO> receipts = LoadAll().ToList();

                if (receipts.Count() == 0)
                {
                    _object.ReceiptId = 0;
                }
                else
                {
                    _object.ReceiptId = (receipts.Max(x=> x.ReceiptId)+ 1);
                }
                receipts.Add(_object);
                File.WriteAllText(path, JsonConvert.SerializeObject(receipts));
            }
        }

        public RecieptDTO Update(RecieptDTO _object)
        {
            throw new NotImplementedException();
        }
    }
}
