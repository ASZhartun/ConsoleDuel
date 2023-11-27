using Abilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creatures
{
    class Creature
    {
        public double Dps { get; set; }
        public double Hp { get; set; }

        public double Current_Hp {  get; set; }

        public States Current_State { get; set; }
        public int State_Count { get; set; }

        public string Name { get; set; }

        public Creature(double health, double damage, string name)
        {
            Hp = health;
            Current_Hp = health;
            Dps = damage;
            Name = name;
            State_Count = 0;
            Current_State = States.ACTIVE;
        }

        public Creature(string name)
        {
            Hp = 10;
            Dps = 0;
            Name = name;
        }

        public Creature() {
            Hp = 10;
            Dps = 0;
            Name = "Dummy";
        }

        public void Info() {
            Console.WriteLine($"Creature \"{Name}\": health = {Hp}, dps = {Dps}");
        }

        public override string ToString() {
            return $"Creature: name = {Name}, damage = {Dps}, health = {Hp}";
        }

        public void StateInfo() {
            Console.WriteLine($"Creature \"{Name}\": {Current_Hp}/{Hp} DPS:{Dps}");
        }

        public void RefreshState() {
            if (State_Count > 0 && Current_State == States.STUNNED)
            {
                State_Count--;
            }
            else {
                State_Count = 0;
                Current_State = States.ACTIVE;
            }
        }

        public void Attack(Creature target)
        {
            if (Current_State == States.ACTIVE)
            {
                target.Current_Hp -= Dps;
            }
        }
    }
}
