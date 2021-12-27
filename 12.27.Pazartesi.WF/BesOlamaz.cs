using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12._27.Pazartesi.WF
{
    class BesOlamaz:Exception
    {
        public override string Message => "Asla Bes Olamaz";
    }
}
