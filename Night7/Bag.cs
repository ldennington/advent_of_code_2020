using System;
using System.Collections.Generic;
using System.Text;

namespace Night7
{
    internal class Bag
    {
        public string Color { get; set; } = "";

        public List<Bag> Contents { get; set; } = new List<Bag>();
    }
}