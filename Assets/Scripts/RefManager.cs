using Completed;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefManager : Singleton<RefManager> {

    private GameManager gameManager;

    public int level;

    public bool isGamePause;

    public Map savedMap;

    public GameManager getGameManager() {
        if (gameManager == null) {
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        }
        return gameManager;
    }
}
