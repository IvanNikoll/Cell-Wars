using UnityEngine;
using Zenject;

public class LevelConfigProvider : MonoBehaviour
{
    [System.Serializable]
    public struct Levels
    {
        public LevelEnum Level;
        public LevelConfig levelConfig;
    }

    [Inject] private LevelContext _context;
    [SerializeField] private Levels[] _levels;

    public void GetLevelConfig(LevelEnum levelEnum)
    {
        foreach (var level in _levels)
        {
            if(level.Level == levelEnum)
            {
                _context.SetLevelConfig(level.levelConfig);
            }
        }
    }
}
