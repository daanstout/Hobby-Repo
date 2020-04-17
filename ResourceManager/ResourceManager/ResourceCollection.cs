using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceManager {
    public class ResourceCollection {
        private readonly Dictionary<string, Resource> resources;

        public readonly ResourceTypes resourceType;

        public ResourceCollection(ResourceTypes resourceType) {
            this.resourceType = resourceType;

            resources = new Dictionary<string, Resource>();
        }

        public bool AddResource(string identifier, Resource resource) {
            if (resources.ContainsKey(identifier))
                return false;

            resources.Add(identifier, resource);

            return true;
        }

        public Resource GetResource(string identifier) {
            if (!resources.ContainsKey(identifier))
                return null;

            return resources[identifier];
        }

        public Resource GetResource(int id) {
            if (id <= 0 || id > resources.Count)
                return null;

            return resources.Values.ToArray()[id - 1];
        }

        public Resource[] GetResourceList() => resources.Values.ToArray();

        public int GetResourceCount() => resources.Count;
    }
}
