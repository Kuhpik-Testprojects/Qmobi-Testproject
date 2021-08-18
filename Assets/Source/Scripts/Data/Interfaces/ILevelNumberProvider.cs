namespace Source.Scripts.Data.Interfaces
{
    public interface ILevelNumberProvider
    {
        int Level { get; }
        int UniqueLevelsPassed { get; }
    }
}