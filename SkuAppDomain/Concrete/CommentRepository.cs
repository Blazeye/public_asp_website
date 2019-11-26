using SkuAppDomain.Abstract;
using SkuAppDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SkuAppDomain.Concrete
{
    public class CommentRepository<T> : GenericRepository<T>, ICommentRepository<T> where T : class
    {
        new protected IDbContext context; 

        public CommentRepository(IDbContext context) : base(context)
        {
            this.context = base.context;
        }

        public virtual List<LogComment> FilterComments(int role)
        {
            List<Message> MessageQ = this.context.Messages.Where(m => m.visible_for_role_id <= role).OrderByDescending(m => m.updated_at).ToList();
            List<LogComment> commentList = new List<LogComment>();
            int count = 0;
            foreach (var mItem in MessageQ)
            {
                count++;

                string category = this.context.Categories.Find(mItem.category_id).name;
                string subject;
                if (mItem.subject_id != null)
                {
                    subject = this.context.Subjects.Find(mItem.subject_id).name;
                }
                else
                {
                    subject = null;
                }
                string followUpName = "";
                string followUpRole = "";
                bool wasFollowedUp = false;
                bool signedFollowUp = false;
                User mFollowupUser = this.context.Users.Find(mItem.followup_user_id);
                if (mItem.followup_user_id != 0)
                {
                    followUpName = mFollowupUser.username;
                    followUpRole = this.context.Roles.Find(mFollowupUser.role).description;
                    signedFollowUp = true;
                }
                if(mItem.followup_date != null) { wasFollowedUp = true; }
                var mUser = this.context.Users.Find(mItem.user_id);
                string mUsername = mUser.username;
                string mRole = this.context.Roles.Find(mUser.role).description;
                string mColor = this.context.Colors.Find(mUser.color).color;
                bool mIsMarked = Convert.ToBoolean(mItem.marked);
                bool isFollowUp = Convert.ToBoolean(mItem.followup);
                int mId = count - 1;

                commentList.Add(new LogComment
                {
                    Id = count,
                    ActualId = mItem.id,
                    Category = category,
                    Color = mColor,
                    CreatedDate = mItem.created_at,
                    UpdatedDate = mItem.updated_at,
                    IsComment = false,
                    Username = mUsername,
                    IsMarked = mIsMarked,
                    Message = mItem.message,
                    NrOfMessage = mItem.id,
                    Subject = subject,
                    IsFollowUp = isFollowUp,
                    FollowUpDate = mItem.followup_date,
                    FollowUpName = followUpName,
                    FollowUpRole = followUpRole,
                    WasFollowedUp = wasFollowedUp,
                    SignedFollowUp = signedFollowUp,
                    UserId = mItem.user_id,
                    HasMarkedComment = false,
                    Role = mRole,
                    AddReplyBox = false,
                });


                
                var CommentQ = this.context.Comments.Where(m => m.message_id == mItem.id).ToList();
                foreach(var cItem in CommentQ)
                {
                    count++;
                    var cUser = this.context.Users.Find(cItem.user_id);
                    string cUsername = cUser.username;
                    string cColor = this.context.Colors.Find(cUser.color).color;
                    bool cIsMarked = Convert.ToBoolean(cItem.marked);
                    string cRole = this.context.Roles.Find(cUser.role).description;
                    if (cIsMarked) { commentList[mId].HasMarkedComment = true; }

                    commentList.Add(new LogComment
                    {
                        Id = count,
                        ActualId = cItem.id,
                        Category = category,
                        Subject = subject,
                        Color = cColor,
                        CreatedDate = cItem.created_at,
                        UpdatedDate = cItem.updated_at,
                        IsComment = true,
                        IsMarked = cIsMarked,
                        Message = cItem.comment,
                        NrOfMessage = mItem.id,
                        Username = cUsername,
                        IsFollowUp = isFollowUp,
                        FollowUpDate = mItem.followup_date,
                        FollowUpName = followUpName,
                        FollowUpRole = followUpRole,
                        WasFollowedUp = wasFollowedUp,
                        SignedFollowUp = signedFollowUp,
                        UserId = cItem.user_id,
                        HasMarkedComment = cIsMarked,
                        Role = mRole,
                        AddReplyBox = false,
                    });
                }
                commentList.Last().AddReplyBox = true;
            }
            return commentList;
        }

    }
}
