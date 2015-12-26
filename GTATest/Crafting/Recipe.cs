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
        /// Initializes an instance of the <see cref="Recipe"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="input">The input.</param>
        /// <param name="output">The output.</param>
        public Recipe(int id, ItemStack[] input, ItemStack[] output)
        {
            Id = id;
            Input = input;
            Output = output;
        }

        /// <summary>
        /// Determines whether the specified input is valid to craft this <see cref="Recipe"/>.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public bool IsValid(ItemStack[] input)
        {
            return input.Length == Input.Length && input.Select(i => Input.Contains(i)).All(i => i);
        }

        /// <summary>
        /// Gets the unique identifier of this <see cref="Recipe"/>.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Gets the input that is needed to craft this <see cref="Recipe"/>.
        /// </summary>
        public ItemStack[] Input { get; }

        /// <summary>
        /// Gets the output, which is received when crafting this <see cref="Recipe"/>.
        /// </summary>
        public ItemStack[] Output { get; }
    }
}
