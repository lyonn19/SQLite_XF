using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLite_XF.Model
{

    public class Person
    {
        //[PrimaryKey]
        public int  Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public char Sex { get; set; }
        public decimal AnnualIncome { get; set; }
        public bool IsPublicPerson { get; set; }
    }
}
