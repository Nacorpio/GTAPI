namespace GTATest
{
    /// <summary>
    /// An interface which should be implemented if the object can be saved to JSON.
    /// </summary>
    public interface ISaveable
    {
        /// <summary>
        /// Saves this ISaveable as a JSON file at the specified path.
        /// </summary>
        void Save();
    }
}
