using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reckon.Core.ModelDto
{
    public class ResultsDTO
    {
        
        public string Candidate { get; } = "Harpreet Singh";
        public string Text { get; set; } = string.Empty;

        public List<string> Results { get; set; } = new List<string>();

        public List<SubText> subTexts { get; set; } = new List<SubText>();


    }
}
