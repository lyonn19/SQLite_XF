using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace SQLite_XF.Model
{

    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public int  Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDateTime { get; set; }
        public bool IsPublicPerson { get; set; }
    }
}
