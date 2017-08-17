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
        private bool init = false;
        private bool regi = false;
        private bool wasAdded = false;

        public bool Init
        {
            get
            {
                return init;
            }

            set
            {
                init = value;
            }
        }

        public bool Regi
        {
            get
            {
                return regi;
            }

            set
            {
                regi = value;
            }
        }

        public bool WasAdded
        {
            get
            {
                return wasAdded;
            }

            set
            {
                wasAdded = value;
            }
        }

        public ModObject(String nm, String typ) {
            this.name = nm;
            this.Type = typ;
        }
    }
}
