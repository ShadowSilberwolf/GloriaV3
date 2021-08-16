using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tile : MonoBehaviour
{
   
    [SerializeField] protected SpriteRenderer renderer;
    [SerializeField] private GameObject Hightlight;
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
}
