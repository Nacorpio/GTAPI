using GTATest.Items;
using Newtonsoft.Json;

namespace GTATest.Models
{
    /// <summary>
    /// Represents a JSON-serialized <see cref="ItemStack"/>.
    /// </summary>
    public class JItemStack : JSerializable<JItemStack, ItemStack>
    {
        /// <summary>
        /// Initializes an instance of the <see cref="JItemStack"/> class.
        /// </summary>
        /// <param name="stack"></param>
        public JItemStack(ItemStack stack) : base(stack)
        {
            ItemId = stack.Item.Id;
            Size = stack.Size;
        }

        /// <summary>
        /// Gets the unique item identifier for this <see cref="JItemStack"/>.
        /// </summary>
        [JsonProperty("itemId")]
        public int ItemId { get; }

        /// <summary>
        /// Gets the size of this <see cref="JItemStack"/>.
        /// </summary>
        [JsonProperty("size")]
        public int Size { get; }
    }
}
