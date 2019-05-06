using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense.World {
    /// <summary>
    /// Keeps track of the time in the world
    /// </summary>
    public sealed class Time {
        /// <summary>
        /// The stopwatch used for tracking the time
        /// </summary>
        private Stopwatch tickWatch;

        private static Time instance;

        /// <summary>
        /// The previous tick
        /// </summary>
        private long previousTick;

        /// <summary>
        /// The elapsed amount of milli seconds since the last tick
        /// </summary>
        public static long deltaTimeMillis { get; private set; }

        /// <summary>
        /// The elapsed amount of seconds
        /// </summary>
        public static float deltaTimeSeconds => deltaTimeMillis / 1000f;

        /// <summary>
        /// The total elapsed time
        /// </summary>
        public static long totalElapsedTime { get; private set; }

        /// <summary>
        /// Instantiates a new Time
        /// </summary>
        private Time() {
            tickWatch = new Stopwatch();
            tickWatch.Start();
        }

        public static Time Create() {
            if (instance == null)
                instance = new Time();

            return instance;
        }

        public void Update() {
            deltaTimeMillis = tickWatch.ElapsedMilliseconds - previousTick;
            previousTick = tickWatch.ElapsedMilliseconds;
            totalElapsedTime = tickWatch.ElapsedMilliseconds;
        }

        public void Pause() => tickWatch.Stop();

        public void Resume() => tickWatch.Start();

        public void Reset() => tickWatch.Reset();
    }
}
