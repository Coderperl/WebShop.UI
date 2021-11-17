using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Data;
using WebShop.DTO;

namespace WebShop.Access
{
    public class RecieptAccess : IDataAccess<RecieptDTO>
    {
        private readonly IDataSource<RecieptDTO> _dataSource;

        public RecieptAccess(IDataSource<RecieptDTO> dataSource)
        {
            _dataSource = dataSource;
        }
        public void Delete(RecieptDTO _object)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RecieptDTO> LoadAll()
        {
            return _dataSource.LoadAll();
        }

        public RecieptDTO LoadById(int i)
        {
            return _dataSource.LoadById(i);
        }

        public void Save(RecieptDTO _object)
        {
            _dataSource.Save(_object);
        }

        public IEnumerable<RecieptDTO> Search(string SearchTerm)
        {
            throw new NotImplementedException();
        }

        public RecieptDTO Update(RecieptDTO _object)
        {
            return _dataSource.Update(_object);
        }

        
    }
}
