using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnits : MonoBehaviour
{
    public Tile OccupiedTile;
    public Faction faction;
    public string unitName;

    public int health = 1000;
    public int Damage = 250;
    public int Armor = 50;

    public void Attack(BaseUnits target)
    {
        target.health = target.health - (Damage - target.Armor);
        if(target.health <= 0)
        {
            Destroy(target.gameObject);
        }
    }

    
}
