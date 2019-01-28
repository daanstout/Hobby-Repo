using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticHumans {
    public class BaseParser : IParser {
        public void Parse(string text, World world) {
            if (string.IsNullOrEmpty(text)) {
                Console.WriteLine("Please type a command - Or \"list\" for a list of commands");
                return;
            }

            text = text.ToLower();

            string[] commands = text.Split(new string[] { " -" }, StringSplitOptions.RemoveEmptyEntries);

            if (commands[0].Equals("quit")) {
                Console.WriteLine("Ending the simulation");
                return;
            }

            if (commands[0].Equals("reproduce")) {
                Console.WriteLine("Reproducing the current population");

                if (commands.Length > 1)
                    if (commands[1].Count() > 3 && commands[1].Substring(0, 3).Equals("rep")) {
                        try {
                            int gens = Math.Abs(Convert.ToInt32(commands[1].Substring(4)));
                            for (int i = 0; i < gens; i++)
                                world.NextGeneration();
                        } catch {
                            Console.WriteLine("Please write a valid reproduce commant, use \" -rep X\" to reproduce X times");
                        }
                    } else
                        Console.WriteLine("Please write a valid reproduce commant, use \" -rep X\" to reproduce X times");
                else
                    world.NextGeneration();

                return;
            }

            if (commands[0].Equals("populate")) {
                Console.WriteLine("Creating a new population");

                int strength = 10;
                int intelligence = 10;
                int constitution = 10;
                int geneCount = 20;
                int populationSize = 50;

                for (int i = 1; i < commands.Length; i++) {
                    string com = commands[i];

                    if (com.Count() > 3 && com.Substring(0, 3).Equals("str")) {
                        try {
                            strength = Math.Abs(Convert.ToInt32(com.Substring(4)));
                        } catch {
                            Console.WriteLine("Please write a valid strength amount. The default value (10) will be used");
                        }
                    }

                    if (com.Count() > 3 && com.Substring(0, 3).Equals("int")) {
                        try {
                            intelligence = Math.Abs(Convert.ToInt32(com.Substring(4)));
                        } catch {
                            Console.WriteLine("Please write a valid intelligence amount. The default value (10) will be used");
                        }
                    }

                    if (com.Count() > 3 && com.Substring(0, 3).Equals("con")) {
                        try {
                            constitution = Math.Abs(Convert.ToInt32(com.Substring(4)));
                        } catch {
                            Console.WriteLine("Please write a valid constitution amount. The default value (10) will be used");
                        }
                    }

                    if (com.Count() > 1 && com.Substring(0, 2).Equals("gc")) {
                        try {
                            geneCount = Math.Abs(Convert.ToInt32(com.Substring(3)));
                        } catch {
                            Console.WriteLine("Please write a valid gene count. The default value (20) will be used");
                        }
                    }

                    if (com.Count() > 3 && com.Substring(0, 3).Equals("pop")) {
                        try {
                            populationSize = Math.Abs(Convert.ToInt32(com.Substring(4)));
                        } catch {
                            Console.WriteLine("Please write a valid population size. The default value (50) will be used");
                        }
                    }
                }

                world.Populate(strength, intelligence, constitution, geneCount, populationSize);

                return;
            }

            if (commands[0].Equals("show") || commands[0].Equals("print") || commands[0].Equals("out")) {
                world.Sort();
                world.PrintCompare();

                return;
            }

            if (commands[0].Equals("list") || commands[0].Equals("command") || commands[0].Equals("commands") || commands[0].Equals("help")) {
                Console.WriteLine($"\nList of commands:\n" +
                    $"All variables are optional\n" +
                    $"Quit: \t\t\t\t\"quit\"\n" +
                    $"Reproduce population: \t\t\"reproduce -rep X\"\n" +
                    $"Create population: \t\t\"populate -str X -int X -con X -gc X -pop X\"\n" +
                    $"Print the population: \t\t\"out\" or \"print\" or \"show\"\n");

                return;
            }

            if (commands[0].Equals("settings")) {
                Console.WriteLine("Switching to settings");
                Program.parser = new SettingsParser();
                return;
            }

            Console.WriteLine("Please write a valid command, or \"help\" for a list of valid commands");
        }
    }
}
