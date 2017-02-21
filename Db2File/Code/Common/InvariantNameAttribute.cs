using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Db2File.Code.Common
{
    class InvariantNameAttribute : Attribute
    {
        public String Name { get; private set; }

        public InvariantNameAttribute(String name)
        {
            Name = name;
        }
    }
}
