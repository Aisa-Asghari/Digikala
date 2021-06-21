using System;
using System.Collections.Generic;
using System.Text;

namespace DigikalaDataAccess.Entity
{
    public class Comment
    {
        public int CommentID { get; set; }
        public string UserName { get; set; }
        public string CommentHead { get; set; }
        public string CommentBody { get; set; }
        public string CommentResponse { get; set; }
    }
}
