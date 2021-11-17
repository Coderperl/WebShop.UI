using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Data;
using WebShop.DTO;

namespace WebShop.Access
{
    public class ShoppingCartAccess : IDataAccess<ShoppingCartDTO>
    {
        private readonly IDataSource<ShoppingCartDTO> _dataSource;

        public ShoppingCartAccess(IDataSource<ShoppingCartDTO> dataSource)
        {
            _dataSource = dataSource;
        }
        public void Delete(ShoppingCartDTO _object)
        {
            _dataSource.Delete(_object);
        }

        public IEnumerable<ShoppingCartDTO> LoadAll()
        {
            return _dataSource.LoadAll();
        }

        public ShoppingCartDTO LoadById(int i)
        {
            return _dataSource.LoadById(i);
        }

        public void Save(ShoppingCartDTO _object)
        {
            _dataSource.Save(_object);
        }

        public IEnumerable<ShoppingCartDTO> Search(string SearchTerm)
        {
            throw new NotImplementedException();
        }

        public ShoppingCartDTO Update(ShoppingCartDTO _object)
        {
           return _dataSource.Update(_object);
        }

        
    }
}
