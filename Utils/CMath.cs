namespace CubivoxCore.Utils
{
    /// <summary>
    /// Cubivox math utility class.
    /// </summary>
    public sealed class CMath
    {
        public static int mod(int x, int m)
        {
            return (x % m + m) % m;
        }
    }
}