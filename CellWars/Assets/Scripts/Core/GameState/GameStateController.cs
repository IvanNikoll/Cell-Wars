using System;
using UnityEngine;

public class GameStateController : MonoBehaviour
{
    [SerializeField] private LevelUIController _levelUIController;
    public bool CanClick {  get; private set; }
    public bool CanEmit {  get; private set; }
    public bool CanUpdateUI {  get; private set; }
    public event Action<GameState> GameStateChanged;
    public static GameStateController Instance {  get; private set; }
    public GameState CurrentState { get; private set; }
    private bool _isLevelOver = false;

    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        GameStateChanged += UpdateStateSettings;
        _levelUIController.FightersDestroyed += OnFightersDestroyed;
        ChangeState(new LoadingState());
    }

    private void UpdateStateSettings(GameState newState)
    {
        CanClick = newState.CanClick;
        CanEmit = newState.CanEmit;
        Debug.Log("Change settings to " + newState + ". CanClick=" + CanClick + " CanEmit =" + CanEmit);
    }

    private void OnFightersDestroyed(OwnerEnum loser)
    {
        if (_isLevelOver)
            return;
        _isLevelOver = true;
        if (loser == OwnerEnum.Player2)
            ChangeState(new WinState());
        if (loser == OwnerEnum.Player1)
            ChangeState(new LoseState());
        
    }

    public void ChangeState(GameState newState)
    {
        GameStateChanged?.Invoke(newState);
        Debug.Log("Changing state to " + newState);
        CurrentState?.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}
