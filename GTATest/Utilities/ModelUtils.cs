using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTA;

namespace GTATest.Utilities
{
    public static class ModelUtils
    {
        /// <summary>
        /// Loads the specified model for usage.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public static bool Load(Model model)
        {
            if (!model.Request(250))
            {
                return false;
            }

            if (!model.IsLoaded || !model.IsInCdImage)
            {
                return false;
            }

            while (!model.IsLoaded) 
                Script.Wait(50);

            return true;
        }
    }
}
