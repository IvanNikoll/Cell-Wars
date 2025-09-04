using TMPro;
using UnityEngine;

public class LevelUIView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _playerFightersText;
    [SerializeField] private TextMeshProUGUI _NPCFightersText;

    public void UpdateText(int playerFighters,  int npcFighters)
    {
        _playerFightersText.text = playerFighters.ToString();
        _NPCFightersText.text = npcFighters.ToString();
    }
}
