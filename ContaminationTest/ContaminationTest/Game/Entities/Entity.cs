using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DaanLib.Maths;

namespace ContaminationTest.Game.Entities {
    public class Entity {
        private float radius;
        private Vector2D position;
        private Vector2D direction;
        private float speed;

        public Entity(float radius, float speed) {
            this.radius = radius;
            this.speed = speed;
        }

        public void Randomize(Random rand) {
            position.Randomize(rand);
            direction.Randomize(rand);
        }

        public void Update(float deltaTime) {
            position += (direction * speed);
        }
    }
}
