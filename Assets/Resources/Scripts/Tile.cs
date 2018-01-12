using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    public List<Tile> neighbors = new List<Tile>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddNeighbor(Tile g)
    {
        neighbors.Add(g);
    }

    public void RemoveNeighbor(Tile g)
    {
        neighbors.Remove(g);
    }

    void OnMouseDown() {
        print("click");
    }
}
