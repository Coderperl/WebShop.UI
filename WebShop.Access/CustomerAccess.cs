using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Data;
using WebShop.DTO;

namespace WebShop.Access
{
    public class CustomerAccess : IDataAccess<CustomerDTO>
    {
        private readonly IDataSource<CustomerDTO> _dataSource;

        public CustomerAccess(IDataSource<CustomerDTO> dataSource)
        {
            _dataSource = dataSource;
        }
        public void Delete(CustomerDTO _object)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerDTO> LoadAll()
        {
            return _dataSource.LoadAll();
        }

        public CustomerDTO LoadById(int i)
        {
            return _dataSource.LoadById(i);
        }

        public void Save(CustomerDTO _object)
        {
            _dataSource.Save(_object);
        }

        public IEnumerable<CustomerDTO> Search(string SearchTerm)
        {
            throw new NotImplementedException();
        }

        public CustomerDTO Update(CustomerDTO _object)
        {
            throw new NotImplementedException();
        }

      
    }
}
