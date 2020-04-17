using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ResourceManager {
    public class Resource {
        //private static readonly Dictionary<string, Resource> resources = new Dictionary<string, Resource>();

        //public static bool AddResource(string identifier, Resource resource) {
        //    if (resources.ContainsKey(identifier))
        //        return false;

        //    resources.Add(identifier, resource);

        //    return true;
        //}

        //public static Resource GetResource(string identifier) {
        //    if (!resources.ContainsKey(identifier))
        //        return null;

        //    return resources[identifier];
        //}

        //public static Resource GetResource(int id) {
        //    if (id <= 0 || id > resources.Count)
        //        return null;

        //    return resources.Values.ToArray()[id - 1];
        //}

        //public static Resource[] GetResourceList() => resources.Values.ToArray();

        //public static int GetResourceCount() => resources.Count;



        public readonly int id;
        public readonly string name;
        public readonly int stackSize;
        public readonly ResourceTypes resourceType;
        public readonly List<int> requiredBuildings;
        public Bitmap sprite;

        [JsonConstructor]
        private Resource(int id, string name, int stackSize, ResourceTypes resourceType, List<int> requiredBuildings) {
            this.id = id;
            this.name = name;
            this.stackSize = stackSize;
            this.resourceType = resourceType;
            this.requiredBuildings = requiredBuildings ?? new List<int>();
        }

        public override string ToString() => string.Format("id: {0}; name: {1}; stackSize: {2}; resourceType: {3}; requiredBuildings: {4}", id, name, stackSize, resourceType, requiredBuildings.ToString());
    }
}
