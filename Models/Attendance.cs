using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Timers;

namespace AMS.Models
{
    public class Attendance
    {
        [Key]
        public int AttendanceId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [Required]
        public DateTime Date { get; set; } = DateTime.Today;
        [Required]
        public TimeSpan? CheckInTime { get; set; } = TimeSpan.FromMinutes(1);
        [Required]
        public TimeSpan? CheckOutTime { get; set; } = TimeSpan.FromMinutes(1);
        public string Status { get; set; }
        public User User { get; set; }
    }

}