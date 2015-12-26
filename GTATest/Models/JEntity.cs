using GTA;
using Newtonsoft.Json;

namespace GTATest.Models
{
    /// <summary>
    /// Represents a JSON-serialized <see cref="Entity"/>.
    /// </summary>
    public class JEntity : JsonModel<Entity>
    {
        /// <summary>
        /// Initializes an instance of the <see cref="JEntity"/> class.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public JEntity(Entity entity)
        {
            Position = new JVector3(entity.Position);
            Alpha = entity.Alpha;
            Health = entity.Health;
            Heading = entity.Heading;
            IsBulletProof = entity.IsBulletProof;
            IsCollisionProof = entity.IsCollisionProof;
            IsPersistent = entity.IsPersistent;
            IsFireProof = entity.IsFireProof;
            IsExplosionProof = entity.IsExplosionProof;
            IsInvincible = entity.IsInvincible;
            IsMeleeProof = entity.IsMeleeProof;
            IsOnlyDamagedByPlayer = entity.IsOnlyDamagedByPlayer;
            IsVisible = entity.IsVisible;
            MaxHealth = entity.MaxHealth;
            LodDistance = entity.LodDistance;
            Rotation = new JVector3(entity.Rotation);
        }

        /// <summary>
        /// Creates an instance of this <see cref="JsonModel{T}"/>.
        /// </summary>
        public override Entity Create()
        {
            return null;
        }

        /// <summary>
        /// Gets the position of this <see cref="JEntity"/>.
        /// </summary>
        [JsonProperty("position", Order=0)]
        public JVector3 Position { get; }

        /// <summary>
        /// Gets the alpha of this <see cref="JEntity"/>.
        /// </summary>
        [JsonProperty("alpha")]
        public int Alpha { get; }

        /// <summary>
        /// Gets the health of this <see cref="JEntity"/>.
        /// </summary>
        [JsonProperty("health")]
        public int Health { get; }

        /// <summary>
        /// Gets the heading of this <see cref="JEntity"/>.
        /// </summary>
        [JsonProperty("heading")]
        public float Heading { get; }

        /// <summary>
        /// Gets whether this <see cref="JEntity"/> is bullet proof.
        /// </summary>
        [JsonProperty("isBulletProof")]
        public bool IsBulletProof { get; }

        /// <summary>
        /// Gets whether this <see cref="JEntity"/> is collision proof.
        /// </summary>
        [JsonProperty("isCollisionProof")]
        public bool IsCollisionProof { get; }

        /// <summary>
        /// Gets whether this <see cref="JEntity"/> is persistent.
        /// </summary>
        [JsonProperty("isPersistent")]
        public bool IsPersistent { get; }

        /// <summary>
        /// Gets whether this <see cref="JEntity"/> is fire proof.
        /// </summary>
        [JsonProperty("isFireProof")]
        public bool IsFireProof { get; }

        /// <summary>
        /// Gets whether this <see cref="JEntity"/> is explosion proof.
        /// </summary>
        [JsonProperty("isExplosionProof")]
        public bool IsExplosionProof { get; }

        /// <summary>
        /// Gets whether this <see cref="JEntity"/> is invincible.
        /// </summary>
        [JsonProperty("isInvincible")]
        public bool IsInvincible { get; }

        /// <summary>
        /// Gets whether this <see cref="JEntity"/> is melee proof.
        /// </summary>
        [JsonProperty("isMeleeProof")]
        public bool IsMeleeProof { get; }

        /// <summary>
        /// Gets whether this <see cref="JEntity"/> can only be damaged by a player.
        /// </summary>
        [JsonProperty("isOnlyDamagedByPlayer")]
        public bool IsOnlyDamagedByPlayer { get; }

        /// <summary>
        /// Gets whether this <see cref="JEntity"/> is visible.
        /// </summary>
        [JsonProperty("isVisible")]
        public bool IsVisible { get; }

        /// <summary>
        /// Gets the maximum health of this <see cref="JEntity"/>.
        /// </summary>
        [JsonProperty("maxHealth")]
        public int MaxHealth { get; }

        /// <summary>
        /// Gets the LOD distance of this <see cref="JEntity"/>.
        /// </summary>
        [JsonProperty("lodDistance")]
        public int LodDistance { get; }

        /// <summary>
        /// Gets the rotation of this <see cref="JEntity"/>.
        /// </summary>
        [JsonProperty("rotation", Order=1)]
        public JVector3 Rotation { get; }
    }
}
