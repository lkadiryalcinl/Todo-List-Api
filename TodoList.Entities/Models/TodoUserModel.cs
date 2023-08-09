using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TodoList.Entities.Models
{
    public class TodoUserModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TodoUserID { get; set; }
        public int TodoID { get; set; }
        public int UserID { get; set; }
    }
}
