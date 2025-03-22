

public interface IGameIistener

{

}

public interface IStartGameListener: IGameIistener
{
    void OnStartGame();
}

public interface IPauseGameListener: IGameIistener
{ 
    void OnPauseGame();
}

public interface IResumeGameListener: IGameIistener
{ 
    void OnResumeGame();
}

public interface IFinishGameListener: IGameIistener
{ 
    void OnFinishGame();
}

