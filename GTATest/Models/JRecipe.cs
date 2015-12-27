using System;
using System.Collections.Generic;
using System.Linq;
using GTATest.Crafting;
using Newtonsoft.Json;

namespace GTATest.Models
{
    /// <summary>
    /// Represents a JSON-serialized <see cref="Recipe"/>.
    /// </summary>
    public class JRecipe : JsonModel<Recipe>
    {
        /// <summary>
        /// Initializes an instance of the JRecipe class.
        /// </summary>
        /// <param name="recipe">The recipe.</param>
        public JRecipe(Recipe recipe)
        {
            Id = recipe.Id;
            Input = recipe.Input.Select(stack => stack.ToModel());
            Output = recipe.Output.Select(stack => stack.ToModel());
        }

        /// <summary>
        /// Creates an instance of this <see cref="JRecipe"/>.
        /// </summary>
        public override Recipe Create()
        {
            return new Recipe(
                Id,
                Input.Select(stack => stack.Create()).ToArray(),
                Output.Select(stack => stack.Create()).ToArray()
            );
        }

        /// <summary>
        /// Gets the unique identifier of this JRecipe.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; }

        /// <summary>
        /// Gets the input which is needed to craft this JRecipe.
        /// </summary>
        [JsonProperty("input")]
        public IEnumerable<JItemStack> Input { get; }

        /// <summary>
        /// Gets the output which is returned when crafting this JRecipe.
        /// </summary>
        [JsonProperty("output")]
        public IEnumerable<JItemStack> Output { get; }
    }
}
