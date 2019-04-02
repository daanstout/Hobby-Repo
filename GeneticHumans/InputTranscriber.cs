using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticHumans {
    /// <summary>
    /// Transcribes user input into commands
    /// </summary>
    public static class InputTranscriber {
        /// <summary>
        /// Transcribes a line of text into commands
        /// </summary>
        /// <param name="text">The input text</param>
        /// <returns>The root of the input</returns>
        public static InputRoot TranscribeInput(string text) {
            // Create the root
            InputRoot root = new InputRoot();

            // If the input text is null/empty, just return the root empty as is
            if (string.IsNullOrEmpty(text))
                return root;

            // Make sure the text is completely lower case
            text = text.ToLower();

            // Split the command options by the subcommand token
            string[] commands = text.Split(new string[] { " -" }, StringSplitOptions.RemoveEmptyEntries);

            // The root command is the first index, the sub commands are the others
            root.command = commands[0];

            // For every sub command, add it to the node list
            for (int i = 1; i < commands.Length; i++) {
                // Split it by spaces
                string[] subCommands = commands[i].Split(' ');

                // We check whether this command is already present
                {
                    bool quit = false;

                    // If the command is present, we need to skip it
                    foreach (InputNode n in root.nodes)
                        if (n.command.Equals(subCommands[0]))
                            quit = true;

                    if (quit)
                        continue;
                }

                // Create the node and set the first subcommand as the node command
                InputNode node = new InputNode {
                    command = subCommands[0]
                };

                // All the other indeces add up to the value
                for (int j = 1; j < subCommands.Length; j++)
                    node.value += subCommands[j] + " ";

                // Trim the trailing space
                node.value.TrimEnd(' ');

                // Add the node to the root
                root.nodes.Add(node);
            }

            // Return the root
            return root;
        }
    }

    /// <summary>
    /// The root command of the text
    /// </summary>
    public class InputRoot {
        /// <summary>
        /// The command
        /// </summary>
        public string command;
        /// <summary>
        /// A list of sub commands
        /// </summary>
        public List<InputNode> nodes;

        /// <summary>
        /// Indicates whether the command string is empty
        /// </summary>
        public bool isEmpty => string.IsNullOrEmpty(command);

        /// <summary>
        /// Instantiates a new input root
        /// </summary>
        public InputRoot() => nodes = new List<InputNode>();
    }

    /// <summary>
    /// An input node with a value
    /// </summary>
    public class InputNode {
        /// <summary>
        /// The command of the node
        /// </summary>
        public string command;
        /// <summary>
        /// The value of the node
        /// </summary>
        public string value;

        /// <summary>
        /// Indicates whether the command string is empty
        /// </summary>
        public bool isEmpty => string.IsNullOrEmpty(command);
        /// <summary>
        /// Indicates whether the value string is empty
        /// </summary>
        public bool isValueless => string.IsNullOrEmpty(value);
    }
}
