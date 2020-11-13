using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Win32.SafeHandles;

namespace DaanLib.Maths {
    public static class MathUtils {
        public const float e = (float)Math.E;
        public const float Log10E = 0.4342945f;
        public const float log2E = 1.442695f;
        public const float PI = (float)Math.PI;
        public const float HalfPI = (float)Math.PI / 2.0f;
        public const float QuarterPI = (float)Math.PI / 4.0f;
        public const float TwoPI = (float)Math.PI * 2.0f;
        public const float RadToDeg = 57.2957795130823208f;
        public const float DegToRad = 0.01745329251994329f;

        public static float Clamp(float value, float min, float max) {
            value = (value > max) ? max : value;
            value = (value < min) ? min : value;
            return value;
        }
        public static int Clamp(int value, int min, int max) {
            value = (value > max) ? max : value;
            value = (value < min) ? min : value;
            return value;
        }
        public static float Clamp01(float value) {
            value = (value > 1.0f) ? 1.0f : value;
            value = (value < 0.0f) ? 0.0f : value;
            return value;
        }
        public static float Distance(float a, float b) => Math.Abs(a - b);
        public static float Lerp(float start, float end, float delta) => start + (end - start) * Clamp01(delta);
        public static float LerpUnclamped(float start, float end, float delta) => start + (end - start) * delta;
        public static float Max(float a, float b) => a > b ? a : b;
        public static int Max(int a, int b) => a > b ? a : b;
        public static float Min(float a, float b) => a < b ? a : b;
        public static int Min(int a, int b) => a < b ? a : b;
        public static bool IsPowerOfTwo(int value) => (value > 0) && ((value & (value - 1)) == 0);
    }
}
