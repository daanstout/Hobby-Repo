using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace VirtualMachine {
    public class CPU {
        private readonly byte[] memory;
        private readonly string[] registerNames;
        private readonly byte[] registers;
        private Dictionary<string, int> registerMaps;

        public CPU(byte[] memory) {
            this.memory = memory;

            registerNames = new string[]{
                "ip", "acc",
                "r1", "r2", "r3", "r4",
                "r5", "r6", "r7", "r8"
            };

            registers = Memory.CreateMemory(registerNames.Length * 2);

            registerMaps = new Dictionary<string, int>();

            for (int i = 0; i < registerNames.Length; i++)
                registerMaps.Add(registerNames[i], i * 2);
        }

        byte[] UshortToByte(ushort value) {
            byte[] bytes = new byte[] {
                (byte)(value >> 8),
                (byte)value
            };

            return bytes;
        }

        ushort GetRegister(string name) {
            if (!registerMaps.ContainsKey(name))
                throw new Exception($"getRegister: No such register: {name}");

            return (ushort)(((registers[registerMaps[name]]) << 8) | registers[registerMaps[name]]);
        }

        void SetRegister(string name, ushort value) {
            if (!registerMaps.ContainsKey(name))
                throw new Exception($"getRegister: No such register: {name}");

            byte[] bytes = UshortToByte(value);

            registers[registerMaps[name]] = bytes[0];
            registers[registerMaps[name] + 1] = bytes[1];
        }

        byte Fetch() {
            var nextInstructionAddress = GetRegister("ip");
            var instruction = memory[nextInstructionAddress];
            SetRegister("ip", (ushort)(nextInstructionAddress + 1));
            return instruction;
        }

        ushort Fetch16() {
            var nextInstructionAddress = GetRegister("ip");
            var instruction = memory[nextInstructionAddress] << 8;
            instruction |= memory[nextInstructionAddress + 1];
            SetRegister("ip", (ushort)(nextInstructionAddress + 2));
            return (ushort)instruction;
        }

        void Execute(byte instruction) {
            ushort literal;
            switch (instruction) {
                case 0x10:
                    literal = Fetch16();
                    SetRegister("r1", literal);
                    break;
                case 0x11:
                    literal = Fetch16();
                    SetRegister("r2", literal);
                    break;
                case 0x12:
                    ushort r1 = Fetch();
                    ushort r2 = Fetch();
                    var value = 
            }
        }
    }
}
