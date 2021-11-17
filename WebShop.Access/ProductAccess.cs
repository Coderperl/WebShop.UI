using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Data;
using WebShop.DTO;

namespace WebShop.Access
{
    public class ProductAccess : IDataAccess<ProductDTO>
    {
        private readonly IDataSource<ProductDTO> _dataSource;

        public ProductAccess(IDataSource<ProductDTO> dataSource)
        {
            _dataSource = dataSource;
        }
        public void Delete(ProductDTO _object)
        {
            _dataSource.Delete(_object);
        }

        public IEnumerable<ProductDTO> LoadAll()
        {
            return _dataSource.LoadAll();
        }

        public ProductDTO LoadById(int i)
        {
            return _dataSource.LoadById(i);
        }

        public void Save(ProductDTO _object)
        {
            _dataSource.Save(_object);
        }

        public ProductDTO Update(ProductDTO _object)
        {
            return _dataSource.Update(_object);
        }
       
    }
}
