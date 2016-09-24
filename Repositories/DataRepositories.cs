using System;
using System.Collections.Generic;
using TestWebApi.Interfaces;
using TestWebApi.Models;

namespace TestWebApi.Repositories
{
    public class DataRepository : IDataRepository
    {
        private List<DataModel> _data = new List<DataModel>();
        private int _nextId = 1;

        public DataRepository()
        {
            _data.Add(new DataModel {Id = 1, Name = "Value1", Value = 1});
            _data.Add(new DataModel {Id = 2, Name = "Value2", Value = 2});
            _nextId += 2;
        }

        public DataModel Add(DataModel item)
        {
            if(item == null)
            {
                throw new ArgumentNullException("Item");
            }

            item.Id = _nextId++;
            _data.Add(item);

            return item;

        }

        public DataModel Get(int id)
        {
            return _data.Find(x => x.Id == id);
        }

        public IEnumerable<DataModel> GetAll()
        {
            return _data;
        }

        public void Remove(int id)
        {
            _data.RemoveAll(x => x.Id == id);
        }

        public bool Update(DataModel item)
        {
            if(item == null)
            {
                throw new ArgumentNullException("Item");
            }

            var index = _data.FindIndex(x => x.Id == item.Id);

            if(index == -1)
            {
                return false;
            }

            _data.RemoveAt(index);
            _data.Add(item);

            return true;
        }
    }
}