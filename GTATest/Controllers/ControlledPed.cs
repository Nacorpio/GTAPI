using System;
using GTA;
using GTA.Native;
using GTATest.Models;
using GTATest.Storage;

namespace GTATest.Controllers
{
    public class ControlledPed : ControlledEntity
    {
        /// <summary>
        /// Handles all the events of the <see cref="ControlledPed"/> class.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        public delegate void ControlledPedEventHandler(object sender, EventArgs e);

        private bool _isInVehicle, _isInCombat, _isDiving, _isInMeleeCombat, _isClimbing, _isFalling, _isDucking, _isSprinting, _isShooting, _isWalking, _isIdle, _isProne, _isAimingFromCover, _isInTrain, _isReloading, _isGettingUp;

        #region Events

        /// <summary>
        /// Raised when this ControlledPed has entered a Vehicle.
        /// </summary>
        public event ControlledPedEventHandler EnterVehicle;

        /// <summary>
        /// Raised when this ControlledPed has left a Vehicle.
        /// </summary>
        public event ControlledPedEventHandler LeaveVehicle;

        /// <summary>
        /// Raised when this ControlledPed enters a combat.
        /// </summary>
        public event ControlledPedEventHandler EnterCombat;

        /// <summary>
        /// Raised when this ControlledPed leaves a combat.
        /// </summary>
        public event ControlledPedEventHandler LeaveCombat;

        /// <summary>
        /// Raised when this ControlledPed dives.
        /// </summary>
        public event ControlledPedEventHandler Dive;

        /// <summary>
        /// Raised when this ControlledPed enters a melee combat.
        /// </summary>
        public event ControlledPedEventHandler EnterMeleeCombat;

        /// <summary>
        /// Raised when this ControlledPed leaves a melee combat.
        /// </summary>
        public event ControlledPedEventHandler LeaveMeleeCombat;

        /// <summary>
        /// Raised when this ControlledPed climbs.
        /// </summary>
        public event ControlledPedEventHandler Climbing;

        /// <summary>
        /// Raised when this ControlledPed falls.
        /// </summary>
        public event ControlledPedEventHandler Fall;

        /// <summary>
        /// Raised when this ControlledPed ducks.
        /// </summary>
        public event ControlledPedEventHandler Duck;

        /// <summary>
        /// Raised when this ControlledPed sprints.
        /// </summary>
        public event ControlledPedEventHandler Sprint;

        /// <summary>
        /// Raised when this ControlledPed shoots.
        /// </summary>
        public event ControlledPedEventHandler Shoot;

        /// <summary>
        /// Raised when this ControlledPed walks.
        /// </summary>
        public event ControlledPedEventHandler Walk;

        /// <summary>
        /// Raised when this ControlledPed idles.
        /// </summary>
        public event ControlledPedEventHandler Idle;

        /// <summary>
        /// Raised when this ControlledPed prones.
        /// </summary>
        public event ControlledPedEventHandler Prone;

        /// <summary>
        /// Raised when this ControlledPed aims from a cover.
        /// </summary>
        public event ControlledPedEventHandler AimFromCover;

        /// <summary>
        /// Raised when this ControlledPed enters a train.
        /// </summary>
        public event ControlledPedEventHandler EnterTrain;

        /// <summary>
        /// Raised when this ControlledPed reloads.
        /// </summary>
        public event ControlledPedEventHandler Reload;

        /// <summary>
        /// Raised wehn this ControlledPed gets up.
        /// </summary>
        public event ControlledPedEventHandler GetUp;

        #endregion

        /// <summary>
        /// Initializes an instance of the <see cref="ControlledPed"/> class.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public ControlledPed(Entity entity) : base(entity)
        {
            Inventory = new Inventory("Inventory") {
                Owner = Entity
            };
        }

        /// <summary>
        /// Gets the model of this <see cref="ControlledPed"/>.
        /// </summary>
        /// <returns></returns>
        public JPed GetModel()
        {
            if (((Ped) Entity) != null)
                return new JPed((Ped) Entity);
            return null;
        }

        /// <summary>
        /// Gets the inventory of this <see cref="ControlledPed"/>.
        /// </summary>
        public Inventory Inventory { get; protected set; }

        /// <summary>
        /// Gets the <see cref="Ped"/> that has been controlled originally.
        /// </summary>
        public Ped Ped => (Ped) Entity;

        #region Native Functions

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

        #endregion

        /// <summary>
        /// Updates the frame of this <see cref="ControlledPed"/>.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        public override void OnTick(object sender, EventArgs e)
        {
            base.OnTick(sender, e);

            if (Ped.IsGettingUp != _isGettingUp) {
                _isGettingUp = Ped.IsGettingUp;
                GetUp?.Invoke(sender, e);
            }

            if (Ped.IsReloading != _isReloading) {
                _isReloading = Ped.IsReloading;
                Reload?.Invoke(sender, e);
            }

            if (Ped.IsInTrain != _isInTrain) {
                _isInTrain = Ped.IsInTrain;
                EnterTrain?.Invoke(sender, e);
            }

            if (Ped.IsAimingFromCover != _isAimingFromCover) {
                _isAimingFromCover = Ped.IsAimingFromCover;
                AimFromCover?.Invoke(sender, e);
            }

            if (Ped.IsProne != _isProne) {
                _isProne = Ped.IsProne;
                Prone?.Invoke(sender, e);
            }

            if (Ped.IsIdle != _isIdle) {
                _isIdle = Ped.IsIdle;
                Idle?.Invoke(sender, e);
            }

            if (Ped.IsWalking != _isWalking) {
                _isWalking = Ped.IsWalking;
                Walk?.Invoke(sender, e);
            }

            if (Ped.IsShooting != _isShooting) {
                _isShooting = Ped.IsShooting;
                Shoot?.Invoke(sender, e);
            }

            if (Ped.IsSprinting != _isSprinting) {
                _isSprinting = Ped.IsSprinting;
                Sprint?.Invoke(sender, e);
            }

            if (Ped.IsDucking != _isDucking) {
                _isDucking = Ped.IsDucking;
                Duck?.Invoke(sender, e);
            }

            if (Ped.IsFalling != _isFalling) {
                _isFalling = Ped.IsFalling;
                Fall?.Invoke(sender, e);
            }

            if (Ped.IsClimbing != _isClimbing) {
                _isClimbing = Ped.IsClimbing;
                Climbing?.Invoke(sender, e);
            }

            if (Ped.IsInVehicle() != _isInVehicle) {
                _isInVehicle = Ped.IsInVehicle();
                if (_isInVehicle) {
                    EnterVehicle?.Invoke(sender, e);
                } else {
                    LeaveVehicle?.Invoke(sender, e);
                }
            }

            if (Ped.IsInCombat != _isInCombat) {
                _isInCombat = Ped.IsInCombat;
                if (_isInCombat) {
                    EnterCombat?.Invoke(sender, e);
                } else {
                    LeaveCombat?.Invoke(sender, e);       
                }
            }

            if (Ped.IsInMeleeCombat != _isInMeleeCombat) {
                _isInMeleeCombat = Ped.IsInMeleeCombat;
                if (_isInMeleeCombat) {
                    EnterMeleeCombat?.Invoke(sender, e);
                } else {
                    LeaveMeleeCombat?.Invoke(sender, e);
                }
            }

            if (Ped.IsDiving != _isDiving) {
                _isDiving = Ped.IsDiving;
                Dive?.Invoke(sender, e);
            }
        }
    }
}
