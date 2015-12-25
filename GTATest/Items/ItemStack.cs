using GTATest.Models;
using GTATest.Storage;

namespace GTATest.Items
{
    /// <summary>
    /// Represents a stack of items.
    /// </summary>
    public class ItemStack
    {
        /// <summary>
        /// Initializes an instance of the <see cref="ItemStack"/> class.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="size">The size.</param>
        public ItemStack(Item item, int size)
        {
            Item = item;
            Size = size;
        }

        #region Equality

        protected bool Equals(ItemStack other)
        {
            return Equals(Item, other.Item) && Size == other.Size;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <returns>
        /// true if the specified object  is equal to the current object; otherwise, false.
        /// </returns>
        /// <param name="obj">The object to compare with the current object. </param>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            if (obj.GetType() != this.GetType()) {
                return false;
            }
            return Equals((ItemStack) obj);
        }

        /// <summary>
        /// Serves as the default hash function. 
        /// </summary>
        /// <returns>
        /// A hash code for the current object.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked {
                return ((Item?.GetHashCode() ?? 0)*397) ^ Size;
            }
        }

        #endregion

        #region Operators

        public static bool operator ==(ItemStack one, ItemStack two)
        {
            if (one == null || two == null) {
                return false;
            }
            return one.Item.Id == two.Item.Id && one.Size == two.Size;
        }

        public static bool operator !=(ItemStack one, ItemStack two)
        {
            return !(one == two);
        }

        public static ItemStack operator %(ItemStack one, ItemStack two)
        {
            return one.Item.Id != two.Item.Id ? null : new ItemStack(one.Item, one.Size%two.Size);
        }

        public static ItemStack operator +(ItemStack one, ItemStack two)
        {
            return one.Item.Id != two.Item.Id ? null : new ItemStack(one.Item, one.Size + two.Size);
        }

        public static ItemStack operator -(ItemStack one, ItemStack two)
        {
            return one.Item.Id != two.Item.Id ? null : new ItemStack(one.Item, one.Size - two.Size);
        }

        #endregion

        /// <summary>
        /// Gets the item of this <see cref="ItemStack"/>.
        /// </summary>
        public Item Item { get; }

        /// <summary>
        /// Gets the size of this <see cref="ItemStack"/>.
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Gets or sets the parent inventory of this <see cref="ItemStack"/>.
        /// </summary>
        public Inventory Parent { get; set; }

        /// <summary>
        /// Converts this <see cref="ItemStack"/> to a serializable JSON model.
        /// </summary>
        /// <returns></returns>
        public JItemStack ToModel()
        {
            return new JItemStack(this);
        }
    }
}
