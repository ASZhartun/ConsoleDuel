using Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abilities
{
    class SummonAbility : Ability
    {
        public Creature Slave {  get; set; }

        public SummonAbility(string name, int cooldown, Creature slave) : base(name: name, cooldown: cooldown) { 
            Slave = slave;
        }

        public Creature Summon() { 
            return Slave;
        }

        public new void Info() { 
            base.Info();
            Console.WriteLine($"\rSummoning this: {Slave}\n");
        }

        public override void cast(Hero owner, Creature target)
        {
            if (Current_Cooldown == 0)
            {
                owner.Imps.Add(Slave);
                Current_Cooldown = Cooldown;
            }
        }
    }
}
