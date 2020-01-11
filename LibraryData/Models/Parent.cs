using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData.Models
{
    public class Parent
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string TelephoneNumber { get; set; }

        //virtual for lazy loading
        public virtual IEnumerable<Child> Children { get; set; }
        public virtual IEnumerable<Item> Items { get; set; }
    }
}
