using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoList.Entities.Models
{
    public class TodoModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TodoID { get; set; }

        public int UserID { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "PriortyType")]
        public string PriorityType { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "DateCreated")]
        public DateTime DateCreated { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "DateStart")]
        public DateTime DateStart { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "DateEnd")]
        public DateTime DateEnd { get; set; }

        [Display(Name = "Finished")]
        public Boolean IsFinished { get; set; } = false;

        [Display(Name = "Favorite")]
        public Boolean IsFav { get; set; } = false;
        [Display(Name = "Active")]
        public Boolean IsActive { get; set; } = true;
    }
}
