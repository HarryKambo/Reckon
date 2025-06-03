using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reckon.Core.ModelDto
{
    public class ReckonPostRequestDTO
    {

        public string Candidate { get; } = "Harpreet Singh";

        public string Text { get; set; } = string.Empty;       

        public List<ReckonPostRequestResults> Results { get; set; } = new List<ReckonPostRequestResults>();
    }
}
