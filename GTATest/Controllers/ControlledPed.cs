using System;
using GTA;
using GTA.Native;

namespace GTATest.Controllers
{
    public class ControlledPed : ControlledEntity
    {
        /// <summary>
        /// Initializes an instance of the <see cref="ControlledPed"/> class.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public ControlledPed(Entity entity) : base(entity)
        {
        }

        /// <summary>
        /// Gets the <see cref="Ped"/> that has been controlled originally.
        /// </summary>
        public Ped Ped => (Ped) Entity;

        /// <summary>
        /// Sets whether this <see cref="ControlledPed"/> has bound ankles.
        /// </summary>
        /// <param name="toggle">The value.</param>
        public void SetBoundAnkles(bool toggle)
        {
            Function.Call(Hash.SET_ENABLE_BOUND_ANKLES, Ped, toggle);
        }

        /// <summary>
        /// Sets whether this <see cref="ControlledPed"/> has handcuffs.
        /// </summary>
        /// <param name="toggle">The value.</param>
        public void SetHandcuffs(bool toggle)
        {
            Function.Call(Hash.SET_ENABLE_HANDCUFFS, Ped, toggle);
        }

        /// <summary>
        /// Sets or gets whether this <see cref="ControlledPed"/> is a cop.
        /// </summary>
        public bool IsCop
        {
            set { Function.Call(Hash.SET_PED_AS_COP, Ped, value); }
        }

        /// <summary>
        /// Gets whether this <see cref="ControlledPed"/> is hanging on to a vehicle.
        /// </summary>
        public bool IsHangingOnToVehicle => Function.Call<bool>((Hash) 0x1C86D8AEF8254B78, Ped);

        /// <summary>
        /// Gets or sets the alertness of this <see cref="ControlledPed"/>.
        /// </summary>
        public float Alertness
        {
            get { return Function.Call<float>(Hash.GET_PED_ALERTNESS, Ped); }
            set { Function.Call(Hash.SET_PED_ALERTNESS, Ped, value); }
        }

        /// <summary>
        /// Sets the maximum angle of the visual field of this <see cref="ControlledPed"/>.
        /// </summary>
        public float VisualFieldMaxAngle
        {
            set { Function.Call(Hash.SET_PED_VISUAL_FIELD_MAX_ANGLE, Ped, value); }
        }

        /// <summary>
        /// Sets the minimum angle of the visual field of this <see cref="ControlledPed"/>.
        /// </summary>
        public float VisualFieldMinAngle
        {
            set { Function.Call(Hash.SET_PED_VISUAL_FIELD_MIN_ANGLE, Ped, value); }
        }

        /// <summary>
        /// Sets the hearing range of this <see cref="ControlledPed"/>.
        /// </summary>
        public float HearingRange
        {
            set { Function.Call(Hash.SET_PED_HEARING_RANGE, Ped, value); }
        }

        /// <summary>
        /// Sets the seeing range of this <see cref="ControlledPed"/>.
        /// </summary>
        public float SeeingRange
        {
            set { Function.Call(Hash.SET_PED_SEEING_RANGE, Ped, value); }
        }

        /// <summary>
        /// Gets the bone that was last damaged on this <see cref="ControlledPed"/>.
        /// </summary>
        /// <returns>-1 if there is no bone that has been damaged.</returns>
        public int GetLastDamagedBone()
        {
            var o1 = new OutputArgument();
            var value = Function.Call<bool>(Hash.GET_PED_LAST_DAMAGE_BONE, Ped, o1);

            if (value) {
                return o1.GetResult<int>();
            }

            return -1;
        }

        /// <summary>
        /// Called every tick this <see cref="ControlledPed"/> is within a Vehicle.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="vehicle">The vehicle.</param>
        protected virtual void OnInsideVehicle(object sender, Vehicle vehicle)
        {}

        /// <summary>
        /// Called every tick this <see cref="ControlledPed"/> is in combat.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        protected virtual void OnInCombat(object sender, EventArgs e)
        {
            if (Ped.IsInMeleeCombat) {
                OnInMeleeCombat(sender, e);
            }
        }

        /// <summary>
        /// Called every tick this <see cref="ControlledPed"/> is in water.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        protected override void OnInWater(object sender, EventArgs e)
        {
            base.OnInWater(sender, e);
            if (Ped.IsDiving) {
                OnDiving(sender, e);        
            }
        }

        /// <summary>
        /// Called every tick this <see cref="ControlledPed"/> is diving.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        protected virtual void OnDiving(object sender, EventArgs e)
        {}

        /// <summary>
        /// Called every tick this <see cref="ControlledPed"/> is in a melee combat.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        protected virtual void OnInMeleeCombat(object sender, EventArgs e)
        {}

        /// <summary>
        /// Updates the frame of this <see cref="ControlledPed"/>.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        public override void OnTick(object sender, EventArgs e)
        {
            base.OnTick(sender, e);

            if (Ped.IsInVehicle()) {
                OnInsideVehicle(sender, Ped.CurrentVehicle);
            }

            if (Ped.IsInCombat) {
                OnInCombat(sender, e);
            }
        }
    }
}
