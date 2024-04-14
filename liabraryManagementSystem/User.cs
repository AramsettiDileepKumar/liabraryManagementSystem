using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace liabraryManagementSystem
{
    public class User
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public User(string name, int iD)
        {
            Name = name;
            ID = iD;
        }
    }
}
