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

        public string FullLanguageName => LanguageCodeMap.ContainsKey(Language)
            ? LanguageCodeMap[Language]
            : Language;

        private static readonly Dictionary<string, string> LanguageCodeMap = new()
        {
            {"fr", "FRENCH"},
            {"en", "ENGLISH"},
            {"es", "SPANISH"},
            {"de", "GERMAN"},
            {"it", "ITALIAN"},
            {"pt", "PORTUGUESE"},
            {"ja", "JAPANESE"},
            {"zh", "CHINESE"},
            // tu peux ajouter d'autres codes ISO que tu veux
        };   
    }
}
