using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Data;
using WebShop.DTO;

namespace WebShop.Access
{
    public class CardAccess : IDataAccess<CardDTO>
    {
        private readonly IDataSource<CardDTO> _DataSource;

        public CardAccess(IDataSource<CardDTO> dataSource)
        {
            _DataSource = dataSource;
        }
        public void Delete(CardDTO _object)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CardDTO> LoadAll()
        {
            return _DataSource.LoadAll();
        }

        public CardDTO LoadById(int i)
        {
            return _DataSource.LoadById(i);
        }

        public void Save(CardDTO _object)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CardDTO> Search(string SearchTerm)
        {
            throw new NotImplementedException();
        }

        public CardDTO Update(CardDTO _object)
        {
            throw new NotImplementedException();
        }

     
    }
}
