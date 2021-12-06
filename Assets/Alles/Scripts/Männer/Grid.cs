using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System;

public class Grid : MonoBehaviour
{
    public static Grid Instance;
    [SerializeField] private int width, height;
    public int[,] gridArray;

   // public Tile[,] tileArray;
    

    [SerializeField] private Tile GrassTile, MountainTile;
    
    [SerializeField] private Transform cam;


    private Dictionary<Vector2, Tile> tiles;

   public void Start()
    {
        Instance = this;
        gridArray = new int[width, height];

        
    }
   

    public void GenerateGrid()
    {
        tiles = new Dictionary<Vector2, Tile>();

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for(int y = 0; y < gridArray.GetLength(1); y++)
            {
                var randomTile = Random.Range(0, 6) == 3 ?  MountainTile : GrassTile;
                var spawnedTile = Instantiate(randomTile, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";
               // tileArray[x, y] = spawnedTile;
                
                spawnedTile.Init(x,y);


                tiles[new Vector2(x, y)] = spawnedTile;
                
               // int randomValue = Random.Range(1, 30);
               // SetValue(x, y, randomValue);
            }
        }

        cam.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, -10);
        GameManager.Instance.ChangeState(GameState.SpawnHeroes);
        MenuManager.Instance.BenjaminRedGreen();

    }

    public Tile GetHerospawnTile()
    {
        return tiles.Where(t => t.Key.x < width / 2 && t.Value.Walkable).OrderBy(t => Random.value).First().Value;

    }

    public Tile GetEnemyspawnTile()
    {
        return tiles.Where(t => t.Key.x > width / 2 && t.Value.Walkable).OrderBy(t => Random.value).First().Value;

    }

    public Tile GetTileAtPosition(Vector2 pos)
    {
        if(tiles.TryGetValue(pos, out var tile))
        {
            return tile;
        }

        return null;
    }
    
    public void SetValue(int x, int y, int value)
    {
        if ( x>= 0 && y >= 0 && x < width && y < height)
        {
            gridArray[x, y] = value;
        }
    }

    public int GetValue(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return gridArray[x, y];
        }
        else
        {
            return 0;
        }
    }
}
