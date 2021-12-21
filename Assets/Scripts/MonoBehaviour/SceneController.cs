using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private void OnEnable()
    {
        EventsBroker.OnPlayerLost += ToPause;
    }

    private void OnDisable()
    {
        EventsBroker.OnPlayerLost -= ToPause;
    }

    private GameState currentState = GameState.game;
    public enum GameState
    {
        pause,
        game,
    }

    private void Start()
    {
        UpdateGameState(GameState.game);
    }

    private void ToPause()
    {
        UpdateGameState(GameState.pause);
    }

    //Глобальная точка входа для работы с изменением состояния игры
    public void UpdateGameState(GameState state)
    {
        GameState prevGameState = currentState;
        currentState = state;

        switch (state)
        {
            case GameState.pause:
                Time.timeScale = 0;
                break;
            case GameState.game:
                Time.timeScale = 1;
                break;
            default:
                break;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
}
