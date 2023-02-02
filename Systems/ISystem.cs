namespace FeatureSystem.Systems
{
    public interface ISystem
    {
        void Initialize();

        void Destroy();
    }

    public interface ISystemUpdate
    {
        void Update();
    }
}