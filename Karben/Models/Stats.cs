using System;
using System.Collections.Generic;
using System.Text;

namespace Karben
{
    class Stats
    {
        public float Health { get; set; }
        public float Mana { get; set; }
        public float Damage { get; set; }
        public float Speed { get; set; }
        public Stats(float health, float mana, float damage, float speed)
        {
            Health = health;
            Mana = mana;
            Damage = damage;
            Speed = speed;
        }
    }
}
