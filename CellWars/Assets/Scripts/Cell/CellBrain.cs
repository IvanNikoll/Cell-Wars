public class CellBrain
{
    private TickService _tickService;
    private Cell _cell;
    private IFighterChanger _fighterChanger;
    private float _timer;
    private float _addInterval = 1f;

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
}