using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkuAppDomain.Entities
{
    public class SearchInfo
    {
        public string CurrentCategory { get; set; }
        public string CurrentSubject { get; set; }
        public string CurrentDate { get; set; }
        public bool? CurrentMarked { get; set; }
        public bool? CurrentFollowup { get; set; }
    }
}
