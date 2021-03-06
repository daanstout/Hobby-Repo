﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

using MonoUI.Framework;

using SimpleRPG.Actors;
using SimpleRPG.UI.Components;

namespace SimpleRPG.UI.Windows {
    public class BattleFieldWindow : ContainerBase {
        Point componentSize;

        BattleEntityComponent leftCreatureComponent;
        BattleEntityComponent rightCreatureComponent;

        public BattleFieldWindow(Rectangle displayRectangle) : base(displayRectangle) { }

        public BattleFieldWindow(Point location, Point size) : this(new Rectangle(location, size)) { }

        public BattleFieldWindow(int x, int y, int width, int height) : this(new Rectangle(x, y, width, height)) { }

        public void Initialize(Creature leftCreature, Creature rightCreature) {
            componentSize = new Point(300, 500);

            leftCreatureComponent = new BattleEntityComponent(new Point(0, 0), componentSize) {
                backGroundTextureToLoad = "BorderBlack"
            };
            rightCreatureComponent = new BattleEntityComponent(displayRectangle.Width - componentSize.X, 0, componentSize.X, componentSize.Y) {
                backGroundTextureToLoad = "BorderBlack"
            };

            leftCreatureComponent.Initialize(leftCreature);
            rightCreatureComponent.Initialize(rightCreature);

            AddControl(leftCreatureComponent);
            AddControl(rightCreatureComponent);
        }
    }
}
