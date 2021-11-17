using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Data;
using WebShop.DTO;

namespace WebShop.Access
{
    public class OrderAccess : IDataAccess<OrderDTO>
    {
        private readonly IDataSource<OrderDTO> _dataSource;

        public OrderAccess(IDataSource<OrderDTO> dataSource)
        {
            _dataSource = dataSource;
        }
        public void Delete(OrderDTO _object)
        {
             _dataSource.Delete(_object);
        }

        public IEnumerable<OrderDTO> LoadAll()
        {
            return _dataSource.LoadAll();
        }

        public OrderDTO LoadById(int i)
        {
            return _dataSource.LoadById(i);
        }

        public void Save(OrderDTO _object)
        {
            _dataSource.Save(_object);
        }

        public IEnumerable<OrderDTO> Search(string SearchTerm)
        {
            throw new NotImplementedException();
        }

        public OrderDTO Update(OrderDTO _object)
        {
            return _dataSource.Update(_object);
        }

        
    }
}
