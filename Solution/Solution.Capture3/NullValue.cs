using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Capture3
{
    class NullValue
    {
        public Phone Phone { get; set; }
    }

    class Phone
    {
        public Company Company { get; set; }
    }

    class Company
    {
        public string Name { get; set; }

    }

}
