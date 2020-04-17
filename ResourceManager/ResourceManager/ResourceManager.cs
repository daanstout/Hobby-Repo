using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DaanLib.Menus;
using ResourceManager.UserControls;

namespace ResourceManager {
    public partial class ResourceManager : Form {
        const int resourceWidth = 60;
        const int resourceHeight = 25;
        const int spriteSize = 20;

        private AMenu<ResourceTypes> resourceViewMenu;
        private AMenu<UserControl> mainViewMenu;

        private readonly List<ResourceCollection> resourceCollections;

        private int currentResourceToShow;

        public ResourceManager() {
            InitializeComponent();

            resourceCollections = new List<ResourceCollection>() {
                ImportData.ImportResources(@"D:\Google Drive\Resource Managing Game\Data", "ResourcesRaw.json", ResourceTypes.Raw),
                ImportData.ImportResources(@"D:\Google Drive\Resource Managing Game\Data", "ResourcesIntermediate.json", ResourceTypes.Intermediate),
                ImportData.ImportResources(@"D:\Google Drive\Resource Managing Game\Data", "ResourcesFinalized.json", ResourceTypes.Finalized)
            };

            ImportData.ImportBuildings(@"D:\Google Drive\Resource Managing Game\Data", "Buildings.json");

            SetUpMenus();
        }

        private void SetUpMenus() {
            resourceViewMenu = new VerticalMenu<ResourceTypes>(resourceMenuPanel, new SizeF(resourceMenuPanel.Width, 25));

            resourceViewMenu.tabChanged += OnResourceViewTabChange;

            resourceViewMenu.tabColor = BackColor;
            resourceViewMenu.textColor = ForeColor;
            resourceViewMenu.borderWidth = 0;
            resourceViewMenu.bordorColor = Color.White;

            resourceViewMenu.CreateTab("Raw", ResourceTypes.Raw);
            resourceViewMenu.CreateTab("Intermediate", ResourceTypes.Intermediate);
            resourceViewMenu.CreateTab("Finalized", ResourceTypes.Finalized);

            resourceViewMenu.ChangeTab(0);


            mainViewMenu = new VerticalMenu<UserControl>(mainViewMenuPanel, new SizeF(mainViewMenuPanel.Width, 50));

            mainViewMenu.tabChanged += OnMainViewTabChange;

            mainViewMenu.tabColor = BackColor;
            mainViewMenu.textColor = ForeColor;
            mainViewMenu.borderWidth = 0;
            mainViewMenu.bordorColor = Color.White;

            mainViewMenu.CreateTab("Resources", new ResourceViewControl());
            mainViewMenu.CreateTab("Buildings", null);
            mainViewMenu.CreateTab("Produce", null);

            mainViewMenu.ChangeTab(0);
        }

        private void OnResourceViewTabChange(object sender, TabChangedEventArgs<ResourceTypes> e) {
            currentResourceToShow = (int)e.data;

            resourcePanel.Invalidate();
        }

        private void OnMainViewTabChange(object sender, TabChangedEventArgs<UserControl> e) {
            SetViewControl(e.data);
        }

        private void SetViewControl(UserControl control) {
            if (control == null || mainViewPanel == null)
                return;

            mainViewPanel.Controls.Clear();
            mainViewPanel.Controls.Add(control);

            control.Focus();

            mainViewPanel.Invalidate();
        }

        private void resourcePanel_Paint(object sender, PaintEventArgs e) {
            if (resourceCollections[currentResourceToShow].GetResourceCount() == 0)
                return;

            if (!(sender is Panel panel))
                return;

            Resource[] resources = resourceCollections[currentResourceToShow].GetResourceList();

            int currentX = 0;
            int currentY = 0;

            foreach (Resource resource in resources) {
                if (resource.sprite != null)
                    e.Graphics.DrawImage(resource.sprite, new Rectangle(currentX, currentY, spriteSize, spriteSize));

                SizeF stringSize = e.Graphics.MeasureString(resource.stackSize.ToString(), panel.Font);

                Point stringLocation = new Point() {
                    X = currentX + spriteSize + 5,
                    Y = (int)(currentY + ((spriteSize - stringSize.Height) / 2))
                };

                e.Graphics.DrawString(resource.stackSize.ToString(), panel.Font, Brushes.White, stringLocation);

                currentX += resourceWidth;

                if (currentX + resourceWidth > panel.Width) {
                    currentX = 0;
                    currentY += resourceHeight + 5;
                }
            }
        }

        private void resourcePanel_MouseMove(object sender, MouseEventArgs e) {
            if (!(sender is Panel panel))
                return;

            int resourcesPerRow = panel.Width / resourceWidth;

            int row = e.Y / resourceHeight;
            int column = e.X / resourceWidth;

            int index = (row * resourcesPerRow) + column;

            resourcePanelToolTip.SetToolTip(panel, resourceCollections[currentResourceToShow].GetResource(index + 1)?.name);
        }
    }
}
