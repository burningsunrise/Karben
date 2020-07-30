using System;
using System.Collections.Generic;
using System.Text;

namespace Karben
{
    class Description
    {
        public string Name { get; set; }
        public string CardDescription { get; set; }
        public string Story { get; set; }
        public string Rarity { get; set; }
        public string Image { get; set; }

        public Description(string name, string carddescription, string story, string rarity, string image)
        {
            Name = name;
            CardDescription = carddescription;
            Story = story;
            Rarity = rarity;
            Image = image;
        }
    }
}
