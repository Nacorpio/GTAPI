using System.Linq;
using GTATest.Items;

namespace GTATest.Crafting
{
    /// <summary>
    /// Represents a craftable Recipe.
    /// </summary>
    public class Recipe
    {
        /// <summary>
        /// Initializes an instance of the Recipe class.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="output">The output.</param>
        public Recipe(ItemStack[] input, ItemStack[] output)
        {
            Input = input;
            Output = output;
        }

        /// <summary>
        /// Determines whether the specified input is valid to craft this Recipe.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public bool IsValid(ItemStack[] input)
        {
            return input.Length == Input.Length && input.Select(i => Input.Contains(i)).All(i => i);
        }

        /// <summary>
        /// Gets the input that is needed to craft this Recipe.
        /// </summary>
        public ItemStack[] Input { get; }

        /// <summary>
        /// Gets the output, which is received when crafting this Recipe.
        /// </summary>
        public ItemStack[] Output { get; }
    }
}
