using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLib.ECS {
    public abstract class Component {
        private readonly Guid id;
        private readonly Entity entity;

        public Guid ID => id;
        public Entity Entity { get; internal set; }

        protected Component() {
            id = Guid.NewGuid();
        }

        public T GetComponent<T>() where T : Component => entity.GetComponent<T>();
        public T[] GetComponents<T>() where T : Component => entity.GetComponents<T>();
        public bool HasComponent<T>() where T : Component => entity.HasComponent<T>();
        public void RemoveSelf() => entity.RemoveComponent(this);
    }
}
