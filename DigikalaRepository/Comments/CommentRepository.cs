using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DigikalaDataAccess.Context;
using DigikalaDataAccess.Entity;

namespace DigikalaRepository.Comments
{
    public class CommentRepository : ICommentRepository
    {
        public void Add(Comment comment)
        {
            using (var db = new DigikalaDB())
            {
                db.Comments.Add(comment);
                db.SaveChanges();
            }
        }

        public List<Comment> GetAll()
        {
            using (var db = new DigikalaDB())
            {
                return db.Comments.ToList();
            }
        }

        public List<Comment> GetAllByUser(string userName)
        {
            using (var db = new DigikalaDB())
            {
                return db.Comments.Where(x => x.UserName.Equals(userName)).ToList();
            }
        }

        public Comment GetById(int Id)
        {
            using (var db = new DigikalaDB())
            {
                return db.Comments.Where(x => x.CommentID == Id).FirstOrDefault();
            }
        }

        public void Update(Comment comment)
        {
            using (var db = new DigikalaDB())
            {
                var lastItem = db.Comments.Where(x => x.CommentID == comment.CommentID).FirstOrDefault();
                lastItem.CommentResponse = comment.CommentResponse;
                db.Update<Comment>(lastItem);
                db.SaveChanges();
            }
        }
    }
}
