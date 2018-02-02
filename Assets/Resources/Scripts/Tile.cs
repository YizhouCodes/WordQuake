using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    string letters = "abcdefghijklmnopqrstuvwxyz";
    string letter = "";
    public GameObject Letter;
    public List<Tile> neighbors = new List<Tile>();

	// Use this for initialization
	void Start () {
        CreateTile();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CreateTile()
    {
        letter = letters[Random.Range(0, letters.Length)].ToString();
        Debug.Log(letter);
        Sprite sprite = Resources.Load("Letters/" + letter, typeof(Sprite)) as Sprite;
        Debug.Log(sprite);
        Letter.GetComponent<SpriteRenderer>().sprite = sprite;
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
