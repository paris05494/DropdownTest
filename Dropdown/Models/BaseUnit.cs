using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dropdown.Models
{
    public class BaseUnit
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public override string ToString() => Name;
    }
}
