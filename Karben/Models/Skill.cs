using System;
using System.Collections.Generic;
using System.Text;

namespace Karben.Models
{
    class Skill
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float CoolDown { get; set; }
        public float Damage { get; set; }
        public bool Enabled { get; set; }
        public DateTime Ready { get; set; }
        public Skill(string name, string description, float cooldown, float damage, bool enabled, DateTime ready)
        {
            Name = name;
            Description = description;
            CoolDown = cooldown;
            Damage = damage;
            Enabled = enabled;
            Ready = ready;
        }
    }
}
