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
        ShowDamage(Damage.ToString());                                           // GanzeZeile.

        target.health = target.health - (Damage - target.Armor);
        if(target.health <= 0)
        {
            Destroy(target.gameObject);
        }
    }

    void ShowDamage(string text)                    // ShowDamage hat benjo gemacht.
    {
        if (floatingTextPrefab)
        {
            GameObject prefab = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
            prefab.GetComponentInChildren<TextMesh>().text = text;
        }
    }
    
}
