using UnityEngine;
using UnityEngine.UI;

public class MultySlider : MonoBehaviour
{
    [SerializeField] private Image _playerFill;
    [SerializeField] private Image _enemyFill;
    [SerializeField] private Image _neutralFill;
    [SerializeField] private int _maxValue;

    public void Show(int player, int enemy, int neutral)
    {
        _maxValue = player + enemy + neutral;
        float playerValue = (float)player / _maxValue;
        float enemyValue = (float)enemy / _maxValue;
        float neutralValue = (float)neutral / _maxValue;

        _playerFill.fillAmount = playerValue;
        _neutralFill.fillAmount = playerValue + neutralValue;
        _enemyFill.fillAmount = playerValue + neutralValue + enemyValue;
    }
}
