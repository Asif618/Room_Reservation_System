

namespace RoomApplying.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class UserInfo
    {
        public int id { get; set; }
        [Required(ErrorMessage ="Requried")]
        public string User_Name { get; set; }
        [Required(ErrorMessage = "Requried")]
        public string Adress { get; set; }
        [Required(ErrorMessage = "Requried")]
        public string Room_Name { get; set; }
        [Required(ErrorMessage = "Requried")]
        public string Room_No { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Requried")]
        public string Start_Date { get; set; }
        [Required(ErrorMessage = "Requried")]
        [DataType(DataType.Date)]
        public string Finish_Date { get; set; }
        [Required(ErrorMessage = "Requried")]
        public string Phone { get; set; }
    }
}
