using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainTile : Tile
{
    [SerializeField] private Sprite baseSprite, offsetSprite;
    // Start is called before the first frame update
    public override void Init(int x, int y)
    {
        var isOffset = (x + y) % 2 == 1;
        renderer.sprite = isOffset ? offsetSprite : baseSprite;
    }
}
