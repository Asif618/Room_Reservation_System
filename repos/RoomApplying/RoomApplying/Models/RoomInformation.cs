

namespace RoomApplying.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class RoomInformation
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Requried")]
        public string Room_Name { get; set; }
        [Required(ErrorMessage = "Requried")]
        public string Room_No { get; set; }
        [Required(ErrorMessage = "Requried")]
        public string Confirm_Room { get; set; }
    }
}
