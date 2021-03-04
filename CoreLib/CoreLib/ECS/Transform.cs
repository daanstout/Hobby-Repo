using System;
using System.Collections.Generic;
using System.Text;

using CoreLib.Maths;

namespace CoreLib.ECS {
    public class Transform {
        private Vector3 position;
        private Vector3 rotation;
        private Vector3 scale;
        private readonly List<Transform> children;
        private Transform parent;
        private Entity entity;

        public Vector3 Position { get => position; set => position = value; }
        public Vector3 Rotation { get => rotation; set => rotation = value; }
        public Vector3 Scale { get => scale; set => scale = value; }
        public int ChildCount => children.Count;
        public bool HasChildren => children.Count != 0;
        public Transform Parent {
            get => parent;
            set {
                if (value == parent)
                    return;

                parent?.RemoveChild(this);

                parent = value;

                parent?.AddChild(this);
            }
        }
        public Entity Entity { get => entity; set => entity = value; }

        public Transform this[int i] {
            get => children[i];
            set => children[i] = value;
        }

        public Transform() {
            position = Vector3.Zero;
            rotation = Vector3.Zero;
            scale = Vector3.One;
        }

        public Transform[] GetChildren() => children.ToArray();

        internal void RemoveChild(Transform transform) => children.Remove(transform);
        internal void AddChild(Transform transform) => children.Add(transform);
    }
}
