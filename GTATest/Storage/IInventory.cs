using System.Collections.Generic;
using GTATest.Items;

namespace GTATest.Storage
{
    /// <summary>
    /// Represents a Storage, containing item stacks.
    /// </summary>
    public interface IInventory
    {
        /// <summary>
        /// Gets the name of this IStorage.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the items of this IStorage.
        /// </summary>
        /// <returns></returns>
        List<ItemStack> Items { get; }
    }
}
