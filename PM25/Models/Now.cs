using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PM25.Models
{
    public class Now
    {
        public int ID { get; set; }
        public string title { get; set; }
        public string summary { get; set; }
        public string downloadURL { get; set; }
        public string createTime { get; set; }
    }
}