using System;
using System.Collections.Generic;
using System.Text;
using Karben.Models;

namespace Karben
{
    abstract class Player
    {
        public abstract string Status { get; set; }
        public abstract List<Skill> SkillBook { get; set; }
        public abstract List<Spell> SpellBook { get; set; }
        public abstract Stats Stats { get; set; }
        public abstract Description Description { get; set; }
        public abstract float SpeedCount { get; set; }
        public abstract bool Attack(Player player, Npc npc);
        public abstract bool Buff(Player player, Npc npc);
    }
}
