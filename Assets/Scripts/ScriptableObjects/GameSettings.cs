using UnityEngine;

[CreateAssetMenu(fileName = "Game Settings", menuName = "Game/Settings", order = 101)]
public class GameSettings : ScriptableObject
{
    [SerializeField]
    private DifficultyGame difficultyGame;
    
    public DifficultyGame DifficultyGame => difficultyGame;
}
