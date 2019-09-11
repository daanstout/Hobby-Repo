using System;
using System.Diagnostics;
using System.IO;

namespace Chip8 {
    class Program {
        const char PIXEL = '█';

        static void Main(string[] args) {
            Chip8 chip = new Chip8();

            SetupGraphics();
            SetupInput();

            chip.Initialize();
            chip.LoadGame(@"D:\Github\myChip8-bin-src\pong2.c8");

            for(int i = 0; i < 100; i++) {
            //while (true) {
                chip.EmulateCycle();

                if (chip.drawFlag)
                    DrawGraphics();

                chip.SetKeys();
            }
        }

        static void SetupGraphics() {
            Console.SetWindowSize(Chip8.DISPLAY_WIDTH, Chip8.DISPLAY_HEIGTH);
        }

        static void SetupInput() {

        }

        static void DrawGraphics() {

        }
    }
}
