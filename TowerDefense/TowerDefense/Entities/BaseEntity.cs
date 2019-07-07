using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DaanLib;
using DaanLib.Maths;

namespace TowerDefense.Entities {
    /// <summary>
    /// The Base Entity
    /// </summary>
    public class BaseEntity : ITickable, IEquatable<BaseEntity> {
        /// <summary>
        /// The idsetter used to fetch the new ID
        /// </summary>
        private static IDSetter idSetter = new IDSetter();
        /// <summary>
        /// The id of the entity
        /// </summary>
        protected int _id = idSetter.getNextValidId;
        /// <summary>
        /// The id of the entity
        /// </summary>
        public int id => _id;

        /// <summary>
        /// The position of the entity
        /// </summary>
        public Vector2D position;
        /// <summary>
        /// The scale of the entity
        /// </summary>
        public Vector2D scale;
        /// <summary>
        /// The bounding radius of the object
        /// </summary>
        public float boundingRadius { get; set; }
        /// <summary>
        /// The sprite of the object
        /// </summary>
        public Bitmap sprite { get; set; }
        /// <summary>
        /// The color of the object
        /// </summary>
        public Color color { get; set; } = Color.White;

        /// <summary>
        /// Gets the display rectangle of this Entity
        /// </summary>
        public RectangleF displayRectangle => new RectangleF(position, scale);

        /// <summary>
        /// Instantiates a new BaseEntity
        /// </summary>
        protected BaseEntity() : this(new Vector2D()) { }

        /// <summary>
        /// Instantiates a new BaseEntity
        /// </summary>
        /// <param name="position">The position of the entity</param>
        protected BaseEntity(Vector2D position) : this(position, new Vector2D(1, 1)) { }

        /// <summary>
        /// Instantiates a new BaseEntity
        /// </summary>
        /// <param name="position">The position of the Entity</param>
        /// <param name="scale">The scale of the entity</param>
        protected BaseEntity(Vector2D position, Vector2D scale) : this(position, scale, 1) { }

        /// <summary>
        /// Instantiates a new BaseEntity
        /// </summary>
        /// <param name="position">The position of the Entity</param>
        /// <param name="scale">The scale of the entiy</param>
        /// <param name="boundingRadius">The bounding radius of the entity</param>
        protected BaseEntity(Vector2D position, Vector2D scale, float boundingRadius) {
            this.boundingRadius = boundingRadius;
            this.position = position;
            this.scale = scale;
        }

        /// <summary>
        /// Instantiates a new BaseEntity
        /// </summary>
        /// <param name="position">The position of the Entity</param>
        /// <param name="scale">The scale of the Entity</param>
        /// <param name="boundingRadius">The bounding radius of the Entity</param>
        /// <param name="sprite">The sprite of the Entity</param>
        protected BaseEntity(Vector2D position, Vector2D scale, float boundingRadius, Bitmap sprite) {
            this.boundingRadius = boundingRadius;
            this.position = position;
            this.scale = scale;
            this.sprite = sprite;
        }

        /// <summary>
        /// Awakes the Entity
        /// </summary>
        public virtual void Awake() { }

        /// <summary>
        /// Destroys the Entity
        /// </summary>
        public virtual void Destroy() { }

        /// <summary>
        /// Initializes the Entity
        /// </summary>
        public virtual void Initialize() { }

        /// <summary>
        /// Pauses the Entity
        /// </summary>
        public virtual void Pause() { }

        /// <summary>
        /// Renders the Entity
        /// </summary>
        /// <param name="g">The Graphics instance to draw too</param>
        public virtual void Render(Graphics g) {
            if (sprite == null)
                g.FillRectangle(new SolidBrush(color), displayRectangle);
            else
                g.DrawImage(sprite, displayRectangle);
        }

        /// <summary>
        /// Updates the Entity
        /// </summary>
        /// <param name="deltaTime">The delta time between updates</param>
        public virtual void Update(float deltaTime) { }

        /// <summary>
        /// Checks for equality of this Entity and another object
        /// </summary>
        /// <param name="obj">The other object</param>
        /// <returns>True if the Entities are equal</returns>
        public override bool Equals(object obj) => Equals(obj as BaseEntity);
        
        /// <summary>
        /// Checks for equality of this Entity and another Entity
        /// </summary>
        /// <param name="other">The other Entity</param>
        /// <returns>True if the Entities are equal</returns>
        public virtual bool Equals(BaseEntity other) => other != null && id == other.id;
        
        /// <summary>
        /// Gets the HashCode of this Entity
        /// </summary>
        /// <returns>The HashCode of this Entity</returns>
        public override int GetHashCode() => 1877310944 + id.GetHashCode();

        /// <summary>
        /// Checks for equality of two Entities
        /// </summary>
        /// <param name="left">The left Entity</param>
        /// <param name="right">The right Entity</param>
        /// <returns>True if the Entities are equal</returns>
        public static bool operator ==(BaseEntity left, BaseEntity right) => EqualityComparer<BaseEntity>.Default.Equals(left, right);
        /// <summary>
        /// Checks for inequality of two Entities
        /// </summary>
        /// <param name="left">The left Entity</param>
        /// <param name="right">The right Entity</param>
        /// <returns>True if the Entities are not equal</returns>
        public static bool operator !=(BaseEntity left, BaseEntity right) => !(left == right);
    }
}
