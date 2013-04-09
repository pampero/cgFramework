using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Base
{
    public abstract class BaseService
    {
        public ILog Logger { get; set; }
    }
}

   