using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Exceptions
{
    public class ObjectNotExist : Exception
    {
        public ObjectNotExist(object obj) : base(String.Format("Cannot find this obj: {0}", obj.ToString())) { }
    }
}
