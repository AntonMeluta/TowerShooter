using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : Singleton<SceneController>
{
    private GameState currentState = GameState.game;
    public enum GameState
    {
        pause,
        game,
        loss
    }

    private void Start()
    {
        UpdateGameState(GameState.game);
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
            case GameState.loss:
                Time.timeScale = 0;
                break;
            default:
                break;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            RestartGame();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
}
