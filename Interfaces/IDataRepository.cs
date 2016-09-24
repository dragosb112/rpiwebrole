using System.Collections.Generic;
using TestWebApi.Models;

namespace TestWebApi.Interfaces
{
    public interface IDataRepository
    {
        IEnumerable<DataModel> GetAll();
        DataModel Get(int id);
        DataModel Add(DataModel item);
        void Remove(int id);
        bool Update(DataModel item);

    }
}