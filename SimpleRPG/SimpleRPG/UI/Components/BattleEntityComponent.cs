using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

using IdleGame.UI.Framework.TextRenderer;

using Microsoft.Xna.Framework;

using MonoUI.Controls;
using MonoUI.Framework;

using SimpleRPG.Actors;

namespace SimpleRPG.UI.Components {
    public class BattleEntityComponent : ComponentBase {
        Picture picture;
        Label nameLabel;
        Label healthLabel;
        Creature creature;

        public BattleEntityComponent(Rectangle displayRectangle) : base(displayRectangle) { }

        public BattleEntityComponent(Point location, Point size) : this(new Rectangle(location, size)) { }

        public BattleEntityComponent(int x, int y, int width, int height) : this(new Rectangle(x, y, width, height)) { }

        public void Initialize(Creature creature) {
            this.creature = creature;

            picture = new Picture(new Rectangle(displayRectangle.Location + new Point(50, 25), new Point(200, 400))) {
                background = creature.sprite
            };

            AddControl(picture);

            nameLabel = new Label(new Rectangle(displayRectangle.Location + new Point(50, 450), new Point(displayRectangle.Width - 100, 0))) {
                textAligner = CenteredTextAligner.instance,
                text = creature.name,
                fontToLoad = "Font"
            };

            AddControl(nameLabel);

            healthLabel = new Label(new Rectangle(displayRectangle.Location + new Point(50, 475), new Point(displayRectangle.Width - 100, 0))) {
                textAligner = CenteredTextAligner.instance,
                text = $"{creature.health} / {creature.maxHealth}",
                fontToLoad = "Font"
            };

            AddControl(healthLabel);
        }

        protected override void UpdateControl(GameTime gameTime) {
            healthLabel.text = $"{creature.health} / {creature.maxHealth}";

            base.UpdateControl(gameTime);
        }
    }
}
