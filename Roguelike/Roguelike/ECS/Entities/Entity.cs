using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Roguelike.ECS.Components;
using Roguelike.Graphics;
using Roguelike.Utils;

namespace Roguelike.ECS.Entities {
    public abstract class Entity {
        protected List<IComponent> components;
        public Vector2 spriteSize;
        public Vector2 location;
        public Vector2 previousLocation;
        public Vector2 velocity;
        public float speed;
        public bool HasMoved => velocity.X != 0 || velocity.Y != 0;

        public Entity() {
            components = new List<IComponent>();
        }

        public RectangleF GetEntityRectangle() {
            return new RectangleF((location - (spriteSize / 2)), spriteSize);
        }

        public RectangleF GetEntityRectangle(Vector2 offset) {
            return new RectangleF(location - (spriteSize / 2) - offset, spriteSize);
        }

        public abstract Entity Copy();

        public virtual void AddComponent(IComponent component) {
            components.Add(component);
            component.Entity = this;
        }

        public virtual T GetComponent<T>() where T : IComponent {
            foreach (var component in components)
                if (component is T comp)
                    return comp;

            return default;
        }

        public virtual bool RemoveComponent<T>() where T : IComponent {
            IComponent toRemove = null;
            int index = -1;

            for (int i = 0; i < components.Count; i++) {
                if (components[i] is T) {
                    toRemove = components[i];
                    index = i;
                    break;
                }
            }

            if (toRemove == null)
                return false;

            toRemove.Entity = null;
            components.RemoveAt(index);
            return true;
        }

        public virtual bool HasComponent<T>() where T : IComponent {
            foreach (var component in components)
                if (component is T)
                    return true;

            return false;
        }

        public virtual void Draw(DrawData drawData) { }
        public virtual void Load() { }
        public virtual void Update(GameTime gameTime) {
            foreach (var component in components)
                component.Execute(gameTime);
        }

        public IComponent[] GetComponents() => components.ToArray();
    }
}
