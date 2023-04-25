using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    
    void OnMouseEnter()
    {
        rend.material.color = Color.yellow;
    }





    void OnMouseExit()
    {
        rend.material.color = Color.red;
    }
}
