using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataClean
{
   public class CustomPayload:Payload
    {
        public CustomPayload(string name, string from, string to) : base(name, from, to)
        {
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
