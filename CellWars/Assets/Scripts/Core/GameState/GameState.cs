public abstract class GameState 
{
    public bool CanClick { get; protected set; }
    public bool CanEmit { get; protected set; }
    public virtual void Enter() { }
    public virtual void Exit() { }
}

public class LoadingState : GameState
{
    public LoadingState()
    {
        CanClick = false;
        CanEmit = false;
    }

    public override void Enter()
    {

    }
    public override void Exit() { }
}

public class CountDownState : GameState
{
    private TickService _tickService;
    private const float COUNTDOWNINTERVAL = 15f;
    private float _timer;
    public CountDownState(TickService tickService)
    {
        _tickService = tickService;
        CanClick = false;
        CanEmit = false;
        Subscribe();
    }

    private void Subscribe()
    {
        _tickService.OnTick += Tick;
    }

    private void Tick(float deltaTime)
    {
        _timer += deltaTime;
        if (_timer > COUNTDOWNINTERVAL)
        {
            _timer = 0;
            GameStateController.Instance.ChangeState(new StartState());
        }
    }

    public override void Enter()
    {

    }

    public override void Exit()
    {
        Unsubscribe();
    }

    private void Unsubscribe()
    {
        _tickService.OnTick -= Tick;
    }
}

public class StartState : GameState
{
    public StartState()
    {
        CanClick = true;
        CanEmit = true;
    }

    public override void Enter()
    {

    }

    public override void Exit()
    {
    }
}

public class WinState :GameState
{
    public void Enter()
    {

    }

    public void Exit()
    {
    }
}

public class LoseState : GameState
{
    public void Enter()
    {

    }

    public void Exit()
    {
    }
}

