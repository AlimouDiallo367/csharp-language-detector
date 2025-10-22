using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_DetectionLangue.Models
{
    public class TokenStatus
    {
        public string Date { get; set; }
        public int Requests { get; set; } 
        public int Bytes { get; set; } 
        public string Plan { get; set; } 
        public string Plan_Expires { get; set; } 
        public int Daily_Requests_Limit { get; set; } 
        public int Daily_Bytes_Limit { get; set; } 
        public string Status { get; set; } 
    }
}
