using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileMapEditorButton : MonoBehaviour {

    private Image image;

    public Sprite empty;
    public Sprite exit;
    public Sprite moveingBoxDown;
    public Sprite moveingBoxLeft;
    public Sprite moveingBoxRight;
    public Sprite moveingBoxUp;
    public Sprite player;
    public Sprite nonMovingTile;

    private Tile.TileType tileType = Tile.TileType.Empty;

    // Use this for initialization
    void Start() {
    }

    public void onClick() {
        ChangeTile(RefManager.Instance.getMapEditorManager().getSelectedTile());
    }

    public void ChangeTile(Tile.TileType tile) {
        tileType = tile;
        GetComponent<Image>().sprite = getSpriteByTile(tile);
    }

    private Sprite getSpriteByTile(Tile.TileType tile) {
        switch (tile) {
            case (Tile.TileType.Empty):
                return empty;
            case (Tile.TileType.Exit):
                return exit;
            case (Tile.TileType.MoveingBoxDown):
                return moveingBoxDown;
            case (Tile.TileType.MoveingBoxLeft):
                return moveingBoxLeft;
            case (Tile.TileType.MoveingBoxRight):
                return moveingBoxRight;
            case (Tile.TileType.MoveingBoxUp):
                return moveingBoxUp;
            case (Tile.TileType.Player):
                return player;
            case (Tile.TileType.NonMovingTile):
                return nonMovingTile;
        }
        return empty;
    }

    public Tile.TileType getTileType() {
        return tileType;
    }
}
