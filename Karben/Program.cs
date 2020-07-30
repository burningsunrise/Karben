using System;
using System.Collections.Generic;
using System.Threading;
using Karben.Cards;
using Karben.Enemies;
using Karben.Models;

namespace Karben
{
    class Program
    {
        static void Main(string[] args)
        {
            //TelegramMaster insomnia = new TelegramMaster();
            //ProceduralDungeon pd = new ProceduralDungeon();
            Shaman shaman = new Shaman();
            Assassin ass = new Assassin();
            Npc goblin = new Goblin();
            Npc goblin2 = new Goblin();
            List<Player> players = new List<Player>() { shaman, ass };
            List<Npc> npcs = new List<Npc>() { goblin, goblin2 };
            PlayerAI bs = new PlayerAI(players, goblin);
        }
    }
}
