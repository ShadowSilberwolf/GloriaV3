using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] private int width, height;

    [SerializeField] private Tile GrassTile, MountainTile;
    //[SerializeField] private Tile baseTile;
    [SerializeField] private Transform cam;


    private Dictionary<Vector2, Tile> tiles;

    void Start()
    {
        
        GenerateGrid();
    }

    public void GenerateGrid()
    {
        tiles = new Dictionary<Vector2, Tile>();

        for (int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                var randomTile = Random.Range(0, 6) == 3 ?  MountainTile : GrassTile;
                var spawnedTile = Instantiate(randomTile, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";

                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnedTile.Init(isOffset);


                tiles[new Vector2(x, y)] = spawnedTile;

            }
        }

        cam.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, -10);

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
