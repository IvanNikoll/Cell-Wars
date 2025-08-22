/// <summary>
/// This class is used for producing fighters
/// </summary>
public class CellBrain
{
    private IFighterChanger _fighterChanger;
    private TickService _tickService;
    private Cell _cell;

    private float _addInterval;
    private float _timer;

    public CellBrain(Cell cell, TickService tickService, float addInterval)
    {
        _cell = cell;
        _fighterChanger = cell;
        _tickService = tickService;
        _addInterval = addInterval;
        Subscribe();
    }

    private void Subscribe()
    {
        _tickService.OnTick += Tick;
    }

    private void Tick(float deltaTime)
    {
        _timer += deltaTime;
        if (_timer > _addInterval)
        {
            ProduceFighter();
            _timer = 0f;
        }
    }

    private void ProduceFighter()
    {
        if(_cell.Fighters<_cell.Limit)
            _fighterChanger.AddFighter();
    }

    private void OnDisable()
    {
        Unsubscribe();
    }

    private void Unsubscribe()
    {
        _tickService.OnTick -= Tick;
    }
}