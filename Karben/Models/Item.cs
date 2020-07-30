using System;
using System.Collections.Generic;
using System.Text;

namespace Karben
{
    abstract class Item
    {
        public abstract string Name { get; set; }
        public abstract string Description { get; set; }
        public abstract int Quantity { get; set; }

        public Item(string name, string description, int quantity)
        {
            Name = name;
            Description = description;
            Quantity = quantity;
        }
    }
}
