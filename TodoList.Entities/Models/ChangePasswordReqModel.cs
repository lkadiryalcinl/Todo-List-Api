using System;
using System.Collections.Generic;
using System.Text;

namespace TodoList.Entities.Models.ReqModels
{
    public class ChangePasswordReqModel
    {
        public int UserID { get; set; }
        public string oldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
