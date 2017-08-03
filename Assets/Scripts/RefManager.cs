using Completed;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefManager : Singleton<RefManager> {

    private GameManager gameManager;
    private GameObject gameManagerObj;
    private MapEditorManager mapEditorManager;
    private BoardManager boardManager;

    public int level;
    public string worldName;

    public bool isGamePause;

    public string mapEditorName = "";
    public int mapEditorCol;
    public int mapEditorRow;

    public GameManager getGameManager() {
        if (gameManager == null) {
            gameManager = GetGameManagerObject().GetComponent<GameManager>();
        }
        return gameManager;
    }

    public MapEditorManager getMapEditorManager() {
        if (mapEditorManager == null) {
            mapEditorManager = GameObject.Find("MapEditorManager").GetComponent<MapEditorManager>();
        }
        return mapEditorManager;
    }

    public BoardManager GetBoardManager() {
        if (boardManager == null) {
            boardManager = GetGameManagerObject().GetComponent<BoardManager>();
        }
        return boardManager;
    }

    public GameObject GetGameManagerObject() {
        if (gameManagerObj == null) {
            gameManagerObj = GameObject.Find("GameManager");
        }
        return gameManagerObj;
    }
}
