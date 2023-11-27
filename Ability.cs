using Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abilities
{
    class Ability
    {
        public double Damage { get; set; }
        public double Heal { get; set; }
        public int Durotation { get; set; }
        public int Cooldown { get; set; }

        public int Current_Cooldown { get; set; }
        public string Name { get; set; }

        public States ApplyingState { get; set; }

        public Ability(string name, double damage = 0, double heal = 0, int durotation = 0, int cooldown = 0, States applyingState = States.ACTIVE)
        {
            Damage = damage;
            Heal = heal;
            Durotation = durotation;
            Cooldown = cooldown;
            Name = name;
            Current_Cooldown = 0;
            ApplyingState = applyingState;
        }

        public void Info() {
            Console.WriteLine($"Ability \"{Name}\": damage = {Damage}, Heal = {Heal}, durotation = {Durotation}, cooldown = {Cooldown}\n");
        }

        public override string ToString()
        {
            return $"Ability \"{Name}\": [damage = {Damage}, Heal = {Heal}, durotation = {Durotation}, cooldown = {Cooldown}]";
        }

        public void InfoState() {
            Console.WriteLine($"Ability \"{Name}\": cooldown = {Current_Cooldown}\n");
        }

        public virtual void cast(Hero owner, Creature target) {
            if (Current_Cooldown == 0)
            {
                owner.Current_Hp += Heal;
                if (owner.Current_Hp > owner.Hp) owner.Current_Hp = owner.Hp;
                target.Current_Hp -= Damage;
                target.Current_State = ApplyingState;
                target.State_Count = Durotation;
                Console.WriteLine($"Casting {Name} by {owner.Name}");
            }
            Current_Cooldown = Cooldown;
        }

        public void Reset_Cooldown() {
            if (Current_Cooldown > 0)
            {
                Current_Cooldown--;
            }
        }
    }

    enum States { 
        ACTIVE, 
        STUNNED,
    }
}
