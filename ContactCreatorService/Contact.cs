using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHelpers;

namespace ContactCreatorService
{
    [DelimitedRecord(",")]
    public class Contact
    {
        public string first_name;
        public string last_name;
        public int phone;
        public string email;
    }
}
