
namespace ShootEmUp
{
    public interface IGameIistener

    {

    }

    public interface IStartGameListener : IGameIistener
    {
        void OnStartGame();
    }

    public interface IPauseGameListener : IGameIistener
    {
        void OnPauseGame();
    }

    public interface IResumeGameListener : IGameIistener
    {
        void OnResumeGame();
    }

    public interface IFinishGameListener : IGameIistener
    {
        void OnFinishGame();
    }

    public interface IUpdateGameListener : IGameIistener
    { 
        void OnUpdate(float deltaTime);
    }

    public interface IFixedUpdateGameListener : IGameIistener
    {
        void OnFixedUpdate(float fixedDeltaTime);
    }

    public interface ILateUpdateGameListener : IGameIistener
    {
        void OnLateUpdate(float deltaTime);
    }
}