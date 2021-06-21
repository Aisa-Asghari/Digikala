using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DigikalaDataAccess
{
    public class User
    {
        public int UserID { get; set; }

        [Required(ErrorMessage = "نام كاربري خود را وارد كنيد")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "رمز عبور حساب كاربري خود را وارد کنید")]
        public string UserPassword { get; set; }
        public int UserType { get; set; }   // 0 => seller      1 => customer
        public int LoginCount { get; set; }
        public DateTime FirstLogin { get; set; }
        public DateTime LasstLogin { get; set; }
    }
}
