using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_5_CSharp.Classes
{
    internal class Student
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public string LastName { get; set; }
            public int Unit1 { get; set; }
            public int Unit2 { get; set; }
            public int Unit3 { get; set; }

            public decimal Average { get { return (Unit1 + Unit2 + Unit3) / 3; } }
    }
}
