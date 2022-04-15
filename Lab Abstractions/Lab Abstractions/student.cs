using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Abstractions
{
    internal class student : member
    {
        private string _student_id;
        private string _major;

        public string StudentId
        {
            get { return _student_id; }
            set { _student_id = value; }
        }
        public string Major
        {
            get { return _major; }
            set { _major = value; }
        }
    }
}
