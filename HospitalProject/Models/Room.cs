using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalProject.Models
{
    public class Room
    {
        public int RoomId { get; set; }

        public string RoomPurpose { get; set; }

        public int RoomNumber { get; set; }

        public int Floor { get; set; }

        public string Building { get; set; }

    }
}