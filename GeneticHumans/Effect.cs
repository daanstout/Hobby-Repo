using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticHumans {
    public abstract class Effect {
        private static List<Effect> effects = new List<Effect> {
            new Strength1(),
            new Strength2(),
            new Strength3(),
            new StrengthN1(),
            new StrengthN2(),
            new StrengthN3(),

            new Intelligence1(),
            new Intelligence2(),
            new Intelligence3(),
            new IntelligenceN1(),
            new IntelligenceN2(),
            new IntelligenceN3(),

            new Constitution1(),
            new Constitution2(),
            new Constitution3(),
            new ConstitutionN1(),
            new ConstitutionN2(),
            new ConstitutionN3()
        };

        private static Random rand = new Random();

        public static Effect GetRandomEffect() => effects[rand.Next(0, effects.Count)];


        public abstract void Activate(Human human);
    }

    public class Strength1 : Effect { public override void Activate(Human human) => human.strength += 1; }
    public class Strength2 : Effect { public override void Activate(Human human) => human.strength += 2; }
    public class Strength3 : Effect { public override void Activate(Human human) => human.strength += 3; }
    public class StrengthN1 : Effect { public override void Activate(Human human) => human.strength -= 1; }
    public class StrengthN2 : Effect { public override void Activate(Human human) => human.strength -= 2; }
    public class StrengthN3 : Effect { public override void Activate(Human human) => human.strength -= 2; }

    public class Intelligence1 : Effect { public override void Activate(Human human) => human.intelligence += 1; }
    public class Intelligence2 : Effect { public override void Activate(Human human) => human.intelligence += 2; }
    public class Intelligence3 : Effect { public override void Activate(Human human) => human.intelligence += 3; }
    public class IntelligenceN1 : Effect { public override void Activate(Human human) => human.intelligence -= 1; }
    public class IntelligenceN2 : Effect { public override void Activate(Human human) => human.intelligence -= 2; }
    public class IntelligenceN3 : Effect { public override void Activate(Human human) => human.intelligence -= 2; }

    public class Constitution1 : Effect { public override void Activate(Human human) => human.constitution += 1; }
    public class Constitution2 : Effect { public override void Activate(Human human) => human.constitution += 2; }
    public class Constitution3 : Effect { public override void Activate(Human human) => human.constitution += 3; }
    public class ConstitutionN1 : Effect { public override void Activate(Human human) => human.constitution -= 1; }
    public class ConstitutionN2 : Effect { public override void Activate(Human human) => human.constitution -= 2; }
    public class ConstitutionN3 : Effect { public override void Activate(Human human) => human.constitution -= 2; }
}
