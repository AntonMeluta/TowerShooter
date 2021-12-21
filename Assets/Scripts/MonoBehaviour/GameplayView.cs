using UnityEngine;
using UnityEngine.UI;

public class GameplayView : MonoBehaviour
{
    [SerializeField]
    private Text textWave;
    [SerializeField]
    private GameObject LossWindow;

    private void OnEnable()
    {
        EventsBroker.OnPlayerToWar += WaveTextEnable;
        EventsBroker.OnPlayerLost += PlayerLost;
        EventsBroker.OnWave += UpdateValueWave;
    }

    private void OnDisable()
    {
        EventsBroker.OnPlayerToWar -= WaveTextEnable;
        EventsBroker.OnPlayerLost -= PlayerLost;
        EventsBroker.OnWave -= UpdateValueWave;
    }

    private void WaveTextEnable()
    {
        textWave.enabled = true;
    }

    private void PlayerLost()
    {
        LossWindow.SetActive(true);
    }

    private void UpdateValueWave(int value)
    {
        textWave.text = "Wave: " + value;
    }

}
