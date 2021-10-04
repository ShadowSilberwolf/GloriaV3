using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    [SerializeField] public GameObject SelectedHeroObject, TileObject, TileUnitObject; 
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
            TileUnitObject.SetActive(false);
            return;
        }

        TileObject.GetComponentInChildren<Text>().text = Teile.TileName;
        TileObject.SetActive(true);

        if (Teile.OccupiedUnits)
        {
            TileUnitObject.GetComponentInChildren<Text>().text = Teile.OccupiedUnits.unitName;
            TileUnitObject.SetActive(true);
        }
    }
}
