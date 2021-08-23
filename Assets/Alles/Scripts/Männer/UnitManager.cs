using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance;
    private List<ScriptableUnit> Unitys;
    public BasePlayer1 SelectedPlayer;
    void Awake()
    {
        Instance = this;

        Unitys = Resources.LoadAll<ScriptableUnit>("Units").ToList();
    }
    public void SpawnEnemys()
    {
        var enemyCount = 1;

        for (int i = 0; i < enemyCount; i++)
        {
            var randomPrefab = GetRandomUnit<BasePlayer2>(Faction.Player2);
            var spawnedEnemy = Instantiate(randomPrefab);
            var randomSpawnTile = Grid.Instance.GetEnemyspawnTile();

            randomSpawnTile.SetUnit(spawnedEnemy);
        }
        GameManager.Instance.ChangeState(GameState.HeroesTurn);
    }
    public void SpawnHeroes()
    {
        var heroCount = 1;

        for(int i = 0; i < heroCount; i++)
        {
            var randomPrefab = GetRandomUnit<BasePlayer1>(Faction.Player1);
            var spawnedHero = Instantiate(randomPrefab);
            var randomSpawnTile = Grid.Instance.GetHerospawnTile();

            randomSpawnTile.SetUnit(spawnedHero);


        }

        GameManager.Instance.ChangeState(GameState.SpawnEnemys);
    }

    private T GetRandomUnit<T>(Faction faction) where T : BaseUnits
    {
        return (T)Unitys.Where(u => u.faction == faction).OrderBy(o => Random.value).First().UnitPrefab;
    }

    public void SetSelectedPlayer(BasePlayer1 Hero)
    {
        SelectedPlayer = Hero;
    }
}
