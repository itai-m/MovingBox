using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Completed;

public class ExitTile : Tile {


    private GameManager gameManager;

    // Use this for initialization
    void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player")) {
            gameManager.nextLevel();
        }
    }
}

