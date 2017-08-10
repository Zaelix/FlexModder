using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexModder
{
    class ModObject
    {
        public String name;
        public String Type;

        public ModObject(String nm, String typ) {
            this.name = nm;
            this.Type = typ;
        }
    }
}
