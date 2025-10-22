using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_DetectionLangue.Models
{
    public class LanguageCandidate
    {
        public string Language { get; set; }
        public double Score { get; set; }

        public string FullLanguageName { get; set; } 
    }
}
