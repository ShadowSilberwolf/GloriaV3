using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BaseUnits : MonoBehaviour
{
    public Tile OccupiedTile;
    public Faction faction;
    public string unitName;
                                                                                // Benjo, Was hat er geändert.
    [SerializeField] private int health = 1000;                                 // [SerializeField] private.
    [SerializeField] private GameObject floatingTextPrefab;                     // Ganze Zeile.
    public int Damage = 250;
    public int Armor = 50;

    public void Attack(BaseUnits target)
    {
        ShowDamage((Damage - target.Armor).ToString(),target);                                           // GanzeZeile.

        target.health = target.health - (Damage - target.Armor);
        if(target.health <= 0)
        {
            Destroy(target.gameObject);
            MenuManager.Instance.ShowEndScreen(UnitManager.Instance.PrüfeHeroAnzahl());

        }
    }

    void ShowDamage(string text, BaseUnits target)                    // ShowDamage hat benjo gemacht.
    {
        if (floatingTextPrefab)
        {
            GameObject prefab = Instantiate(floatingTextPrefab, target.transform.position, Quaternion.identity);
            prefab.GetComponentInChildren<TextMesh>().text = text;
        }
    }
    
}
