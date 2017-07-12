using Completed;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefManager : Singleton<RefManager> {

    private GameManager gameManager;
    private MapEditorManager mapEditorManager;

    public int level;

    public bool isGamePause;

    public string mapEditorName = "";
    public int mapEditorCol;
    public int mapEditorRow;

    public GameManager getGameManager() {
        if (gameManager == null) {
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        }
        return gameManager;
    }

    public MapEditorManager getMapEditorManager() {
        if (mapEditorManager == null) {
            mapEditorManager = GameObject.Find("MapEditorManager").GetComponent<MapEditorManager>();
        }
        return mapEditorManager;
    }
}
