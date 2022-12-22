namespace CubivoxCore.Utils
{
    public class ControllerKeyUtils
    {
        public static readonly string CUBIVOX_NAME = "CUBIVOX";

        public static ControllerKey CubivoxControllerKey(string key)
        {
            return new ControllerKey(CUBIVOX_NAME, key);
        }
    }
}
