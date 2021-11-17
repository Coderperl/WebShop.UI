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
    public class CardData : IDataSource<CardDTO>
    {
        string path = @"C:\Users\pelle\source\repos\WebShop.UI\WebShop.Data\Card.json";
        public bool Delete(CardDTO _object)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CardDTO> LoadAll()
        {
            throw new NotImplementedException();
        }

        public CardDTO LoadById(int i)
        {
            return JsonConvert.DeserializeObject<CardDTO>(File.ReadAllText(path));
        }

        public void Save(CardDTO _object)
        {
            throw new NotImplementedException();
        }

        public CardDTO Update(CardDTO _object)
        {
            throw new NotImplementedException();
        }
    }
}
