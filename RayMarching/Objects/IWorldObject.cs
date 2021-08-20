using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Text;

namespace RayMarching.Objects {
    public interface IWorldObject {
        Vector3 Position { get; set; }
        Color Color { get; set; }

        float GetDistance(Vector3 position);
        bool IsOn(Vector3 position);
        bool IsInside(Vector3 position);

        void Update(float deltaTime);
    }
}
