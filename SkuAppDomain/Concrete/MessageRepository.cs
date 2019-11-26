using SkuAppDomain.Abstract;
using SkuAppDomain.Entities;
using System;
using System.Linq;

namespace SkuAppDomain.Concrete
{
    public class MessageRepository<T> : GenericRepository<T>, IMessageRepository<T> where T : class
    {
        protected new IDbContext context;
        public MessageRepository(IDbContext dataContext) : base(dataContext)
        {
            this.context = base.context;
        }

        public Message SaveNewMessage(string item, string message, int? userid, int visibleToRoleId, byte marked, byte followup, int followupUser)
        {
            if (userid != null)
            {
                var UserToMessage = this.context.Users.Find(userid);
                var fullSubject = this.context.Subjects.FirstOrDefault(i => i.name == item);
                int? subjectId;
                int categoryId;
                if (fullSubject == null)
                {
                    subjectId = null;
                    categoryId = this.context.Categories.First(i => i.name == item).id;
                }
                else
                {
                    subjectId = fullSubject.id;
                    categoryId = this.context.Subjects.Find(subjectId).category_id;
                }
                DateTime createdAt = DateTime.Now;
                DateTime updatedAt = DateTime.Now;
                return new Message
                {
                    user_id = (int)userid,
                    message = message,
                    category_id = categoryId,
                    subject_id = subjectId,
                    followup = followup,
                    marked = marked,
                    visible_for_role_id = visibleToRoleId,
                    created_at = createdAt,
                    updated_at = updatedAt,
                    followup_user_id = followupUser,
                };
            }
            else return null;
        }

        public Comment SaveNewComment(string comment, int? userid, byte marked, int messageid)
        {
            if (userid != null)
            {
                DateTime createdAt = DateTime.Now;
                DateTime updatedAt = DateTime.Now;
                return new Comment
                {
                    user_id = (int)userid,
                    comment = comment,
                    marked = marked,
                    message_id = messageid,
                    created_at = createdAt,
                    updated_at = updatedAt
                };
            }
            else return null;
        }
    }
}
