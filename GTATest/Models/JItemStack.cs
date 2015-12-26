using GTATest.Items;
using GTATest.Utilities;
using Newtonsoft.Json;

namespace GTATest.Models
{
    /// <summary>
    /// Represents a JSON-serialized <see cref="ItemStack"/>.
    /// </summary>
    public class JItemStack : JsonModel<ItemStack>
    {
        /// <summary>
        /// Initializes an instance of the <see cref="JItemStack"/> class.
        /// </summary>
        /// <param name="stack"></param>
        public JItemStack(ItemStack stack)
        {
            ItemId = stack.Item.Id;
            Size = stack.Size;
        }

        /// <summary>
        /// Creates an instance of this <see cref="JsonModel{T}"/>.
        /// </summary>
        public override ItemStack Create()
        {
            return new ItemStack(ItemRepository.Get(ItemId), Size);
        }

        /// <summary>
        /// Gets the unique item identifier for this <see cref="JItemStack"/>.
        /// </summary>
        [JsonProperty("itemId", Order=0)]
        public int ItemId { get; }

        /// <summary>
        /// Gets the size of this <see cref="JItemStack"/>.
        /// </summary>
        [JsonProperty("size", Order=1)]
        public int Size { get; }
    }
}