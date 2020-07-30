using System;
using System.Collections.Generic;
using System.Text;

namespace Karben.Models
{
    abstract class Npc
    {
        public abstract Random Random { get; set; }
        public abstract Stats Stats { get; set; }
        public abstract string Name { get; set; }
        public abstract float SpeedCount { get; set; }
        public abstract List<Spell> SpellBook { get; set; }
        public abstract List<Skill> SkillBook { get; set; }
        public abstract void Attack(Skill skill, Player player, Npc npc);
        public abstract void Buff(Skill skill, Player player, Npc npc);
    }
}
