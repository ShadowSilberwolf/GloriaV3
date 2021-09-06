using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System;

public class Grid 
{
    
    private int width, height;
    public int[,] gridArray;
    

    [SerializeField] private Tile GrassTile, MountainTile;
    
    [SerializeField] private Transform cam;


    private Dictionary<Vector2, Tile> tiles;

   public Grid(int Width, int Height)
    {
        width = Width;
        height = Height;
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

                
                spawnedTile.Init(x,y);


                tiles[new Vector2(x, y)] = spawnedTile;

                
            }
        }

        cam.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, -10);
        GameManager.Instance.ChangeState(GameState.SpawnHeroes);
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
    
}
