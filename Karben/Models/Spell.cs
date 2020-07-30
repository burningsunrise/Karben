using System;
using System.Collections.Generic;
using System.Text;
namespace Karben
{
    class Spell 
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public float CoolDown { get; set; }
        public float Damage { get; set; }
        public bool Enabled { get; set; }
        public DateTime Ready { get; set; }
        public Spell(string name, string description, string type, float cooldown, float damage, bool enabled, DateTime ready)
        {
            Name = name;
            Description = description;
            Type = type;
            CoolDown = cooldown;
            Damage = damage;
            Enabled = enabled;
            Ready = ready;
        }
    }
}
