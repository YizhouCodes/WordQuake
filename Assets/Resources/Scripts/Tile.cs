using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    string letters = "abcdefghijklmnopqrstuvwxyz";
    string letter = "";
    public GameObject Letter;
    public GameObject tileObject;
    public List<Tile> neighbors = new List<Tile>();
    public bool isSelected = false;

	// Use this for initialization
	void Start () {
        CreateTile();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ToggleSelected()
    {
        isSelected = !isSelected;
        Material m;
        if (isSelected)
        {
            m = Resources.Load("Materials/Green", typeof(Material)) as Material;
        }
        else {
            m = Resources.Load("Materials/Grey", typeof(Material)) as Material;
        }
        tileObject.GetComponent<MeshRenderer>().material = m;
    }

    public void CreateTile()
    {
        letter = letters[Random.Range(0, letters.Length)].ToString();
        Sprite sprite = Resources.Load("Letters/" + letter, typeof(Sprite)) as Sprite;
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
        ToggleSelected();
    }
}
