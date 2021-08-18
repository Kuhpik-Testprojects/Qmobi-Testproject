using Source.Scripts.Configs;

namespace Source.Scripts.Data.Interfaces
{
    public interface ILevelConfigProvider
    {
        LevelConfig Config { get; }
        void SetCurrentConfig(LevelConfig config);
    }
}