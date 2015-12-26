using GTATest.Items;
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
        /// Deserializes the specified JSON-formatted string, and converts it to a <see cref="JItemStack"/>.
        /// </summary>
        /// <param name="json">The JSON string.</param>
        /// <returns></returns>
        public static JItemStack ToObject(string json)
        {
            return (JItemStack) JsonConvert.DeserializeObject(json);
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