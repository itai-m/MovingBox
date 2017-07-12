using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TilePicker : MonoBehaviour {

    private Tile.TileType pickTile;

    public GameObject menuPanel;

	// Use this for initialization
	void Start () {
		
	}

    public void TilePick(int pickNumber) {
        HighLigthedButton(pickNumber);
        switch (pickNumber) {
            case 0:
                pickTile = Tile.TileType.NonMovingTile;
                break;
            case 1:
                pickTile = Tile.TileType.MoveingBoxDown;
                break;
            case 2:
                pickTile = Tile.TileType.MoveingBoxLeft;
                break;
            case 3:
                pickTile = Tile.TileType.MoveingBoxRight;
                break;
            case 4:
                pickTile = Tile.TileType.MoveingBoxUp;
                break;
            case 5:
                pickTile = Tile.TileType.Player;
                break;
            case 7:
                pickTile = Tile.TileType.Empty;
                break;
            case 6:
                pickTile = Tile.TileType.Exit;
                break;
        }
    }

    public Tile.TileType getSelectedTile() {
        return pickTile;
    }


    private void HighLigthedButton(int childNumber) {
        for (int i = 0; i < transform.childCount; i++) {
            transform.GetChild(i).gameObject.GetComponent<Image>().color = Color.white;
        }
        transform.GetChild(childNumber).gameObject.GetComponent<Image>().color = Color.cyan;
    }
}
