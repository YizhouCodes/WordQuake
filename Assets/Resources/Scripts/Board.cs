using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {

    public List<GameObject> tiles = new List<GameObject>();
    public int gridWidth;
    public int gridHeight;
    public GameObject tilePrefab;

	// Use this for initialization
	void Start () {
		for(int y = 0; y < gridHeight; y++) {
            for(int x = 0; x < gridWidth; x++) {
                GameObject g = Instantiate(tilePrefab, new Vector3(x, y, 0), Quaternion.identity) as GameObject;
                g.transform.parent = gameObject.transform;
                tiles.Add(g);
            }
        }
        gameObject.transform.position = new Vector3(-gridWidth / 2 + 0.5f, -gridHeight / 2 + 0.5f, 0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
