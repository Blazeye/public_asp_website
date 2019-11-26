using System.Collections.Generic;
using SkuAppDomain.Entities;

namespace SkuApplication.Models
{
    public class CommentListViewModel
    {
        public IList<LogComment> CommentList { get; set; }
        public SearchInfo SearchData { get; set; }
        public PagingInfo PagingData { get; set; }
    }
}