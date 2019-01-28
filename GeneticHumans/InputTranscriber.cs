using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticHumans {
    public static class InputTranscriber {
        public static InputRoot TranscribeInput(string text) {
            InputRoot root = new InputRoot();

            if (string.IsNullOrEmpty(text))
                return root;

            string[] commands = text.Split(new string[] { " -" }, StringSplitOptions.RemoveEmptyEntries);

            root.command = commands[0];

            for (int i = 1; i < commands.Length; i++) {
                string[] subCommands = commands[i].Split(' ');

                InputNode node = new InputNode {
                    command = subCommands[0]
                };

                for (int j = 1; j < subCommands.Length; j++)
                    node.value += subCommands[j] + " ";

                node.value.TrimEnd(' ');

                root.nodes.Add(node);
            }

            return root;
        }
    }

    public class InputRoot {
        public string command;
        public List<InputNode> nodes;

        public bool isEmpty => string.IsNullOrEmpty(command);

        public InputRoot() => nodes = new List<InputNode>();
    }

    public class InputNode {
        public string command;
        public string value;

        public bool isEmpty => string.IsNullOrEmpty(command);
        public bool isValueless => string.IsNullOrEmpty(value);
    }
}
