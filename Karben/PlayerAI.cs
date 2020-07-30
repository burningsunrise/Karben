using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Karben.Models;

namespace Karben
{
    class PlayerAI
    {
        public PlayerAI(List<Player> players, Npc npc)
        {
            while (true)
            {
                foreach (var player in players)
                {
                    if (player.Stats.Speed <= player.SpeedCount)
                    {
                        bool yeet = player.Buff(player, npc);
                        if (!yeet)
                            player.Attack(player, npc);
                        player.SpeedCount = 0;
                    }
                    //Console.WriteLine($"{npc.Name} HP: {npc.Stats.Health}");
                    try
                    {
                        Console.WriteLine($"{player.Description.Name} HP: {player.Stats.Health} | Status {player.Status} | Time Until Turn: {player.Stats.Speed - player.SpeedCount}");
                    }
                    catch
                    {

                    }
                    Thread.Sleep(TimeSpan.FromSeconds(1f / 30f));
                    player.SpeedCount++;
                }
            }
        }
    }
}
