using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticHumans {
    class Program {
        static void Main(string[] args) {
            Colony colony = new Colony();

            while (true) {
                string line = Console.ReadLine();

                if (string.IsNullOrEmpty(line))
                    continue;
                else if (line[0] == 'q')
                    break;
                else if (line[0] == 'r') {
                    string[] command = line.Split(' ');
                    if (command.Length == 2)
                        for (int i = 0; i < Math.Abs(Convert.ToInt32(command[1])); i++)
                            colony.NextGeneration();
                    else
                        colony.NextGeneration();
                } else if (line[0] == 'p') {
                    string[] command = line.Split(' ');

                    if (command.Length < 6) {
                        Console.WriteLine("Correct usage: \"p {strength} {intelligence} {constitution] {gene count} {population}\"");
                        continue;
                    }

                    colony.Populate(Convert.ToInt32(command[1]),
                        Convert.ToInt32(command[2]),
                        Convert.ToInt32(command[3]),
                        Convert.ToInt32(command[4]),
                        Convert.ToInt32(command[5]));
                } else if (line[0] == 'o')
                    colony.Print();
                else if (line[0] == 'm') {
                    string[] command = line.Split(' ');

                    if (command.Length < 2) {
                        Console.WriteLine("Correct usage: \"m {new modifier}\"");
                        continue;
                    }

                    colony.modifier = (float)Convert.ToDouble(command[1]);
                } else if (line.Substring(0, 4).Equals("list") || line.Substring(0, 8).Equals("commands")) {
                    Console.WriteLine("Quit: 'q'\n" +
                        "Reproduce: 'r' - {generations -> int | optional}\n" +
                        "Populate: 'p' - {strength -> int} - {intelligence -> int} - {constitution -> int} - {gene count -> int} - {population -> int}\n" +
                        "Out: 'o'\n" +
                        "Modifier: 'm' {modifier -> float (uses commas)}\n" +
                        "List: \"commands\" or \"list\"");
                }
            }
        }
    }
}
