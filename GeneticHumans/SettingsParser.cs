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
            } else*/
            string[] commands = text.Split(new string[] { " -" }, StringSplitOptions.RemoveEmptyEntries);

            if (commands[0].Equals("debug")) {
                if (commands.Length <= 1) {
                    Console.WriteLine("Please specify what to set debug mode to with \"-toggle\" to perform a toggle or \"-set X\" to set it to a specific value");
                    return;
                }

                if (commands[1].Length >= 3 && commands[1].Substring(0, 3).Equals("set")) {
                    try {
                        world.debug = Convert.ToBoolean(commands[1].Substring(4));
                        Console.WriteLine($"Set debug to {world.debug}");
                    } catch {
                        Console.WriteLine("Correct usage: \"debug -set X\" or \"debug -toggle\"");
                    }
                    return;
                }

                if (commands[1].Length >= 6 && commands[1].Substring(0, 6).Equals("toggle")) {
                    world.debug = !world.debug;
                    Console.WriteLine($"Toggled debug to {world.debug}");
                    return;
                }
            }

            if (commands[0].Equals("mutation")) {
                if (commands.Length <= 1) {
                    Console.WriteLine("Please specify what to set the mutation chance to with \"-set X\"");
                    return;
                }

                if (commands[1].Length >= 3 && commands[1].Substring(0, 3).Equals("set")) {
                    try {
                        world.mutationChance = (float)Convert.ToDouble(commands[1].Substring(4));
                        Console.WriteLine($"Set the mutation chance to {world.mutationChance}");
                    } catch {
                        Console.WriteLine("Please use a valid float value");
                    }
                }

                return;
            }

            if (commands[0].Equals("back")) {
                Program.parser = new BaseParser();
                return;
            }

            if (commands[0].Equals("list") || commands[0].Equals("command") || commands[0].Equals("commands") || commands[0].Equals("help")) {
                Console.WriteLine($"Settings:\n" +
                    $"Debug mode:\t\t\t\"debug -toggle\" or \"debug -set X\"\n" +
                    $"Mutation chance:\t\t\"mutation -set X\"\n" +
                    $"Back:\t\t\t\t\"back\"");
            }
        }
    }
}
