using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{


    public static GameManager Instance;
    public GameState GameState;
    

    public static event Action<GameState> OnGameStateChanged;

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
                Grid.Instance.GenerateGrid();
                break;
            case GameState.SpawnHeroes:
                UnitManager.Instance.SpawnHeroes();
                break;
            case GameState.SpawnEnemys:
                UnitManager.Instance.SpawnEnemys();
                break;
            case GameState.HeroesTurn:
                
                break;
            case GameState.EnemysTurn:
                
                break;
                 default:
                  throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
       
        OnGameStateChanged?.Invoke(newState);

       
    }
}

public enum GameState
{
    GenerateGrid = 0,
    SpawnHeroes = 1,
    SpawnEnemys = 2,
    HeroesTurn = 3,
    EnemysTurn = 4
}
