using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit", menuName = "Scriptable Unit")]
public class ScriptableUnit : ScriptableObject
{

    public Faction faction;
    public BaseUnits UnitPrefab;

        
}

public enum Faction
{
    Player1 = 0,
    Player2 = 1


}
