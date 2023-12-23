namespace CubivoxCore.Utils
{
    public class CMath
    {
        public static int mod(int x, int m)
        {
            return (x % m + m) % m;
        }
    }
}