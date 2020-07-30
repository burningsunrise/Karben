using System;
using System.Collections.Generic;
using System.Text;
using Karben.Models;

namespace Karben.Cards
{
    class Assassin : Player
    {
        public override string Status { get; set; } = "";
        public override Stats Stats { get; set; } = new Stats(15, 10f, 0f, 15f);
        public override float SpeedCount { get; set; } = 0f;
        public override List<Skill> SkillBook { get; set; } = new List<Skill>();
        public override List<Spell> SpellBook { get; set; } = new List<Spell>();
        public override Description Description { get; set; } = new Description
        (
            "Kausa",
            "Focuses on high damage, very straight forward and very deadly.",
            "A templar assasin, loyal to the king, and whomever pays her the highest.",
            "S",
            ""
        );
        public override bool Attack(Player player, Npc npc)
        {
            //npc.Stats.Health -= skill.Damage + player.Stats.Damage;
            return false;
        }

        public override bool Buff(Player player, Npc npc)
        {
            return false;
        }

        public Assassin()
        {
            SkillBook.Add(new Skill("Coin Flip", $"Flip a coin and decide if you want to actually attack. +{10 + Stats.Damage} damage, or -{10 + Stats.Damage} damage.", 15f, 0f, true, DateTime.Now));
            SkillBook.Add(new Skill("Cut Throat", "Slice someones ankles, cause why would you name the body part your about to attack?", 5f, 3f, true, DateTime.Now));
            SkillBook.Add(new Skill("Kyūketsuki", $"Take on your shadow form and steal +{3 + Stats.Damage} health from the enemy, healing yourself", 10f, 3f, true, DateTime.Now));
            SpellBook.Add(new Spell("Limit Break", $"Remove your earthly form and increase your speed by {2 + Stats.Damage}, can only be used once, and at great cost", "buff", 50f, 0f, false, DateTime.Now));
        }
    }
}
