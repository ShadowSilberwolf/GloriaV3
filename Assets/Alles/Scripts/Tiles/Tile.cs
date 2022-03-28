using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tile : MonoBehaviour
{
   
    
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
                Select();
            }

            else if(OccupiedUnits.faction == Faction.Player2 && GameManager.Instance.GameState == GameState.EnemysTurn) 
            {
                Select();
            }
            else if (UnitManager.Instance.SelectedPlayer != null && OccupiedUnits.faction == Faction.Player2 && GameManager.Instance.GameState == GameState.HeroesTurn)
            {
                UnitManager.Instance.SelectedPlayer.Attack(OccupiedUnits);

                MenuManager.Instance.ShowEndScreen(UnitManager.Instance.PrüfeHeroAnzahl());

                GameManager.Instance.EndRound();
            }
            else if (UnitManager.Instance.SelectedPlayer != null && OccupiedUnits.faction == Faction.Player1 && GameManager.Instance.GameState == GameState.EnemysTurn)
            {
                UnitManager.Instance.SelectedPlayer.Attack(OccupiedUnits);

                MenuManager.Instance.ShowEndScreen(UnitManager.Instance.PrüfeHeroAnzahl());

                GameManager.Instance.EndRound();
            }
        }
        else
        {
            if(UnitManager.Instance.SelectedPlayer != null)
            {
                SetUnit(UnitManager.Instance.SelectedPlayer);
                GameManager.Instance.EndRound();
            }
        }
        MenuManager.Instance.ShowEndScreen(UnitManager.Instance.PrüfeHeroAnzahl());
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
        if (OccupiedUnits != null)
        {
            if (OccupiedUnits.faction == Faction.Player2)
            {
                HightlightRed.SetActive(true);
            }
            else if (OccupiedUnits.faction == Faction.Player1)
            {
                HightlightGreen.SetActive(true);
            }
        }
        else 
        {
            HightlightRed.SetActive(false);
            HightlightGreen.SetActive(false);
        }
    }
    public void Select()
    {
        UnitManager.Instance.SetSelectedPlayer(OccupiedUnits);
        UnitHigh();
    }

    public void Update()
    {
       // UnitHigh();
    }
}
