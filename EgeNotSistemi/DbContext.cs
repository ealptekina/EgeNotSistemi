using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgeNotSistemi
{
    class DbContext
    {
        public string Adres = System.IO.File.ReadAllText(@"C:\Users\ThinkPad-E15\Documents\TestEgeNotSistemi.txt");
    }
}
