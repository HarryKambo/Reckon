using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reckon.Core.ModelDto
{
    public class SubText
    {
        public string Name { get; set; } = string.Empty;

        public List<string> Results { get; set; } = new List<string>();

        public string IndicesString {

            get { return string.Join(",", Results); }
        }
    }
}
