using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLib.ECS {
    public class Entity {
        private readonly Transform transform;
        private readonly List<Component> components;

        public Transform Transform => transform;

        public Entity() {
            transform = new Transform();
            components = new List<Component>();
        }

        public Component AddComponent(Component component) {
            if (components.Contains(component))
                return null;

            components.Add(component);

            return component;
        }

        public T AddComponent<T>() where T : Component, new() {
            T comp = new T {
                Entity = this
            };

            components.Add(comp);

            return comp;
        }

        public T GetComponent<T>() where T : Component {
            foreach (var comp in components)
                if (comp is T compT)
                    return compT;

            return null;
        }

        public T[] GetComponents<T>() where T : Component {
            var numComps = 0;

            foreach (var comp in components)
                if (comp is T)
                    numComps++;

            if (numComps == 0)
                return new T[0];

            var comps = new T[numComps];
            var currentIndex = 0;

            foreach (var comp in components)
                if (comp is T compT)
                    comps[currentIndex++] = compT;

            return comps;
        }

        public T GetComponentInParent<T>() where T : Component {
            foreach (var comp in components)
                if (comp is T compT)
                    return compT;

            if (transform.Parent != null)
                return transform.Parent.Entity.GetComponentInParent<T>();
            
            return null;
        }



        public bool HasComponent<T>() where T : Component {
            foreach (var comp in components)
                if (comp is T)
                    return true;

            return false;
        }

        public void RemoveComponent(Component component) => components.Remove(component);


        public void RemoveComponent<T>() where T : Component {
            foreach (var comp in components) {
                if (comp is T) {
                    components.Remove(comp);
                    return;
                }
            }
        }
    }
}
