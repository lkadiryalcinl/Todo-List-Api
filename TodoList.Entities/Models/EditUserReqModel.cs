using System;
using System.Collections.Generic;
using System.Text;

namespace TodoList.Entities.Models.ReqModels
{
    public class EditUserReqModel
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
