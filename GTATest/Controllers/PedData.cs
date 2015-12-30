using GTA;
using GTATest.Models;

namespace GTATest.Controllers
{
    public class PedData : EntityData<ControlledPed>
    {
        /// <summary>
        /// Initializes an instance of the <see cref="PedData"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public PedData(string name) : base(name, EntityType.Ped)
        {}

        #region Properties

        /// <summary>
        /// Gets the height of the wetness on the model of this <see cref="PedData"/>.
        /// </summary>
        public float WetnessHeight
        {
            get { return Properties["wetnessHeight"]; }
            set { Properties["wetnessHeight"] = value; }
        }

        /// <summary>
        /// Gets the shoot rate of this <see cref="PedData"/>.
        /// </summary>
        public int ShootRate
        {
            get { return Properties["shootRate"]; }
            set { Properties["shootRate"] = value; }
        }

        /// <summary>
        /// Gets the relationship group of this <see cref="PedData"/>.
        /// </summary>
        public int RelationshipGroup
        {
            get { return Properties["relationshipGroup"]; }
            set { Properties["relationshipGroup"] = value; }
        }

        /// <summary>
        /// Gets whether this <see cref="PedData"/> never leaves its group.
        /// </summary>
        public bool NeverLeavesGroup
        {
            get { return Properties["neverLeavesGroup"]; }
            set { Properties["neverLeavesGroup"] = value; }
        }

        /// <summary>
        /// Gets the money of this <see cref="PedData"/>.
        /// </summary>
        public int Money
        {
            get { return Properties["money"]; }
            set { Properties["money"] = value; }
        }

        /// <summary>
        /// Gets the maximum driving speed of this <see cref="PedData"/>, while in a vehicle.
        /// </summary>
        public float MaxDrivingSpeed
        {
            get { return Properties["maxDrivingSpeed"]; }
            set { Properties["maxDrivingSpeed"] = value; }
        }

        /// <summary>
        /// Gets whether this <see cref="PedData"/> is a priority target for its enemies.
        /// </summary>
        public bool IsPriorityTargetForEnemies
        {
            get { return Properties["isPriorityTargetForEnemies"]; }
            set { Properties["isPriorityTargetForEnemies"] = value; }
        }

        /// <summary>
        /// Gets whether this <see cref="PedData"/> is an enemy.
        /// </summary>
        public bool IsEnemy
        {
            get { return Properties["isEnemy"]; }
            set { Properties["isEnemy"] = value; }
        }

        /// <summary>
        /// Gets whether this <see cref="PedData"/> is ducking.
        /// </summary>
        public bool IsDucking
        {
            get { return Properties["isDucking"]; }
            set { Properties["isDucking"] = value; }
        }

        /// <summary>
        /// Gets the firing pattern of this <see cref="PedData"/>.
        /// </summary>
        public FiringPattern FiringPattern
        {
            get { return Properties["firingPattern"]; }
            set { Properties["firingPattern"] = value; }
        }

        /// <summary>
        /// Gets whether this <see cref="PedData"/> dies when inside a sinking vehicle.
        /// </summary>
        public bool DrownsInSinkingVehicle
        {
            get { return Properties["drownsInSinkingVehicle"]; }
            set { Properties["drownsInSinkingVehicle"] = value; }
        }

        /// <summary>
        /// Gets whether this <see cref="PedData"/> drops its weapons on death.
        /// </summary>
        public bool DropsWeaponsOnDeath
        {
            get { return Properties["dropsWeaponsOnDeath"]; }
            set { Properties["dropsWeaponsOnDeath"] = value; }
        }

        /// <summary>
        /// Gets the driving style of this <see cref="PedData"/>, while inside a vehicle.
        /// </summary>
        public DrivingStyle DrivingStyle
        {
            get { return Properties["drivingStyle"]; }
            set { Properties["drivingStyle"] = value; }
        }

        /// <summary>
        /// Gets the driving speed of this <see cref="PedData"/>, while inside a vehicle.
        /// </summary>
        public float DrivingSpeed
        {
            get { return Properties["drivingSpeed"]; }
            set { Properties["drivingSpeed"] = value; }
        }

        /// <summary>
        /// Gets whether this <see cref="PedData"/> dies instantly in water.
        /// </summary>
        public bool DiesInstantlyInWater
        {
            get { return Properties["diesInstantlyInWater"]; }
            set { Properties["diesInstantlyInWater"] = value; }
        }

        /// <summary>
        /// Gets whether this <see cref="PedData"/> can switch weapons.
        /// </summary>
        public bool CanSwitchWeapons
        {
            get { return Properties["canSwitchWeapons"]; }
            set { Properties["canSwitchWeapons"] = value; }
        }

        /// <summary>
        /// Gets whether this <see cref="PedData"/> can suffer critical hits from other peds.
        /// </summary>
        public bool CanSufferCriticalHits
        {
            get { return Properties["canSufferCriticalHits"]; }
            set { Properties["canSufferCriticalHits"] = value; }
        }

        /// <summary>
        /// Gets whether this <see cref="PedData"/> can ragdoll.
        /// </summary>
        public bool CanRagdoll
        {
            get { return Properties["canRagdoll"]; }
            set { Properties["canRagdoll"] = value; }
        }

        /// <summary>
        /// Gets whether this <see cref="PedData"/> can play gestures.
        /// </summary>
        public bool CanPlayGestures
        {
            get { return Properties["canPlayGestures"]; }
            set { Properties["canPlayGestures"] = value; }
        }

        /// <summary>
        /// Gets whether this <see cref="PedData"/> always keeps the same task.
        /// </summary>
        public bool AlwaysKeepTask
        {
            get { return Properties["alwaysKeepTask"]; }
            set { Properties["alwaysKeepTask"] = value; }
        }

        /// <summary>
        /// Gets whether this <see cref="PedData"/> can fly through the windscreen of a vehicle.
        /// </summary>
        public bool CanFlyThroughWindscreen
        {
            get { return Properties["canFlyThroughWindscreen"]; }
            set { Properties["canFlyThroughWindscreen"] = value; }
        }

        /// <summary>
        /// Gets whether this <see cref="PedData"/> can be targetted by other peds.
        /// </summary>
        public bool CanBeTargetted
        {
            get { return Properties["canBeTargetted"]; }
            set { Properties["canBeTargetted"] = value; }
        }

        /// <summary>
        /// Gets whether this <see cref="PedData"/> can be knocked off a bike.
        /// </summary>
        public bool CanBeKnockedOffBike
        {
            get { return Properties["canBeKnockedOffBike"]; }
            set { Properties["canBeKnockedOffBike"] = value; }
        }

        /// <summary>
        /// Gets whether this <see cref="PedData"/> can be dragged out of a vehicle.
        /// </summary>
        public bool CanBeDraggedOutVehicle
        {
            get { return Properties["canBeDraggedOutVehicle"]; }
            protected set { Properties["canBeDraggedOutVehicle"] = value; }
        }

        /// <summary>
        /// Gets whether to block permanent events within this <see cref="PedData"/>.
        /// </summary>
        public bool BlockPermanentEvents
        {
            get { return Properties["blockPermanentEvents"]; }
            protected set { Properties["blockPermanentEvents"] = value; }
        }

        /// <summary>
        /// Gets wheter this <see cref="PedData"/> always dies when it has low health.
        /// </summary>
        public bool AlwaysDiesOnLowHealth
        {
            get { return Properties["alwaysDiesOnLowHealth"]; }
            protected set { Properties["alwaysDiesOnLowHealth"] = value; }
        }

        /// <summary>
        /// Gets or sets the model of this <see cref="PedData"/>.
        /// </summary>
        public Model Model
        {
            get { return ((JModel) Properties["model"]).Create(); }
            protected set { Properties["model"] = new JModel(value); }
        }

        /// <summary>
        /// Gets or sets the armor of this <see cref="PedData"/>.
        /// </summary>
        public int Armor
        {
            get { return Properties["armor"]; }
            protected set { Properties["armor"] = value; }
        }

        /// <summary>
        /// Gets or sets the accuracy of this <see cref="PedData"/>.
        /// </summary>
        public int Accuracy
        {
            get { return Properties["accuracy"]; }
            protected set { Properties["accuracy"] = value; }
        }

        #endregion

        /// <summary>
        /// Copies the information from the specified Entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public override void Copy(Entity entity)
        {
            base.Copy(entity);

            var ped = (Ped) entity;
            if (ped == null)
            {
                return;
            }

            Armor = ped.Armor;
            Accuracy = ped.Accuracy;
            CanRagdoll = ped.CanRagdoll;
            CanFlyThroughWindscreen = ped.CanFlyThroughWindscreen;
            RelationshipGroup = ped.RelationshipGroup;
            Money = ped.Money;
            IsDucking = ped.IsDucking;
        }

        /// <summary>
        /// Creates this <see cref="PedData"/>.
        /// </summary>
        public override void Create()
        {
            // Create the PedData.
            Ped ped = World.CreatePed(Model, Position.Create(), Heading);

            // Initialize the Ped.
            Initialize(ped);

            // Set the properties.
            ped.Armor = Armor;
            ped.Accuracy = Accuracy;
            ped.AlwaysDiesOnLowHealth = AlwaysDiesOnLowHealth;
            ped.BlockPermanentEvents = BlockPermanentEvents;
            ped.CanBeDraggedOutOfVehicle = CanBeDraggedOutVehicle;
            ped.CanBeKnockedOffBike = CanBeKnockedOffBike;
            ped.CanPlayGestures = CanPlayGestures;
            ped.AlwaysKeepTask = AlwaysKeepTask;
            ped.CanFlyThroughWindscreen = CanFlyThroughWindscreen;
            ped.CanBeTargetted = CanBeTargetted;
            ped.CanRagdoll = CanRagdoll;
            ped.CanSufferCriticalHits = CanSufferCriticalHits;
            ped.CanSwitchWeapons = CanSwitchWeapons;
            ped.DropsWeaponsOnDeath = DropsWeaponsOnDeath;
            ped.DrivingStyle = DrivingStyle;
            ped.DrivingSpeed = DrivingSpeed;
            ped.DiesInstantlyInWater = DiesInstantlyInWater;
            ped.DrownsInSinkingVehicle = DrownsInSinkingVehicle;
            ped.RelationshipGroup = RelationshipGroup;
            ped.NeverLeavesGroup = NeverLeavesGroup;
            ped.ShootRate = ShootRate;
            ped.FiringPattern = FiringPattern;
            ped.DrivingSpeed = DrivingSpeed;
            ped.Money = Money;
            ped.IsPriorityTargetForEnemies = IsPriorityTargetForEnemies;
            ped.IsEnemy = IsEnemy;
            ped.IsDucking = IsDucking;
            ped.MaxDrivingSpeed = MaxDrivingSpeed;
            ped.WetnessHeight = WetnessHeight;
        }
    }
}
