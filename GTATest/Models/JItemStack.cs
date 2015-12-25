using GTATest.Items;
using Newtonsoft.Json;

namespace GTATest.Models
{
    /// <summary>
    /// Represents a JSON-serialized <see cref="ItemStack"/>.
    /// </summary>
    public struct JItemStack
    {
        /// <summary>
        /// Initializes an instance of the <see cref="JItemStack"/> structure.
        /// </summary>
        /// <param name="stack"></param>
        public JItemStack(ItemStack stack) : this(stack.Item, stack.Size)
        {}

        /// <summary>
        /// Initializes an instance of the <see cref="JItemStack"/> structure.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="size">The size.</param>
        public JItemStack(Item item, int size) : this(item.Id, size)
        {}

        /// <summary>
        /// Initializes an instance of the <see cref="JItemStack"/> structure.
        /// </summary>
        /// <param name="itemId">The item identifier.</param>
        /// <param name="size">The size.</param>
        public JItemStack(int itemId, int size)
        {
            ItemId = itemId;
            Size = size;
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

        /// <summary>
        /// Converts the specified <see cref="ItemStack"/> to a <see cref="JItemStack"/>.
        /// </summary>
        /// <param name="stack">The stack.</param>
        /// <returns></returns>
        public static JItemStack ToJItemStack(ItemStack stack)
        {
            return new JItemStack(stack);
        }

        /// <summary>
        /// Converts this <see cref="JItemStack"/> to a JSON-serialized string.
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
