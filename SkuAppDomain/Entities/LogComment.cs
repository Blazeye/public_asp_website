using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkuAppDomain.Entities
{
    public class LogComment
    {

        public int Id { get; set; }
        public int ActualId { get; set; }
        public string Message { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public bool IsComment { get; set; }
        public bool IsMarked { get; set; }
        public bool IsFollowUp { get; set; }
        public bool SignedFollowUp { get; set; }
        public bool WasFollowedUp { get; set; }
        public string FollowUpName { get; set; }
        public DateTime? FollowUpDate { get; set; }
        public string FollowUpRole { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int? NrOfMessage { get; set; }
        public string Color { get; set; }
        public string Category { get; set; }
        public string Subject { get; set; }
        public int UserId { get; set; }
        public bool HasMarkedComment { get; set; }
        public bool AddReplyBox { get; set; }
    }
}
