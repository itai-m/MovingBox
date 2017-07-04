using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Completed;

public class ExitTile : Tile {

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player")) {
            RefManager.Instance.getGameManager().nextLevel();
        }
    }
}

