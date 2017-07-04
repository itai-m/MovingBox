using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Completed;

public class ExitTile : Tile {

<<<<<<< HEAD
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player")) {
            RefManager.Instance.getGameManager().nextLevel();
=======

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
>>>>>>> fef21a562409a4a88c84ea3c8e4d97d9a6bd29ab
        }
    }
}

