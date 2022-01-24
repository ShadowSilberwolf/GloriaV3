using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    [SerializeField] public GameObject SelectedHeroObject, TileObject, TileUnitObject, Spieler1GreenSelectedHeroInfo, Spieler1GreenTileUnitInfo, 
        Spieler2RedSelectedHeroInfo, Spieler2RedTileUnitInfo,Spieler1IstDran, Spieler2IstDran, Background_EndScreen, Text_Spieler1, Text_Spieler2;

   
    private void Awake()
    {
        Instance = this;


    }

    public void ShowselectedHero(BaseUnits PlayerOne)
    {
        if(PlayerOne == null)
        {
            SelectedHeroObject.SetActive(false);
            return;
        }
        SelectedHeroObject.GetComponentInChildren<Text>().text = PlayerOne.unitName;
        SelectedHeroObject.SetActive(true);
    }

    public void ShowTileInfo(Tile Teile) 
    {
        if (Teile == null)
        {
            TileObject.SetActive(false);
           

            return;
        }

        TileObject.GetComponentInChildren<Text>().text = Teile.TileName;
        TileObject.SetActive(true);

        //Tile unit info
        if (Teile.OccupiedUnits)
        {
            TileUnitObject.GetComponentInChildren<Text>().text = Teile.OccupiedUnits.unitName;
            TileUnitObject.SetActive(true);
            if(Teile.OccupiedUnits.faction == Faction.Player1)
            {
                TileUnitObject.GetComponent<Image>().color = new Color32(0, 255, 10, 255);
            }
            else if (Teile.OccupiedUnits.faction == Faction.Player2)
            {
                TileUnitObject.GetComponent<Image>().color = new Color32(203, 54, 63, 255);
            }
        }

       
    }

    public void BenjaminRedGreen()
    {
        
        if (GameManager.Instance.GameState == GameState.HeroesTurn)
        {
            Spieler1IstDran.SetActive(true);
            Spieler2IstDran.SetActive(false);
        }
        else if (GameManager.Instance.GameState == GameState.EnemysTurn)
        {
            Spieler2IstDran.SetActive(true);
            Spieler1IstDran.SetActive(false);
        }
    }

    public void ShowEndScreen(int Spieler)
    {
        if(Spieler != 0)
        {
        
            Background_EndScreen.SetActive(true);
            if(Spieler == 1)
            {
                Text_Spieler2.SetActive(false);
            }
            else if (Spieler == 2)
            {
                Text_Spieler1.SetActive(false);
            }
        }
    }
}
