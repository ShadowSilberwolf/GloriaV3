using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tile : MonoBehaviour
{
   
    [SerializeField] protected SpriteRenderer renderer;
    [SerializeField] private GameObject Hightlight;
    [SerializeField] private GameObject HightlightGreen;
    [SerializeField] private GameObject HightlightRed;
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

    void OnMouseDown()
    {
        //if (GameManager.Instance.GameState != GameState.HeroesTurn) return;

        if(OccupiedUnits != null)
        {
            if (OccupiedUnits.faction == Faction.Player1 && GameManager.Instance.GameState == GameState.HeroesTurn)
            {
                UnitManager.Instance.SetSelectedPlayer(OccupiedUnits);
            }

            else if(OccupiedUnits.faction == Faction.Player2 && GameManager.Instance.GameState == GameState.EnemysTurn) 
            {
                UnitManager.Instance.SetSelectedPlayer(OccupiedUnits);
            }
            else if (UnitManager.Instance.SelectedPlayer != null && OccupiedUnits.faction == Faction.Player2 && GameManager.Instance.GameState == GameState.HeroesTurn)
            {
                UnitManager.Instance.SelectedPlayer.Attack(OccupiedUnits);
                UnitManager.Instance.SetSelectedPlayer(null);
                GameManager.Instance.ChangeState(GameState.EnemysTurn);
                MenuManager.Instance.BenjaminRedGreen();
            }
            else if (UnitManager.Instance.SelectedPlayer != null && OccupiedUnits.faction == Faction.Player1 && GameManager.Instance.GameState == GameState.EnemysTurn)
            {
                UnitManager.Instance.SelectedPlayer.Attack(OccupiedUnits);
                UnitManager.Instance.SetSelectedPlayer(null);
                GameManager.Instance.ChangeState(GameState.HeroesTurn);
                MenuManager.Instance.BenjaminRedGreen();
            }

        }
        else
        {
            if(UnitManager.Instance.SelectedPlayer != null)
            {
                SetUnit(UnitManager.Instance.SelectedPlayer);
                UnitManager.Instance.SetSelectedPlayer(null);
                if(GameManager.Instance.GameState == GameState.EnemysTurn)
                {
                    GameManager.Instance.ChangeState(GameState.HeroesTurn);
                    MenuManager.Instance.BenjaminRedGreen();
                }
                else if(GameManager.Instance.GameState == GameState.HeroesTurn)
                {
                    GameManager.Instance.ChangeState(GameState.EnemysTurn);
                    MenuManager.Instance.BenjaminRedGreen();
                }
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

    public void UnitHigh()
    {
        Debug.Log("Tits");
    }
}
