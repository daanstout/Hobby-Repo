using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualBrainFuckInterpreter {
    /// <summary>
    /// A BrainFuck Interpreter
    /// </summary>
    class Interpreter {
        /// <summary>
        /// The program we are currently operating
        /// </summary>
        public string program { get; private set;}
        /// <summary>
        /// The current instruction we are doing
        /// </summary>
        public int instructionPointer { get; private set; }
        /// <summary>
        /// The number of cells in this program
        /// </summary>
        public int numCells { get; private set; }
        /// <summary>
        /// The bytes in each cell
        /// </summary>
        byte[] cells;
        /// <summary>
        /// The current cell we are talking to
        /// </summary>
        public int dataPointer { get; private set; }

        public bool incrementalSteps { get; set; }

        private TaskCompletionSource<bool> step = new TaskCompletionSource<bool>();

        public bool doStep {
            set => step.SetResult(value);
        }

        /// <summary>
        /// The base number of cells
        /// </summary>
        const int baseNumCells = 30000;

        /// <summary>
        /// The maximum number of instructions we execute before leaving, to prevent infinite loops
        /// </summary>
        const int maximumInstructions = 1000000;

        /// <summary>
        /// The maximum checks we make while checking loops, to prevent infinite loops
        /// </summary>
        const int loopsChecked = 1000000;

        /// <summary>
        /// Instantiates a new Interpreter with basic settings
        /// </summary>
        public Interpreter() {
            numCells = baseNumCells;

            Reset();
        }

        /// <summary>
        /// Instantiates a new Interpreter with a specifif number of cells
        /// </summary>
        /// <param name="numCells">The number of cells in this interpreter</param>
        public Interpreter(int numCells) {
            this.numCells = numCells;

            Reset();
        }

        /// <summary>
        /// Instantiates a new Interpreter with a program
        /// </summary>
        /// <param name="program">The program to execute</param>
        public Interpreter(string program) {
            numCells = baseNumCells;
            this.program = program;

            Reset();
        }

        /// <summary>
        /// Instantiates a new Interpreter with a specific number of cells and a program to execute
        /// </summary>
        /// <param name="numCells">The number of cells in this interpreter</param>
        /// <param name="program">The program to execute</param>
        public Interpreter(int numCells, string program) {
            this.numCells = numCells;
            this.program = program;

            Reset();
        }

        public void LoadNewProgram(string program) {
            Reset(true);

            this.program = program;
        }

        public byte[] GetCellData() => cells.Clone() as byte[];

        /// <summary>
        /// Resets the interpreter
        /// </summary>
        private void Reset(bool resetProgram = false) {
            instructionPointer = 0;
            cells = new byte[numCells];
            if (resetProgram)
                program = "";
            dataPointer = 0;
        }

        /// <summary>
        /// Executes the currently loaded program
        /// </summary>
        public async void Execute() {
            // If there is no program, there is nothing to execute. Return
            if (string.IsNullOrEmpty(program))
                return;

            // Keep track of the number of instructions we have executed
            int instructionsRan = 0;

            // While we have not gotten to the end of the program, we loop over it
            while (instructionPointer < program.Length && instructionsRan < maximumInstructions) {
                // If we want to do incremental steps as a set interval or when the user wants to, we wait until the doStep flag is true
                if (incrementalSteps)
                    await step.Task;

                // Get the current instruction
                char instruction = program[instructionPointer];

                // Switch through the commands
                // If the instruction is not part of this, it gets ignored
                switch (instruction) {
                    // This increases the data pointer 1 step forward, going to the next cell
                    case '>':
                        dataPointer++;
                        // Make sure we do not go over the maximum number of cells
                        if (dataPointer >= numCells)
                            dataPointer = numCells - 1;
                        break;
                    // This decreases the data pointer 1 step backwards, going to the previous cell
                    case '<':
                        dataPointer--;
                        // Make sure we do not go below 0
                        if (dataPointer < 0)
                            dataPointer = 0;
                        break;
                    // This increases the data in the current cell
                    case '+':
                        cells[dataPointer]++;
                        break;
                    // This decreases the data in the current cell
                    case '-':
                        cells[dataPointer]--;
                        break;
                    // This outputs the current data to the console
                    case '.':
                        Console.Write((char)cells[dataPointer]);
                        break;
                    // This reads in a byte of data from the console
                    case ',':
                        cells[dataPointer] = (byte)Console.Read();
                        break;
                    // If the current data is equal to 0, we skip this place, else, we execute it as normal
                    case '[':
                        if (cells[dataPointer] == 0)
                            instructionPointer = SkipToNextEnd();
                        break;
                    // If the current data is not equal to 0, we go back to the opening of this loop, else, we execute as normal
                    case ']':
                        if (cells[dataPointer] != 0)
                            instructionPointer = BacktrackToPreviousStart();
                        break;
                }

                // Increment the instruction pointer to go to the next instruction
                instructionPointer++;

                // Increment the number of instructions executed
                instructionsRan++;
            }

            Console.WriteLine("\nEnd of Program");
        }

        /// <summary>
        /// Skips to the next ']' that the current '[' belongs to
        /// </summary>
        /// <returns>The instruction pointer of that bracket</returns>
        private int SkipToNextEnd() {
            // We keep track of how many loops we opened while skipping, so that we find the correct bracket
            int openedLoops = 0;

            // We start looking at the next instruction
            instructionPointer++;

            // Keep track of how many instructions we have checked
            int instructionsChecked = 0;

            // We loop while the current instruction is not a closing bracket, we have unclosed loops,
            //and we have not gone over the number of loops we are allowed to check
            while ((program[instructionPointer] != ']' || openedLoops > 0) && instructionsChecked < loopsChecked) {
                // If we move past the last instruction, something is wrong. Return -1
                if (instructionPointer >= program.Length)
                    return -1;

                // If we find another opening bracket, we have opened a loop
                if (program[instructionPointer] == '[')
                    openedLoops++;

                // If we find a closing bracket and we have opened loops, we have closed a loop
                if (program[instructionPointer] == ']' && openedLoops > 0)
                    openedLoops--;

                // Increment the instruction pointer
                instructionPointer++;

                // Increment the number of instructions we checked
                instructionsChecked++;

                // If we ever end on a closing bracket while we have no open loops, we will exit this loop
            }

            // We don't have to return the instruction pointer, as we are basically setting a variable to itself
            // The reason we do this is for clarity's sake
            return instructionPointer;
        }

        /// <summary>
        /// Backtracks to the previous '[' that belongs to the current ']'
        /// </summary>
        /// <returns></returns>
        private int BacktrackToPreviousStart() {
            // Keep track of how many loops we opened
            int openedLoops = 0;

            // Decrement the instruction pointer to go back 1 step
            instructionPointer--;

            // Keep track of how many instructions we checked
            int instructionsChecked = 0;

            // We loop while the current instruction is not an opening bracket, we have unclosed loops,
            // and we have not gone over the number of loops we are allowed to check
            while ((program[instructionPointer] != '[' || openedLoops > 0) && instructionsChecked < loopsChecked) {
                // If the instruction pointer is reduced to below 0, something is wrong, return -1
                if (instructionPointer < 0)
                    return -1;

                // If we have found another closing bracket, we have opened a loop
                if (program[instructionPointer] == ']')
                    openedLoops++;

                // If we have found an opening bracket, and we have opened loops, we have closed a loop
                if (program[instructionPointer] == '[')
                    openedLoops--;

                // Decrement the instruction pointer to get to the previous pointer
                instructionPointer--;

                // Increment the number of instructions we have checked
                instructionsChecked++;
            }

            // We don't have to return the instruction pointer, as we are basically setting a variable to itself
            // The reason we do this is for clarity's sake
            return instructionPointer;
        }
    }

}
