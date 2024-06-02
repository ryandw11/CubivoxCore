using CubivoxCore.Players;

namespace CubivoxCore.Entities
{
    /// <summary>
    /// Represents an object that moves within the Cubivox game.
    /// 
    /// <para>Common enties are <see cref="Player"/>s and AI characters.</para>
    /// </summary>
    public interface Entity : Identifiable
    {
        /// <summary>
        /// Get the file path for the model of the entity.
        /// </summary>
        /// <returns>The file path for the model of the entity.</returns>
        string GetModel();

        /// <summary>
        /// Get file path for the texture of the entity.
        /// </summary>
        /// <returns>The file path for the texture of the entity.</returns>
        string GetTexture();
    }
}
