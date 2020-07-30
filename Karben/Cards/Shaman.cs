using System;
using System.Collections.Generic;
using System.Text;
using Karben.Models;

namespace Karben.Cards
{
    class Shaman : Player
    {
        public override string Status { get; set; } = "";
        public override Stats Stats { get; set; } = new Stats(15, 10f, 0f, 18f);
        public override float SpeedCount { get; set; } = 0f;
        public override Description Description { get; set; } = new Description
            ("Silvana",
            "An unpredictable card, uses her own blood as a weapon. Uses buffs and attack modifiers.",
            "The Shaman card is an unknown entity that forced her way into existence, she is the single most annoying card in the entire deck.",
            "S",
            "");
        public override List<Skill> SkillBook { get; set; } = new List<Skill>()
        {
            new Skill("Spirits Guide the Way", "Use the spirits to guide your way to the heart of the problem", 10f, 10f, false, DateTime.Now),
            new Skill("Cursed Blood", "Your blood was cursed as a child, use it against your enemies and poison them", 3f, 2f, true, DateTime.Now),
            new Skill("Bite", "Well.. You bite them.", 5f, 5f, true, DateTime.Now)
        };
        public override List<Spell> SpellBook { get; set; } = new List<Spell>()
        {
            new Spell("Blood Moon", "Encompass the area in the blood moon giving you a +5 attack modifier", "buff", 10f, 5f, true, DateTime.Now),
        };

        public override bool Attack(Player player, Npc npc)
        {
            foreach (var skill in SkillBook)
            {
                if (skill.Enabled == true && DateTime.Now >= skill.Ready)
                {
                    Console.WriteLine($"Casted {skill.Name}");
                    npc.Stats.Health -= skill.Damage + player.Stats.Damage;
                    skill.Ready = DateTime.Now.AddSeconds(skill.CoolDown);
                    return true;
                }

            }
            return false;
        }

        public override bool Buff(Player player, Npc npc)
        {
            foreach (var spell in SpellBook)
            {
                if (spell.Type == "buff" && DateTime.Now >= spell.Ready && !player.Status.Contains(spell.Name))
                {
                    Console.WriteLine($"Casted: {spell.Name}");
                    if (spell.Name.Contains("Moon"))
                    {
                        player.Stats.Damage += spell.Damage;
                    }
                    spell.Ready = DateTime.Now.AddSeconds(spell.CoolDown);
                    player.Status += spell.Name + " ";
                    return true;
                }
            }
            return false;
        }

        public Shaman()
        {
        }
    }
}
