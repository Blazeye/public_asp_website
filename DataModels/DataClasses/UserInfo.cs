using System;
using System.Collections.Generic;
using System.Text;

namespace SKU.DataClasses
{
    public class UserInfo : BaseDataClass
    {
        public string Name { get; set; }
        public bool Active { get; set; } //bool of int? 0/1 /* JH Definitly bool */
        public UserColor Color { get; set; }
        public int Role { get; set; }
    }
}
