using System;
using System.Collections.Generic;

namespace TestWebApi.Models
{
    public class DataModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public int GpioId { get; set;}
    }
}
