using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feeler : MonoBehaviour {

    public Tile owner;

    void OnTriggerEnter(Collider c)
    {
        if(c.tag == "Tile")
        {
            owner.AddNeighbor(c.GetComponent<Tile>());
        }
    }

    void OnTriggerExit(Collider c)
    {
        if (c.tag == "Tile")
        {
            owner.RemoveNeighbor(c.GetComponent<Tile>());
        }
    }

}
