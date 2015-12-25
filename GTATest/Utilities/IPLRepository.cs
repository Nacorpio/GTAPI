using System;
using System.Collections.Generic;
using GTA.Math;
using GTA.Native;

namespace GTATest.Utilities
{
    /// <summary>
    /// Represents a repository for storing IPLs, used for loading interiors, removing doors etc.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public static class IPLRepository
    {
        private readonly static Dictionary<string, IPL> Ipls = new Dictionary<string, IPL> {
            {"cluckin_bell_factory", new IPL(new Vector3(-72.68752f, 6253.72656f, 31.08991f), new List<string> {"CS1_02_cf_offmission"}, new List<string> {"CS1_02_cf_onmission1", "CS1_02_cf_onmission2", "CS1_02_cf_onmission3", "CS1_02_cf_onmission4"})},
            {"farm_house", new IPL(new Vector3(2447.9f, 4973.4f, 47.7f), new List<string> {"farmint_cap"}, new List<string> {"farmint"})},
            {"tankerexp", new IPL(new Vector3(1676.4154f, -1626.3705f, 111.4848f), new List<string> {"tankerexp_grp0"}, new List<string> { "tankerexp_grp2", "tankerexp_grp1", "tankerexp_grp3" })},
            {"coroner", new IPL(new Vector3(234.4f, -1355.6f, 40.5f), new List<string> {"Coroner_Int_off"}, new List<string> {"Coroner_Int_on"})}
        };

        /// <summary>
        /// Sets whether an interior at the specified coordinates is active.
        /// </summary>
        /// <param name="x">The X-coordinate.</param>
        /// <param name="y">The Y-coordinate.</param>
        /// <param name="z">The Z-coordinate.</param>
        /// <param name="toggle">true to enable, false to disable.</param>
        public static void SetInteriorToggle(short x, short y, short z, bool toggle)
        {
            var interiorId = Function.Call<int>(Hash.GET_INTERIOR_AT_COORDS, x, y, z);

            Function.Call(Hash._0x2CA429C029CCF247, interiorId);
            Function.Call(Hash.SET_INTERIOR_ACTIVE, interiorId, toggle);
            Function.Call(Hash.DISABLE_INTERIOR, interiorId, toggle);
        }

        /// <summary>
        /// Requests an IPL with the specified id.
        /// </summary>
        /// <param name="id">The unique identifier.</param>
        public static void RequestIPL(string id)
        {
            if (String.IsNullOrEmpty(id)) {
                return;
            }
            Function.Call(Hash.REQUEST_IPL, id);
        }

        /// <summary>
        /// Removes an IPL with the specified id.
        /// </summary>
        /// <param name="id">The unique identifier.</param>
        public static void RemoveIPL(string id)
        {
            if (String.IsNullOrEmpty(id)) {
                return;
            }
            Function.Call(Hash.REMOVE_IPL, id);
        }

        /// <summary>
        /// Executes an IPL with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public static void Execute(string id)
        {
            Get(id).Execute();
        }

        /// <summary>
        /// Gets an IPL with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public static IPL Get(string id)
        {
            return Ipls[id];
        }
    }
}
