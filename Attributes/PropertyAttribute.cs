namespace CubivoxCore.Attributes
{
    public interface PropertyAttribute<StoredValue>
    {
        StoredValue GetValue();
    }
}
