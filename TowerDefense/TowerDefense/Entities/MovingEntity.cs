using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DaanLib.Maths;

namespace TowerDefense.Entities {
    public class MovingEntity : BaseEntity {
        public Vector2D velocity;
        public Vector2D heading;
        public Vector2D side => heading.Perp();

        public float mass;
        public float maxSpeed;
        public float maxForce;
        public float maxTurnRate;

        public Vector2D oldPosition;

        public MovingEntity(Vector2D position, Vector2D scale, Color color, Vector2D heading, float mass, float maxSpeed, float maxForce, float maxTurnRate) : base(position, scale) {
            this.color = color;
            this.heading = heading;
            this.mass = mass;
            this.maxSpeed = maxSpeed;
            this.maxForce = maxForce;
            this.maxTurnRate = maxTurnRate;
        }

        public override void Update(float deltaTime) {
            base.Update(deltaTime);

            position.x += (5.0f * deltaTime);
        }

        public virtual bool RotateHeadingToFacePosition(Vector2D target) {
            Vector2D toTarget = Vector2D.Vec2DNormalize(target - position);

            float angle = (float)Math.Acos(heading.Dot(toTarget));

            if (angle < 0.1)
                return true;

            if (angle > maxTurnRate)
                angle = maxTurnRate;

            Matrix rotationMatrix = Matrix.Identity(3);

            rotationMatrix.Rotate(angle * heading.Sign(toTarget));
            heading = rotationMatrix.TransformVector2D(heading);
            velocity = rotationMatrix.TransformVector2D(velocity);

            return false;
        }
    }
}
