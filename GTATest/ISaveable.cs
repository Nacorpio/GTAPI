using GTATest.Models;

namespace GTATest
{
    /// <summary>
    /// An interface which should be implemented if the object can be saved to JSON.
    /// </summary>
    public interface ISaveable<T, U> where T : JSerializable<T, U>
    {
        /// <summary>
        /// Saves this <see cref="ISaveable(T, U)"/>.
        /// </summary>
        void Save();

        /// <summary>
        /// Gets the model of this <see cref="ISaveable(T, U)"/>.
        /// </summary>
        /// <returns></returns>
        T GetModel();
    }
}
