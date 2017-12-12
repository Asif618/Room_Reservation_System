

namespace RoomApplying.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Admin
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Requried")]
        public string Admin_Name { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Requried")]
        public string Password { get; set; }
    }
}
