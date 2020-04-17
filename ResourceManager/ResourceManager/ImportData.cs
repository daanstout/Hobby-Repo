using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ResourceManager {
    public static class ImportData {
        public static ResourceCollection ImportResources(string folder, string file, ResourceTypes type) {
            if(string.IsNullOrEmpty(folder) || string.IsNullOrEmpty(file)) {
                return null;
            }

            if (!File.Exists(folder + @"\" + file))
                return null;

            string json = File.ReadAllText(folder + @"\" + file);

            List<Resource> resources = JsonConvert.DeserializeObject<List<Resource>>(json);

            //resources.ForEach(Console.WriteLine);

            resources.ForEach(resource => {
                string imageLocation = folder + @"\Sprites\Resources\" + resource.name + ".png";

                if (File.Exists(imageLocation))
                    resource.sprite = (Bitmap)Image.FromFile(imageLocation);
            });//resource.sprite = File.Exists(folder + @"\Sprites\Resources\" + resource.name + ".png") ? (Bitmap)Image.FromFile(folder + @"\Sprites\Resources\" + resource.name + ".png") : null);

            ResourceCollection resourceCollection = new ResourceCollection(type);

            resources.ForEach(resource => resourceCollection.AddResource(resource.name, resource));

            return resourceCollection;
        }

        public static bool ImportBuildings(string folder, string file) {
            if (string.IsNullOrEmpty(folder) || string.IsNullOrEmpty(file))
                return false;

            if (!File.Exists(folder + @"\" + file))
                return false;

            string json = File.ReadAllText(folder + @"\" + file);

            List<Building> buildings = JsonConvert.DeserializeObject<List<Building>>(json);

            buildings.ForEach(Console.WriteLine);

            buildings.ForEach(building => {
                string imageLocation = folder + @"\Sprites\Buildings\" + building.name + ".png";

                if (File.Exists(imageLocation))
                    building.sprite = (Bitmap)Image.FromFile(imageLocation);
            });

            return true;
        }
    }
}
