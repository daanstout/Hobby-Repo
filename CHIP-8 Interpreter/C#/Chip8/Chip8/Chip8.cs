using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Chip8 {
    public class Chip8 {
        public const ushort DISPLAY_WIDTH = 64;
        public const ushort DISPLAY_HEIGTH = 32;

        /// <summary>
        /// The current op-code we are working with
        /// </summary>
        protected ushort opcode;

        /// <summary>
        /// The memory, should be initialized with 4096 indexes
        /// </summary>
        protected byte[] memory;

        /// <summary>
        /// General purpose registers. There are 15 of those, with a 16th as the carry flag
        /// </summary>
        protected byte[] V;

        /// <summary>
        /// The index register
        /// </summary>
        protected ushort indexRegister;

        /// <summary>
        /// The program counter, indicates where we are and what instruction we should do
        /// </summary>
        protected ushort programCounter;

        /*  The program counter can have a value from 0x000 to 0xFFF
         *  0x000 - 0x1FF - Chip 8 interpreter (contains font set in emu
         *  0x050 - 0x0A0 - Used for the built in 4x5 pixel font set (0-F)
         *  0x200 - 0xFFF - Program ROM and work RAM
         */

        /// <summary>
        /// The pixels on the screen
        /// </summary>
        protected byte[] gfx;

        /// <summary>
        /// Time until a delay happens
        /// </summary>
        protected byte delayTimer;
        /// <summary>
        /// Time until the system buzzes
        /// </summary>
        protected byte soundTimer;

        /// <summary>
        /// The stack
        /// </summary>
        protected ushort[] stack;
        /// <summary>
        /// The current index of the stack
        /// </summary>
        protected ushort stackPointer;

        /// <summary>
        /// The keypad (0x0 - 0xF)
        /// </summary>
        protected byte[] key;

        protected byte[] chip8_fontset = {
            0xF0, 0x90, 0x90, 0x90, 0xF0, // 0
            0x20, 0x60, 0x20, 0x20, 0x70, // 1
            0xF0, 0x10, 0xF0, 0x80, 0xF0, // 2
            0xF0, 0x10, 0xF0, 0x10, 0xF0, // 3
            0x90, 0x90, 0xF0, 0x10, 0x10, // 4
            0xF0, 0x80, 0xF0, 0x10, 0xF0, // 5
            0xF0, 0x80, 0xF0, 0x90, 0xF0, // 6
            0xF0, 0x10, 0x20, 0x40, 0x40, // 7
            0xF0, 0x90, 0xF0, 0x90, 0xF0, // 8
            0xF0, 0x90, 0xF0, 0x10, 0xF0, // 9
            0xF0, 0x90, 0xF0, 0x90, 0x90, // A
            0xE0, 0x90, 0xE0, 0x90, 0xE0, // B
            0xF0, 0x80, 0x80, 0x80, 0xF0, // C
            0xE0, 0x90, 0x90, 0x90, 0xE0, // D
            0xF0, 0x80, 0xF0, 0x80, 0xF0, // E
            0xF0, 0x80, 0xF0, 0x80, 0x80  // F
        };

        /// <summary>
        /// Indicates whether we want to draw or not
        /// </summary>
        public bool drawFlag { get; protected set; }

        public Chip8() {
            memory = new byte[4096];
            V = new byte[16];
            gfx = new byte[DISPLAY_WIDTH * DISPLAY_HEIGTH];
            stack = new ushort[16];
            key = new byte[16];
        }

        public bool Initialize() {
            memory = new byte[4096];
            for (int i = 0; i < memory.Length; i++)
                memory[i] = 0;

            V = new byte[16];
            for (int i = 0; i < V.Length; i++)
                V[i] = 0;

            gfx = new byte[DISPLAY_WIDTH * DISPLAY_HEIGTH];
            for (int i = 0; i < gfx.Length; i++)
                gfx[i] = 0;

            stack = new ushort[16];
            for (int i = 0; i < stack.Length; i++)
                stack[i] = 0;

            key = new byte[16];
            for (int i = 0; i < key.Length; i++)
                key[i] = 0;

            programCounter = 0x200;
            opcode = 0;
            indexRegister = 0;
            stackPointer = 0;

            for (int i = 0; i < 80; i++)
                memory[i] = chip8_fontset[i];

            delayTimer = 0;
            soundTimer = 0;

            return true;
        }

        public bool LoadGame(string name) {
            //string file = File.ReadAllText(name);
            byte[] buffer = File.ReadAllBytes(name);

            //byte[] buffer = Encoding.ASCII.GetBytes(file);

            for (int i = 0; i < buffer.Length; i++)
                memory[i + 512] = buffer[i];

            memory[0 + 512] = 0xA2;
            memory[1 + 512] = 0xF0;

            return true;
        }

        public void EmulateCycle() {
            byte byte1 = memory[programCounter];
            byte byte2 = memory[programCounter + 1];

            opcode = (ushort)(byte1 << 8 | byte2);
            //opcode = (ushort)((ushort)memory[programCounter] << 8 | memory[programCounter + 1]);

            switch (opcode & 0xF000) {
                case 0x0000:
                    switch (opcode & 0x000F) {
                        case 0x0000: // Clear the screen
                            break;
                        case 0x000E: // Return from subroutine
                            break;
                        default:
                            Console.WriteLine("Unknown opcode: " + opcode);
                            break;
                    }
                    break;

                case 0x1000:
                    programCounter = (byte)(opcode & 0x0FFF);
                    break;

                case 0x2000:
                    stack[stackPointer] = programCounter;
                    stackPointer++;
                    programCounter = (ushort)(opcode & 0x0FFF);
                    break;

                case 0x8000:
                    switch (opcode & 0x000F) {
                        case 0x0004:
                            if (V[(opcode & 0x00F0) >> 4] > 0xFF - V[(opcode & 0x0F00) >> 8])
                                V[0xF] = 1;
                            else
                                V[0xF] = 0;
                            V[(opcode & 0x0F00) >> 8] += V[(opcode & 0x00F0) >> 4];
                            programCounter += 2;
                            break;
                        default:
                            Console.WriteLine("Unknown opcode: " + opcode);
                            break;
                    } 
                    break;

                case 0xA000:
                    indexRegister = (ushort)(opcode & 0x0FFF);
                    programCounter += 2;
                    break;

                case 0xF000:
                    switch (opcode & 0x00FF) {
                        case 0x0033:
                            memory[indexRegister] = (byte)(V[(opcode & 0x0F00) >> 8] / 100);
                            memory[indexRegister + 1] = (byte)(V[(opcode & 0x0F00) >> 8] / 10 % 10);
                            memory[indexRegister + 2] = (byte)(V[(opcode & 0x0F00) >> 8] % 100 % 10);
                            break;
                    }
                    break;

                default:
                    Console.WriteLine("Unknown opcode: " + opcode);
                    break;
            }

            if (delayTimer > 0)
                delayTimer--;

            if (soundTimer > 0) {
                if (soundTimer == 1)
                    Console.WriteLine("Beep!");
                soundTimer--;
            }
        }

        public bool SetKeys() {


            return true;
        }
    }
}
