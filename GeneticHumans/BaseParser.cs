using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticHumans {
    /// <summary>
    /// The base parser that handles creating and managing a colony
    /// </summary>
    public class BaseParser : IParser {
        /// <summary>
        /// A warning for when the user send an empty string
        /// </summary>
        private const string EMPTY_COMMAND_STRING = "Please type a command - Or \"list\" for a list of commands";
        /// <summary>
        /// The command to quit the program
        /// </summary>
        private const string QUIT_COMMAND = "quit";
        /// <summary>
        /// The command to reproduce the colony
        /// </summary>
        private const string REPRODUCE_COMMAND = "reproduce";
        /// <summary>
        /// The command to indicate how many times the colony reproduces
        /// </summary>
        private const string REPRODUCE_COMMAND_COUNT = "rep";
        /// <summary>
        /// The message for when the user sends an invalid reproduce command
        /// </summary>
        private const string REPRODUCE_COMMAND_INVALID = "Please write a valid reproduce commant, use \" -rep X\" to reproduce X times";
        /// <summary>
        /// The command to create a new population
        /// </summary>
        private const string POPULATE_COMMAND = "populate";
        /// <summary>
        /// The command to set the base strength of a person
        /// </summary>
        private const string POPULATE_COMMAND_STRENGTH = "str";
        /// <summary>
        /// The message for when the user sends an invalid strength amount
        /// </summary>
        private const string POPULATE_COMMAND_STRENGTH_INVALID = "Please write a valid strength amount. The default value (10) will be used";
        /// <summary>
        /// The command to set the base intelligence of a person
        /// </summary>
        private const string POPULATE_COMMAND_INTELLIGENCE = "int";
        /// <summary>
        /// The message for when the user sends an invalid intelligence amount
        /// </summary>
        private const string POPULATE_COMMAND_INTELLIGENCE_INVALID = "Please write a valid intelligence amount. The default value (10) will be used";
        /// <summary>
        /// The command to set the base constitution for a person
        /// </summary>
        private const string POPULATE_COMMAND_CONSTITUTION = "con";
        /// <summary>
        /// The message for when the user sends an invalid constitution amount
        /// </summary>
        private const string POPULATE_COMMAND_CONSTITUTION_INVALID = "Please write a valid constitution amount. The default value (10) will be used";
        /// <summary>
        /// The command to set the gene count of a person
        /// </summary>
        private const string POPULATE_COMMAND_GENE_COUNT = "gc";
        /// <summary>
        /// The message for when a user sends an invalid gene count
        /// </summary>
        private const string POPULATE_COMMAND_GENE_COUND_INVALID = "Please write a valid gene count. The default value (20) will be used";
        /// <summary>
        /// The command to set the population size
        /// </summary>
        private const string POPULATE_COMMAND_POPULATION_SIZE = "pop";
        /// <summary>
        /// The message for when the user sends an invalid population size
        /// </summary>
        private const string POPULATE_COMMAND_POPULATION_SIZE_INVALID = "Please write a valid population size. The default value (50) will be used";
        /// <summary>
        /// One of the commands to print the population (others are print and out)
        /// </summary>
        private const string POPULATION_SHOW = "show";
        /// <summary>
        /// One of the commands to print the population (others are show and out)
        /// </summary>
        private const string POPULATION_PRINT = "print";
        /// <summary>
        /// One of the commands to print the population (others are show and print)
        /// </summary>
        private const string POPULATION_OUT = "out";
        /// <summary>
        /// One of the commands to show a list of commands (others are command, commands, and help)
        /// </summary>
        private const string LIST = "list";
        /// <summary>
        /// One of the commands to show a list of commands (others are list, commands, and help)
        /// </summary>
        private const string COMMAND = "command";
        /// <summary>
        /// One of the commands to show a list of commands (others are list, command, and help)
        /// </summary>
        private const string COMMANDS = "commands";
        /// <summary>
        /// One of the commands to show a list of commands (others are list, command, and command)
        /// </summary>
        private const string HELP = "help";
        /// <summary>
        /// The list of commands
        /// </summary>
        private const string COMMANDLIST = "\nList of commands:\n" +
                    "All variables are optional\n" +
                    "Quit: \t\t\t\t\"quit\"\n" +
                    "Reproduce population: \t\t\"reproduce -rep X\"\n" +
                    "Create population: \t\t\"populate -str X -int X -con X -gc X -pop X\"\n" +
                    "Print the population: \t\t\"out\" or \"print\" or \"show\"\n";
        /// <summary>
        /// The command to switch to the settings
        /// </summary>
        private const string SETTINGS = "settings";
        /// <summary>
        /// The message for when the user is quiting the program
        /// </summary>
        private const string ENDING_SIMULATION = "Ending the simulation";
        /// <summary>
        /// The message for when the user is reproducing the population
        /// </summary>
        private const string REPRODUCE_POPULATION = "Reproducing the current population";
        /// <summary>
        /// The message for when the user is creating a new population
        /// </summary>
        private const string POPULATE_POPULATION = "Creating a new population";
        /// <summary>
        /// The message for when the user is switching to the settings
        /// </summary>
        private const string SWITCHING_SETTINGS = "Switching to settings";
        /// <summary>
        /// The message for when the user did not enter a valid command, but also did send something
        /// </summary>
        private const string INVALID_COMMANDS = "Please write a valid command, or \"help\" for a list of valid commands";

        /// <summary>
        /// The default strenght of a person
        /// </summary>
        private const int DEFAULT_STRENGTH = 10;
        /// <summary>
        /// The default intelligence of a person
        /// </summary>
        private const int DEFAULT_INTELLIGENCE = 10;
        /// <summary>
        /// The default constitution of a person
        /// </summary>
        private const int DEFAULT_CONSTITUTION = 10;
        /// <summary>
        /// The default gene count of a person
        /// </summary>
        private const int DEFAULT_GENE_COUNT = 20;
        /// <summary>
        /// The default population size
        /// </summary>
        private const int DEFAULT_POPULATION_SIZE = 50;

        /*
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

                if (commands.Length <= 0) {
                    world.NextGeneration();
                    return;
                }

                //if(commands[0].Count() <= 3)

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
        */

        /// <summary>
        /// Parses the input commands and applies the effects to the world
        /// </summary>
        /// <param name="input">The input commands</param>
        /// <param name="world">The world</param>
        public void Parse(InputRoot input, World world) {
            if (input.isEmpty) {
                Console.WriteLine(EMPTY_COMMAND_STRING);
                return;
            } // If input.isEmpty

            if (input.command.Equals(QUIT_COMMAND)) {
                Console.WriteLine(ENDING_SIMULATION);
                return;
            } // if input.command.Equals(QUIT_COMMAND)

            if (input.command.Equals(REPRODUCE_COMMAND)) {
                Console.WriteLine(REPRODUCE_POPULATION);

                if (input.nodes.Count == 0) {
                    world.NextGeneration();
                    return;
                } // if input.nodes.Count == 0

                foreach (InputNode node in input.nodes) {
                    if (node.isValueless || node.isEmpty)
                        continue;

                    if (node.command.Equals(REPRODUCE_COMMAND_COUNT)) {
                        try {
                            int gens = Math.Abs(Convert.ToInt32(node.value));
                            for (int i = 0; i < gens; i++)
                                world.NextGeneration();
                        } catch { // try
                            Console.WriteLine(REPRODUCE_COMMAND_INVALID);
                        } // catch
                    } // if node.command.Equals(REPRODUCE_COMMAND_COUNT)
                } // foreach InputNode in input.nodes

                return;
            } // if input.command.Equals(REPRODUCE_COMMAND)

            if (input.command.Equals(POPULATE_COMMAND)) {
                Console.WriteLine(POPULATE_POPULATION);

                int strength = DEFAULT_STRENGTH;
                int intelligence = DEFAULT_INTELLIGENCE;
                int constitution = DEFAULT_CONSTITUTION;
                int geneCount = DEFAULT_GENE_COUNT;
                int populationSize = DEFAULT_POPULATION_SIZE;

                foreach (InputNode node in input.nodes) {
                    if (node.isEmpty || node.isValueless)
                        continue;

                    if (node.command.Equals(POPULATE_COMMAND_STRENGTH)) {
                        try {
                            strength = Math.Abs(Convert.ToInt32(node.value));
                        } catch {
                            Console.WriteLine(POPULATE_COMMAND_STRENGTH_INVALID);
                        }
                    }

                    if (node.command.Equals(POPULATE_COMMAND_INTELLIGENCE)) {
                        try {
                            intelligence = Math.Abs(Convert.ToInt32(node.value));
                        } catch {
                            Console.WriteLine(POPULATE_COMMAND_INTELLIGENCE_INVALID);
                        }
                    }

                    if (node.command.Equals(POPULATE_COMMAND_CONSTITUTION)) {
                        try {
                            constitution = Math.Abs(Convert.ToInt32(node.value));
                        } catch {
                            Console.WriteLine(POPULATE_COMMAND_CONSTITUTION_INVALID);
                        }
                    }

                    if (node.command.Equals(POPULATE_COMMAND_GENE_COUNT)) {
                        try {
                            geneCount = Math.Abs(Convert.ToInt32(node.value));
                        } catch {
                            Console.WriteLine(POPULATE_COMMAND_GENE_COUND_INVALID);
                        }
                    }

                    if (node.command.Equals(POPULATE_COMMAND_POPULATION_SIZE)) {
                        try {
                            populationSize = Math.Abs(Convert.ToInt32(node.value));
                        } catch {
                            Console.WriteLine(POPULATE_COMMAND_POPULATION_SIZE_INVALID);
                        }
                    }
                }

                world.Populate(strength, intelligence, constitution, geneCount, populationSize);

                return;
            }

            if(input.command.Equals(POPULATION_OUT) || input.command.Equals(POPULATION_PRINT) || input.command.Equals(POPULATION_SHOW)) {
                world.Sort();
                world.PrintCompare();

                return;
            }

            if (input.command.Equals(HELP) || input.command.Equals(COMMAND) || input.command.Equals(COMMANDS) || input.command.Equals(LIST)) {
                Console.WriteLine(COMMANDLIST);

                return;
            }

            if (input.command.Equals(SETTINGS)) {
                Console.WriteLine(SWITCHING_SETTINGS);

                Program.parser = new SettingsParser();

                return;
            }

            Console.WriteLine(INVALID_COMMANDS);
        }
    }
}
