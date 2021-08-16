using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMann : MonoBehaviour
{
    public static GameMann Instance;
    public GameState GameState;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ChangeState(GameState.GenerateGrid);
    }

    public void ChangeState(GameState newState)
    {
        GameState = newState;
        switch (newState)
        {
            case GameState.GenerateGrid:
                break;
            case GameState.SpawnHeroes:
                break;
            case GameState.SpawnEnemys:
                break;
            case GameState.HeroesTurn:
                break;
            case GameState.EnemysTurn:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }

    public enum GameState
    {

    }
}
