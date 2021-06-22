using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DigikalaDataAccess.Entity
{
    public class Comment
    {
        public int CommentID { get; set; }
        public string UserName { get; set; }
        [Required(ErrorMessage = "موضوع پیام خود را وارد كنيد")]
        public string CommentHead { get; set; }
        [Required(ErrorMessage = "متن پیام خود را وارد كنيد")]
        public string CommentBody { get; set; }
    }
}
