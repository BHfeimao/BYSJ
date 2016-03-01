using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PM25.Models
{
    public class BodyTem
    {
        public int ID { get; set; }
        public string img { get; set; }
        public string summary { get; set; }
        public string detail { get; set; }
        public string createTime { get; set; }
    }
}