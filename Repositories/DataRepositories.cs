using System;
using System.Collections.Generic;
using System.Linq;
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
            _data.Add(new DataModel {Id = 1, Name = "LED0", Value = 1, GpioId = 18});
            _data.Add(new DataModel {Id = 2, Name = "LED1", Value = 1, GpioId = 23});
            _data.Add(new DataModel {Id = 3, Name = "LED2", Value = 1, GpioId = 24});
            _data.Add(new DataModel {Id = 4, Name = "LED3", Value = 1, GpioId = 25});
            _data.Add(new DataModel {Id = 5, Name = "LED4", Value = 1, GpioId = 12});
            _data.Add(new DataModel {Id = 6, Name = "LED5", Value = 1, GpioId = 16});
            _data.Add(new DataModel {Id = 7, Name = "LED6", Value = 1, GpioId = 20});
            _data.Add(new DataModel {Id = 8, Name = "LED7", Value = 1, GpioId = 21});
            _nextId += _data.Count;
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

            _data = _data.OrderBy(x => x.Id).ToList();

            return true;
        }
    }
}