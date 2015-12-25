using System.Collections.Generic;
using System.Linq;
using GTA;
using GTA.Math;

namespace GTATest.Utilities
{
    public class IPL
    {
        /// <summary>
        /// Initializes an instance of the IPL class.
        /// </summary>
        /// <param name="coords">The coordinates.</param>
        /// <param name="removals">The IPLs that are going to be removed.</param>
        /// <param name="requests">The IPLs that are going to be requested.</param>
        public IPL(Vector3 coords, IEnumerable<string> removals, IEnumerable<string> requests)
        {
            Coordinates = coords;
            QueuedRemovals = removals;
            QueuedRequests = requests;
        }

        /// <summary>
        /// Perform this IPL.
        /// </summary>
        public void Execute()
        {
            QueuedRemovals.ToList().ForEach(IPLRepository.RemoveIPL);
            QueuedRequests.ToList().ForEach(IPLRepository.RequestIPL);
        }

        /// <summary>
        /// Teleports the specified Ped to this IPL.
        /// </summary>
        /// <param name="ped">The ped.</param>
        public void TeleportTo(Ped ped)
        {
            if (ped == null) {
                return;
            }
            ped.Position = Coordinates;
        }

        /// <summary>
        /// Teleports the Player to this IPL.
        /// </summary>
        public void TeleportTo() => TeleportTo(Game.Player.Character);

        /// <summary>
        /// Gets the coordinates of this IPL.
        /// </summary>
        public Vector3 Coordinates { get; }

        /// <summary>
        /// Gets the IPLs that are going to be removed.
        /// </summary>
        public IEnumerable<string> QueuedRemovals { get; }
        
        /// <summary>
        /// Gets the IPLs that are going to be requested.
        /// </summary>
        public IEnumerable<string> QueuedRequests { get; }  
    }
}
