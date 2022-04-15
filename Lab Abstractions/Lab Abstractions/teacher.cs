using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Abstractions
{
    internal class teacher :member
    {
        private string _majo;

        public string majo
        {
            get { return _majo; }
            set { _majo = value; }
        }
    }
}
