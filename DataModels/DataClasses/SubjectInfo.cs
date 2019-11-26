using System;
using System.Collections.Generic;
using System.Text;

namespace SKU.DataClasses
{
    public class SubjectInfo : BaseDataClass /* JH: TIP Waarom SubjectInfo en niet Subject? */
    {
        public string Name { get; set; }
        public Category Category { get; set; }
        public bool Active { get; set; }
    }
}
