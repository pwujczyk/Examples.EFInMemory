using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Examples.InMemory
{
    public class Child
    {
        public int ChildId { get; set; }
        public string Name { get; set; }
        [Required]
        public Dad Dad {get;set;}
    }
}
