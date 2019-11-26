using System;
using System.Collections.Generic;
using System.Text;

namespace SKU.DataClasses
{
    public class Category : BaseDataClass
    {
        public bool Active { get; set; }
        public bool IsAnimal { get; set; }
        public string Name { get; set; }
    }
}
