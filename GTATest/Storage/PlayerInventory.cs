using GTA;

namespace GTATest.Storage
{
    public class PlayerInventory : Inventory
    {
        /// <summary>
        /// Initializes an instance of the <see cref="PlayerInventory"/> class.
        /// </summary>
        public PlayerInventory() : base("PlayerInventory")
        {
            Owner = Game.Player.Character;
        }
    }
}
