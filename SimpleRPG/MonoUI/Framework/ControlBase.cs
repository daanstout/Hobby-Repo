using System;
using System.Collections.Generic;
using System.Text;

using IdleGame.UI.Framework.TextRenderer;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MonoUI.InputSystem;

namespace MonoUI.Framework {
    /// <summary>The base control class, handles most of the work</summary>
    public abstract class ControlBase : IDisposable{
        /// <summary>The time between clicks to register a double click in seconds</summary>
        private const float TIME_FOR_DOUBLE_CLICK_IN_SECONDS = 0.5f;
        /// <summary>Whether the control has been disposed of</summary>
        private bool disposed;

        protected bool isDirty = true;

        /// <summary>The background texture of the control</summary>
        public Texture2D background { get; set; }
        /// <summary>The font of the texture</summary>
        public SpriteFont font { get; set; }
        /// <summary>A list of children contained within this control</summary>
        public List<ControlBase> children { get; protected set; }
        /// <summary>Gets a child at a specified index</summary>
        /// <param name="index">The index to get the child from</param>
        /// <returns>The child at the specified index</returns>
        public ControlBase this[int index] {
            get {
                if (index < 0 || index >= children.Count)
                    throw new IndexOutOfRangeException();
                return children[index];
            }
        }
        /// <summary>The display rectangle of the control</summary>
        public Rectangle displayRectangle { get; protected set; }
        public Rectangle viewRectangle { get; protected set; }
        /// <summary>The location of the control within the game screen</summary>
        public Point location => displayRectangle.Location;
        protected Point worldLocation { get; set; }
        /// <summary>The size of the control</summary>
        public Point size => displayRectangle.Size;
        /// <summary>The height of the control</summary>
        public int height => size.Y;
        /// <summary>The width of the control</summary>
        public int width => size.X;
        /// <summary>Whether the control is currently enabled</summary>
        public bool enabled { get; set; } = true;
        /// <summary>Whether the control is currently visible</summary>
        public bool visible { get; set; } = true;
        /// <summary>The back color of the control</summary>
        public Color backColor { get; set; } = Color.White;
        /// <summary>The color the control should use when the user hovers over it</summary>
        public Color hoverBackColor { get; set; } = Color.White;
        /// <summary>The color the text should be</summary>
        public Color textColor { get; set; } = Color.Black;
        /// <summary>The text this control should show</summary>
        public string text { get; set; } = "";
        /// <summary>The padding of the text of this control</summary>
        public Padding textPadding { get; set; } = new Padding(0, 0, 0, 0);
        /// <summary>What text align function the text drawer should use</summary>
        public ITextAligner textAligner { get; set; } = CenteredTextAligner.instance;
        /// <summary>Whether the user currently hovers over the control</summary>
        public bool isHovered { get; protected set; }
        /// <summary>The parent of this control</summary>
        public ControlBase parent { get; protected set; }
        /// <summary>Whether the background should be displayed</summary>
        public bool displayBackground { get; set; } = true;
        /// <summary>Whether the text should be displayed</summary>
        public bool renderText { get; set; } = true;
        /// <summary>What background should be loaded during loading</summary>
        public string backGroundTextureToLoad { get; set; }
        /// <summary>What font should be loaded during loading</summary>
        public string fontToLoad { get; set; }
        /// <summary>The time since the last click</summary>
        protected TimeSpan timeSinceLastClick { get; set; } = TimeSpan.FromDays(1);

        /// <summary>Initializes a new Control with a specified display rectangle</summary>
        /// <param name="displayRectangle">The display rectangle of the control</param>
        public ControlBase(Rectangle displayRectangle) {
            this.displayRectangle = displayRectangle;
            viewRectangle = this.displayRectangle;
            children = new List<ControlBase>();
        }

        /// <summary>Initializes a new Control at a specified location and with a specified size</summary>
        /// <param name="location">The location of the control</param>
        /// <param name="size">The size of the control</param>
        public ControlBase(Point location, Point size) : this(new Rectangle(location, size)) { }
        /// <summary>Initializes a new Control at a specified point with a specified size</summary>
        /// <param name="x">The x-location of the control</param>
        /// <param name="y">The y-location of the control</param>
        /// <param name="width">The width of the controlp</param>
        /// <param name="height">The height of the control</param>
        public ControlBase(int x, int y, int width, int height) : this(new Rectangle(x, y, width, height)) { }

        /// <summary>De-initializes the control</summary>
        ~ControlBase() {
            Dispose(false);
        }

        /// <summary>Initializes the control and all children</summary>
        public virtual void Initialize() {
            foreach (var child in children)
                child.Initialize();
        }

        /// <summary>Loads content for the control and all children</summary>
        /// <param name="content">The content manager used to load the content</param>
        public virtual void Load(ContentManager content) {
            if (!string.IsNullOrEmpty(backGroundTextureToLoad))
                background = content.Load<Texture2D>(backGroundTextureToLoad);

            if (!string.IsNullOrEmpty(fontToLoad))
                font = content.Load<SpriteFont>(fontToLoad);

            foreach (var child in children)
                child.Load(content);
        }

        /// <summary>Loads a new background for the control</summary>
        /// <param name="name">The name of the background to load</param>
        /// <param name="content">The content manager to load with</param>
        public virtual void LoadBackground(string name, ContentManager content) => background = content.Load<Texture2D>(name);
        /// <summary>Loads a new font for the control</summary>
        /// <param name="name">The name of the font to load</param>
        /// <param name="content">The content manager to load with</param>
        public virtual void LoadFont(string name, ContentManager content) => font = content.Load<SpriteFont>(name);

        /// <summary>Allows for post content load work to be done on the control and all children</summary>
        public virtual void PostLoadContent() {
            foreach (var child in children)
                child.PostLoadContent();
        }

        public virtual void MoveControl(Point movement) {
            displayRectangle = new Rectangle(location + movement, size);
            isDirty = true;
        }

        /// <summary>Gets a localized mouse position</summary>
        /// <returns>The mouse position localized to be within the control</returns>
        public Point LocalizedMousePosition() => Mouse.GetState().Position - location;

        /// <summary>Transforms a localized mouse position to a screen position</summary>
        /// <param name="local">The local mouse position to transform</param>
        /// <returns>The mouse position in screen space</returns>
        public Point LocalizedMousePositionToGlobalMousePosition(Point local) => local + location;

        /// <summary>Checks whether this control directly contains the specified control</summary>
        /// <param name="control">The control to check for</param>
        /// <returns>True if this control is the parent control of the specified control</returns>
        public bool Contains(ControlBase control) {
            //return children.Contains(control);
            return control.parent == this;
        }

        /// <summary>Checks whether this control contains the specified control somewhere in the parent-child tree</summary>
        /// <param name="control">The control to check for</param>
        /// <returns>True if this control is the parent control, or any of this control's children is the parent control of the specified control</returns>
        public bool ContainsIndirect(ControlBase control) {
            if (control.parent == this)
                return true;

            foreach (var child in children)
                if (child.ContainsIndirect(control))
                    return true;

            return false;
        }

        /// <summary>Checks whether a point is within this control's area</summary>
        /// <param name="location">The location to check for</param>
        /// <returns>True if the point is within this control</returns>
        public bool IsInPoint(Point location) => displayRectangle.Contains(location);

        /// <summary>Gets the child that lies at a specified point, or if this control has no children, this control</summary>
        /// <param name="location">The location to check for</param>
        /// <returns>The control that lies the specified point</returns>
        public ControlBase GetChildAtPoint(Point location) {
            if (!displayRectangle.Contains(location))
                return null;

            if (children == null || children.Count == 0)
                return this;

            foreach (var child in children)
                if (child.IsInPoint(location))
                    return child.GetChildAtPoint(location);

            return null;
        }

        /// <summary>Disposes of the control and its resources</summary>
        public void Dispose() {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        /// <summary>Disposes of this control and its resources</summary>
        /// <param name="disposing">Whether resources should be disposed of</param>
        private void Dispose(bool disposing) {
            if (disposed)
                return;

            if (disposing) {
                background.Dispose();
                foreach (var child in children)
                    child.Dispose();
            }

            disposed = true;
        }

        /// <summary>Adds a control to this control as a child</summary>
        /// <param name="control">The control to add</param>
        public virtual void AddControl(ControlBase control) {
            if (Contains(control))
                return;

            children.Add(control);
            control.SetParent(this);
        }

        /// <summary>Sets a control as this control's parent (And removes this control from its previous parent)</summary>
        /// <param name="control">The control to become this control's parent</param>
        public virtual void SetParent(ControlBase control) {
            if (control == null)
                return;

            if (parent != null)
                parent.RemoveControl(this);

            parent = control;
        }

        /// <summary>Removes a child control from this control</summary>
        /// <param name="control">The control to remove</param>
        public virtual void RemoveControl(ControlBase control) {
            if (control == null)
                return;

            if (!Contains(control))
                return;

            children.Remove(control);
        }

        /// <summary>Updates the control if it is enabled</summary>
        /// <param name="gameTime">The game time since the last update</param>
        public void Update(GameTime gameTime) {
            if (!enabled)
                return;

            UpdateControl(gameTime);
        }

        /// <summary>Updates the control if it is enabled</summary>
        /// <param name="gameTime">The game time since the last update</param>
        protected virtual void UpdateControl(GameTime gameTime) {
            timeSinceLastClick += gameTime.ElapsedGameTime;

            if (!enabled)
                return;

            foreach (var child in children)
                child.UpdateControl(gameTime);

            CheckMouseHover();
        }

        /// <summary>Draws the control and its children</summary>
        /// <param name="gameTime">The game time since the last draw call</param>
        /// <param name="spriteBatch">The spritebatch to draw to</param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            if (!visible)
                return;

            DrawControl(gameTime, spriteBatch, new Point(0, 0), isDirty);
        }

        /// <summary>Draws the control and its children</summary>
        /// <param name="gameTime">The game time since the last draw call</param>
        /// <param name="spriteBatch">The spritebatch to draw to</param>
        protected virtual void DrawControl(GameTime gameTime, SpriteBatch spriteBatch, Point worldPosition, bool dirty) {
            if (!visible)
                return;

            dirty |= isDirty;

            if (dirty) {
                worldLocation = worldPosition + location;
                viewRectangle = new Rectangle(worldLocation, size);
                isDirty = false;
            }

            DrawBackground(spriteBatch);
            DrawText(spriteBatch);

            foreach (var child in children)
                child.DrawControl(gameTime, spriteBatch, worldLocation, dirty);
        }

        /// <summary>Draws the background of this control</summary>
        /// <param name="spriteBatch">The spritebatch to draw to</param>
        protected virtual void DrawBackground(SpriteBatch spriteBatch) {
            if (background == null || !displayBackground)
                return;

            spriteBatch.Draw(background, viewRectangle, isHovered ? hoverBackColor : backColor);
        }

        /// <summary>Draws the text of this control</summary>
        /// <param name="spriteBatch">The spritebatch to draw to</param>
        protected virtual void DrawText(SpriteBatch spriteBatch) {
            if (string.IsNullOrEmpty(text) || !renderText)
                return;

            textAligner.RenderText(text, viewRectangle, null, textColor, textPadding, spriteBatch);
        }

        /// <summary>Checks whether the user is currently hovering over the control</summary>
        protected virtual void CheckMouseHover() {
            if (!displayRectangle.Contains(Mouse.GetState().Position)) {
                if (isHovered) {
                    HoverLeave();
                }
                return;
            }

            OnHoverHandler(new MouseMoveEventArgs(Mouse.GetState().Position));

            if (!isHovered) {
                OnHoverEnterHandler(new MouseMoveEventArgs(Mouse.GetState().Position));
                isHovered = true;
            }

            foreach (var child in children)
                child.CheckMouseHover();
        }

        /// <summary>Indicates the user stopped hovering over this control</summary>
        protected virtual void HoverLeave() {
            isHovered = false;

            OnHoverLeaveHandler(new MouseMoveEventArgs(Mouse.GetState().Position));

            foreach (var child in children)
                child.HoverLeave();
        }

        /// <summary>Indicates the user clicked on the control</summary>
        /// <param name="e">The Mouse Click Event Args of the click</param>
        public virtual void Click(MouseClickEventArgs e) {
            if (!displayRectangle.Contains(e.location))
                return;

            OnClickHandler(e);

            foreach (var child in children)
                child.Click(e);
        }

        /// <summary>Indicates the user double-clicked on the control</summary>
        /// <param name="e">The Mouse Click Event Args of the click</param>
        public virtual void DoubleClick(MouseClickEventArgs e) {
            if (!displayRectangle.Contains(e.location))
                return;

            OnDoubleClickHandler(e);

            foreach (var child in children)
                child.DoubleClick(e);
        }

        /// <summary>A delegate for clicking with the mouse</summary>
        /// <param name="sender">The caller of the call</param>
        /// <param name="e">Mouse Click Event Args of the call</param>
        public delegate void OnMouseClick(object sender, MouseClickEventArgs e);
        /// <summary>A delegate for moving with the mouse</summary>
        /// <param name="sender">The caller of the call</param>
        /// <param name="e">Mouse Move Event Args of the call</param>
        public delegate void OnMouseMove(object sender, MouseMoveEventArgs e);

        /// <summary>An event for when the user clicks on the control</summary>
        public event OnMouseClick onClick;
        /// <summary>An event for when the user double-clicks on the control</summary>
        public event OnMouseClick onDoubleClick;
        /// <summary>An event for when the user hovers over the control</summary>
        public event OnMouseMove onHover;
        /// <summary>An event for when the user starts hovering over this control</summary>
        public event OnMouseMove onHoverEnter;
        /// <summary>An event for when the user stops hovering over this control</summary>
        public event OnMouseMove onHoverLeave;

        /// <summary>Invokes the onClick event</summary>
        /// <param name="e">The Mouse Click Event Args of the event</param>
        protected void OnClickHandler(MouseClickEventArgs e) {
            if (timeSinceLastClick.TotalSeconds <= TIME_FOR_DOUBLE_CLICK_IN_SECONDS)
                DoubleClick(e);

            onClick?.Invoke(this, e);

            timeSinceLastClick = TimeSpan.Zero;
        }
        /// <summary>Invokes the onDoubleClick event</summary>
        /// <param name="e">The Mouse Click Event Args of the event</param>
        protected void OnDoubleClickHandler(MouseClickEventArgs e) => onDoubleClick?.Invoke(this, e);
        /// <summary>Invokes the onHover event</summary>
        /// <param name="e">The Mouse Move Event Args of the event</param>
        protected void OnHoverHandler(MouseMoveEventArgs e) => onHover?.Invoke(this, e);
        /// <summary>Invokes the onHoverEnter event</summary>
        /// <param name="e">The Mouse Mouse Event Args of the event</param>
        protected void OnHoverEnterHandler(MouseMoveEventArgs e) => onHoverEnter?.Invoke(this, e);
        /// <summary>Invokes the onHoverLeave event</summary>
        /// <param name="e">The Mouse Move Event Args of the event</param>
        protected void OnHoverLeaveHandler(MouseMoveEventArgs e) => onHoverLeave?.Invoke(this, e);
    }
}
