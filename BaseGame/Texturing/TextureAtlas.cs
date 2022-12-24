using System;
using System.Collections;

namespace CubivoxCore.BaseGame.Texturing
{
    public interface TextureAtlas
    {
        List<AtlasTexture> GetTextures();
        int GetNumberOfRows();
        float GetXOffset(int id);
        float GetYOffset(int id);
        void RecalculateTextureAtlas();
        int GetTextureWidth();
        int GetTextureHeight();
        void SetTextureSize(int width, int height);
        void RegisterTexture(AtlasTexture texture, bool recalculateAtlas);
    }
}
