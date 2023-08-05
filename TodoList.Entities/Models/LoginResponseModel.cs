using System;
using System.Collections.Generic;
using System.Text;

namespace TodoList.Entities.Models
{
    public class LoginResponseModel
    {
        public int UserId { get; set; } = -1;
        public Boolean HasAccess { get; set; } = false;
    }
}
