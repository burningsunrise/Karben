using System;
using System.Collections.Generic;
using System.Text;
using Karben.Models;

namespace Karben.Enemies
{
    class Goblin : Npc
    {
        public override Stats Stats { get; set; } = new Stats(10f, 10f, 0f, 23f);
        public override float SpeedCount { get; set; } = 0f;
        public override string Name { get; set; } = "Japanese Gobrin";
        public override List<Skill> SkillBook { get; set; } = new List<Skill>() { new Skill("Slash", "Slashing strike", 5, 0, true, DateTime.Now) };
        public override List<Spell> SpellBook { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override Random Random { get; set; } = new Random();

        public Goblin()
        {
           
        }

        public override void Attack(Skill skill, Player player, Npc npc)
        {
            if (skill.Name == "Slash")
                skill.Damage = Random.Next(1, 4);
            player.Stats.Health -= skill.Damage + npc.Stats.Damage;
        }

        public override void Buff(Skill skill, Player player, Npc npc)
        {
            throw new NotImplementedException();
        }
    }
}
