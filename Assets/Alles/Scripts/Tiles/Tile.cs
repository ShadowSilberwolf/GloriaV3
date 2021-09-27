using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tile : MonoBehaviour
{
   
    [SerializeField] protected SpriteRenderer renderer;
    [SerializeField] private GameObject Hightlight;
    [SerializeField] private bool isWalkable;
    public string TileName;

    public BaseUnits OccupiedUnits;
    public bool Walkable => isWalkable && OccupiedUnits == null;

    public virtual void Init(int x, int y)
    {
       
    }

    private void OnMouseEnter()
    {
        Hightlight.SetActive(true);
        MenuManager.Instance.ShowTileInfo(this);
    }
    private void OnMouseExit()
    {
        Hightlight.SetActive(false);
        MenuManager.Instance.ShowTileInfo(null);

    }

    public void OnMouseDown()
    {
        Debug.Log("Boobs");
        if (GameManager.Instance.GameState != GameState.HeroesTurn) return;

        if(OccupiedUnits != null)
        {
            if (OccupiedUnits.faction == Faction.Player1)UnitManager.Instance.SetSelectedPlayer((BasePlayer1)OccupiedUnits);
            else
            {
                if(UnitManager.Instance.SelectedPlayer != null)
                {
                    var enemy = (BasePlayer2)OccupiedUnits;
                    UnitManager.Instance.SetSelectedPlayer(null);
                    GameManager.Instance.ChangeState(GameState.HeroesTurn);
                }
            }
        }
        else
        {
            if(UnitManager.Instance.SelectedPlayer != null)
            {
                SetUnit(UnitManager.Instance.SelectedPlayer);
                UnitManager.Instance.SetSelectedPlayer(null);
            }
        }
    }

    public void SetUnit(BaseUnits unit)
    {
        if (unit.OccupiedTile != null) unit.OccupiedTile.OccupiedUnits = null;
        unit.transform.position = transform.position;
        OccupiedUnits = unit;
        unit.OccupiedTile = this;
    }
}
