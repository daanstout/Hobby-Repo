using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticHumans {
    public class SettingsParser : IParser {
        public void Parse(string text, World world) {
            /*if (text[0] == 'm') {
                Console.WriteLine("Adjusting the mutation chance");

                string[] command = text.Split(' ');

                if (command.Length < 2) {
                    Console.WriteLine("Correct usage: \"m {new modifier}\"");
                    return;
                }

                world.modifier = (float)Convert.ToDouble(command[1]);
            } else*/ if (text[0] == 'd') {
                Console.WriteLine("Toggling the debug mode");

                string[] command = text.Split(' ');

                if (command.Length < 2) {
                    Console.WriteLine("Correct usage: \"d {true or false}\"");
                    return;
                }

                try {
                    world.debug = Convert.ToBoolean(command[1]);
                    Console.WriteLine($"Set debug mode to {world.debug}");
                } catch {
                    Console.WriteLine("Correct usage: \"d {true or false}\"");
                    return;
                }
            } else if (text[0] == 'm') {
                Console.WriteLine("Adjusting mutation chance");

                string[] commands = text.Split(' ');

                if(commands.Length < 1) {
                    Console.WriteLine("Correct usage: \"m {new mutation chance -> float}\"");
                    return;
                }

                world.mutationChance = (float)Convert.ToDouble(commands[1]);
            } else if (text[0] == 'b') {
                Program.parser = new BaseParser();
                return;
            } else if ((text.Length >= 4 && text.Substring(0, 4).Equals("list")) || (text.Length >= 8 && text.Substring(0, 8).Equals("commands"))) {
                Console.WriteLine("Mutation Chance: 'm' {mutation chance -> float (uses commas)}\n" +
                    "Debug mode: 'd' {true or false -> string}\n" +
                    "Back: 'b'" +
                    "List: \"commands\" or \"list\"");
            }
        }
    }
}
