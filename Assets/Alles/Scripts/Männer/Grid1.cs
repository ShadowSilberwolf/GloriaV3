using System;
using UnityEngine;

public class Grid<T>
{
    private int width;
    private int height;
    private float v;
    private Vector3 zero;
    private Func<Grid<PathNode>, int, int, PathNode> p;

    public Grid(int width, int height, float v, Vector3 zero, Func<Grid<PathNode>, int, int, PathNode> p)
    {
        this.width = width;
        this.height = height;
        this.v = v;
        this.zero = zero;
        this.p = p;
    }
}