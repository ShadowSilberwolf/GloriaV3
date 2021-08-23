using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tile : MonoBehaviour
{
   
    [SerializeField] protected SpriteRenderer renderer;
    [SerializeField] private GameObject Hightlight;
    [SerializeField] private bool isWalkable;

    public BaseUnits OccupiedUnits;
    public bool Walkable => isWalkable && OccupiedUnits == null;

    public virtual void Init(int x, int y)
    {
       
    }

    private void OnMouseEnter()
    {
        Hightlight.SetActive(true);
    }
    private void OnMouseExit()
    {
        Hightlight.SetActive(false);
    }

    public void SetUnit(BaseUnits unit)
    {
        if (unit.OccupiedTile != null) unit.OccupiedTile.OccupiedUnits = null;
        unit.transform.position = transform.position;
        OccupiedUnits = unit;
        unit.OccupiedTile = this;
    }
}
