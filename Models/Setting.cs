using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMS.Models
{
    public class Setting
    {
        public int SettingId { get; set; }
        public TimeSpan StartTime { get; set; } = TimeSpan.FromMinutes(1);
        public TimeSpan EndTime { get; set; } = TimeSpan.FromMinutes(1);
    }
}