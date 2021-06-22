using DigikalaDataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigikalaRepository.Comments
{
    public interface ICommentRepository
    {
        void Add(Comment comment);
        List<Comment> GetAll();
        List<Comment> GetAllByUser(String userName);
        Comment GetById(int Id);

    }
}
