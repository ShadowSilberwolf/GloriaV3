using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainTile : Tile
{
    [SerializeField] private Color baseColor, offsetColor;
    // Start is called before the first frame update
    public override void Init(int x, int y)
    {
        var isOffset = (x + y) % 2 == 1;
        renderer.color = isOffset ? offsetColor : baseColor;
    }
}
