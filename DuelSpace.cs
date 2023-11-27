using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Creatures;
using Abilities;

namespace ConsoleDuel
{
    internal class DuelSpace
    {
        private static int steps = 0;
        public static void Main(string[] args)
        {
            Console.WriteLine("Let\'s see...");
            Console.WriteLine();
            Ability corruption = new Ability(name: "Corruption", damage: 200, heal: 200, cooldown: 10, durotation: 0);
            Ability ancientSpirit = new Ability(name: "AncientSpirit", heal: 500, cooldown: 10);
            Ability fear = new Ability(name: "Fear", cooldown: 60, durotation: 3, applyingState: States.STUNNED);
            SummonAbility summon = new SummonAbility(name: "SummonSkeleton", cooldown: 10, new Creature(name: "Skeleton", damage: 100, health: 300));

            Hero guldan = new Hero("Guldan", 30, 20, 150, 120);

            Hero nerzul = new Hero("Nerzul", 40, 50, 120, 160);

            guldan.AddAbility(corruption, fear);
            guldan.Info();
            Console.WriteLine();
            nerzul.AddAbility(ancientSpirit, summon);
            nerzul.Info();
            Console.WriteLine();
            Console.WriteLine("Fight!");
            while (true) {
                steps++;
                Console.WriteLine($"Step:{steps}");
                Console.WriteLine("\nStates of heroes BEFORE actions:");
                guldan.StateInfo();
                nerzul.StateInfo();
                Console.WriteLine();
                guldan.DoFullProcast(nerzul);
                nerzul.DoFullProcast(guldan);

                guldan.Attack(nerzul);
                nerzul.Attack(guldan);

                guldan.AttackByImps(nerzul);
                nerzul.AttackByImps(guldan);

                guldan.RefreshState();
                nerzul.RefreshState();
                Console.WriteLine("States of heroes AFTER actions:");
                guldan.StateInfo();
                nerzul.StateInfo();
                Console.WriteLine($"Step number {steps} is over...");
                Console.WriteLine();
                if (IsDead(guldan) || IsDead(nerzul)) break;
            }
            Console.WriteLine();
            guldan.StateInfo();
            nerzul.StateInfo();
        }

        private static bool IsDead(Hero hero) { 
            return hero.Current_Hp <= 0 ? true : false;
        }
    }
}
