using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance;
    private List<ScriptableUnit> Unitys;
    public BaseUnits SelectedPlayer;
    [SerializeField] private int Spieler1AnzahlArmee, Spieler2AnzahlArmee;
    public BasePlayer2[] gegner;
    public BasePlayer1[] heroes;

    void Awake()
    {
        Instance = this;
        gegner = new BasePlayer2[Spieler2AnzahlArmee];
        heroes = new BasePlayer1[Spieler1AnzahlArmee];

        Unitys = Resources.LoadAll<ScriptableUnit>("Units").ToList();
    }
    public void SpawnEnemys()
    {
        
        for (int i = 0; i < Spieler2AnzahlArmee; i++)
        {
            var randomPrefab = GetRandomUnit<BasePlayer2>(Faction.Player2);
            var spawnedEnemy = Instantiate(randomPrefab);
            var randomSpawnTile = Grid.Instance.GetEnemyspawnTile();

            randomSpawnTile.SetUnit(spawnedEnemy);
            gegner[i] = spawnedEnemy;
        }
        GameManager.Instance.ChangeState(GameState.HeroesTurn);
    }
    public void SpawnHeroes()
    {
        

        for(int i = 0; i < Spieler1AnzahlArmee; i++)
        {
            var randomPrefab = GetRandomUnit<BasePlayer1>(Faction.Player1);
            var spawnedHero = Instantiate(randomPrefab);
            var randomSpawnTile = Grid.Instance.GetHerospawnTile();

            randomSpawnTile.SetUnit(spawnedHero);
            heroes[i] = spawnedHero;

        }

        GameManager.Instance.ChangeState(GameState.SpawnEnemys);
    }

    private T GetRandomUnit<T>(Faction faction) where T : BaseUnits
    {
        return (T)Unitys.Where(u => u.faction == faction).OrderBy(o => Random.value).First().UnitPrefab;
    }

    public void SetSelectedPlayer(BaseUnits Hero)
    {
        SelectedPlayer = Hero;
        MenuManager.Instance.ShowselectedHero(Hero);
    }

    public int PrüfeHeroAnzahl()
    {
        int h = 0;
        int e = 0;
        int y = 0;
        for(int i = 0; i < gegner.Length; i++)
        {
            if(gegner[i]!= null)
            {
                e++;
            }
        }
        for (int i = 0; i < heroes.Length; i++)
        {
            if (heroes[i] != null)
            {
                h++;
            }
        }
        if(e == 0)
        {
            y =  1; 
        }
        else if(h == 0)
        {
            y = 2; 
        }
        Debug.Log("Boobs Heroes:"+ h + " (.)(.):" + e );

        return y;
    }


}
