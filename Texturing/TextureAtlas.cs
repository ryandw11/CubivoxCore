using System.Collections.Generic;
using CubivoxCore.Attributes;

namespace CubivoxCore.Texturing
{
    /// <summary>
    /// Represents an atlas of textures. This is primarily used for the global voxel texture atlas.
    /// 
    /// <para>Textures are only available on the client and cannot be referenced on the server.</para>
    /// </summary>
    [ClientOnly]
    public interface TextureAtlas
    {
        /// <summary>
        /// The list of textures this atlas contains.
        /// </summary>
        /// <returns>The textures this atlas contains.</returns>
        List<AtlasTexture> GetTextures();

        /// <summary>
        /// Get the number of rows in the texture atlas.
        /// </summary>
        /// <returns>The number of rows in the texture atlas.</returns>
        int GetNumberOfRows();

        /// <summary>
        /// Get the x offset for a texture.
        /// </summary>
        /// <param name="id">The id of the atlas texture.</param>
        /// <returns>The x offset within the image.</returns>
        float GetXOffset(int id);

        /// <summary>
        /// Get the y offset for a texture.
        /// </summary>
        /// <param name="id">The id of the atlas texture.</param>
        /// <returns>The y offset within the image.</returns>
        float GetYOffset(int id);

        /// <summary>
        /// Recompute the texture atlas with any changes that may have been done.
        /// 
        /// <para>This will generate a new image for use.</para>
        /// </summary>
        void RecalculateTextureAtlas();

        /// <summary>
        /// Get the width of the texture atlas image.
        /// </summary>
        /// <returns>The width of the texture atlas image.</returns>
        int GetTextureWidth();

        /// <summary>
        /// The height of the texture atlas image.
        /// </summary>
        /// <returns>The height of the texture atlas image.</returns>
        int GetTextureHeight();

        /// <summary>
        /// Set the size each texture within the atlas should be.
        /// </summary>
        /// <param name="width">The width of each texture.</param>
        /// <param name="height">The height of each texture.</param>
        void SetTextureSize(int width, int height);

        /// <summary>
        /// Register a texture to the texture atlas.
        /// </summary>
        /// <param name="texture">The texture to add.</param>
        /// <param name="recalculateAtlas">If the texture atlas should be recalculated.</param>
        void RegisterTexture(AtlasTexture texture, bool recalculateAtlas);

        /// <summary>
        /// Create a new atlas texture.
        /// </summary>
        /// <param name="location">The location of the texture image.</param>
        /// <returns></returns>
        AtlasTexture CreateAtlasTexture(string location);
    }
}
