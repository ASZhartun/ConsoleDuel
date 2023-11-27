using Abilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creatures
{
    class Hero : Creature
    {
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Intellect { get; set; }
        public int Stamina { get; set; }

        public double Crit { get; set; }

        public List<Ability> Abilities { get; set; }
        public List<Creature> Imps { get; set; }

        public Hero(double health, double dps, string name) : base(health, dps, name) { 
            Abilities = new List<Ability>();
            Imps = new List<Creature>();
        }

        public Hero(string name, int str, int agi, int inta, int sta) : base(name) {
            Strength = str;
            Agility = agi;
            Intellect = inta;
            Stamina = sta;
            Abilities = new List<Ability>();
            Imps = new List<Creature>();
            RefreshStats();
        }

        private void RefreshStats()
        {
            Dps = Strength * 1.5 + Agility * 1 + Intellect * 1;
            Hp = Current_Hp = Stamina * 10 + Strength * 2;
            Crit = Agility * 0.002 + Intellect * 0.0005;
        }

        public new void Info() {
            Console.WriteLine($"Hero \"{Name}\":\thealth = {Hp}, dps = {Dps} \nStats:  str = {Strength}, agi = {Agility}, inta = {Intellect}, sta = {Stamina} with crit_chance = {Math.Round((Crit * 100), 0)}%");
            Console.WriteLine($"Abils:\t{GetAbilityInfo()}");
        }

        public void AddAbility(Ability ability) { 
            Abilities.Add( ability );
        }

        public void AddAbility(Ability ability, params Ability[] adds)
        {
            Abilities.Add(ability);
            Abilities.AddRange(adds);
        }

        public string GetAbilityInfo() {
            StringBuilder sb = new StringBuilder();
            foreach (Ability ability in Abilities)
            {
                sb.Append(ability.ToString());
                sb.Append(";\n\t");
            }
            
            return sb.ToString()[..^2];
        }

        

        public void AttackByImps(Creature target)
        {
            foreach (Creature imp in Imps)
            {
                target.Current_Hp -= imp.Dps;
            }
        }

        public void DoFullProcast(Creature target) {
            foreach (Ability ability in Abilities) {
                if (ability.Current_Cooldown == 0)
                {
                    ability.cast(this, target);
                }
                else {
                    ability.Reset_Cooldown();
                }
            }
        }

        public void Attack(Creature target)
        {
            if (Current_State == States.ACTIVE)
            {
                target.Current_Hp -= Math.Round(Dps+Dps*Crit, 0);
            }
        }
    }
}
