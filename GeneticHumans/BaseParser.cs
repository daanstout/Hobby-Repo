using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticHumans {
    public class BaseParser : IParser {
        public void Parse(string text, World world) {
            if (string.IsNullOrEmpty(text)) {
                Console.WriteLine("Please type a command - or \"list\" for a list of commands");
                return;
            } else if (text[0] == 'q') {
                Console.WriteLine("Ending simulation");
                return;
            } else if (text[0] == 'r') {
                Console.WriteLine("Reproducing the current population");

                string[] command = text.Split(' ');

                if (command.Length == 2)
                    if (!string.IsNullOrEmpty(command[1]))
                        for (int i = 0; i < Math.Abs(Convert.ToInt32(command[1])); i++)
                            world.NextGeneration();
                    else
                        world.NextGeneration();
                else
                    world.NextGeneration();
            } else if (text[0] == 'p') {
                Console.WriteLine("Creating a new population");

                string[] command = text.Split(' ');

                if (command.Length < 6) {
                    Console.WriteLine("Correct usage: \"p {strength} {intelligence} {constitution] {gene count} {population}\"");
                    return;
                }

                world.Populate(Convert.ToInt32(command[1]),
                    Convert.ToInt32(command[2]),
                    Convert.ToInt32(command[3]),
                    Convert.ToInt32(command[4]),
                    Convert.ToInt32(command[5]));
            } else if (text[0] == 'o') {
                //world.Print();
                world.Sort();
                world.PrintCompare();
            } else if (text[0] == 's') {
                Program.parser = new SettingsParser();
                return;
            } else if ((text.Length >= 4 && text.Substring(0, 4).Equals("list")) || (text.Length >= 8 && text.Substring(0, 8).Equals("commands"))) {
                Console.WriteLine("Quit: 'q'\n" +
                    "Reproduce: 'r' - {generations -> int | optional}\n" +
                    "Populate: 'p' - {strength -> int} - {intelligence -> int} - {constitution -> int} - {gene count -> int} - {population -> int}\n" +
                    "Out: 'o'\n" +
                    "Settings: 's'" +
                    "List: \"commands\" or \"list\"");
            }
        }
    }
}
