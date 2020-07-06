﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MonoUI.Framework {
    public struct Padding {
        public static readonly Padding zero = new Padding();

        public int left;
        public int right;
        public int top;
        public int bottom;

        public Padding(int left, int right, int top, int bottom) {
            this.left = left;
            this.right = right;
            this.top = top;
            this.bottom = bottom;
        }
    }
}
