using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualMachine {
    public static class Memory {
        public static byte[] CreateMemory(int sizeInBytes) {
            return new byte[sizeInBytes];
        }
    }
}
