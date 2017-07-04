using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePicker : MonoBehaviour {

    private Tile.TileType pickTile;

	// Use this for initialization
	void Start () {
		
	}

    public void TilePick(int pickNumber) {
        switch (pickNumber) {
            case 0:
                pickTile = Tile.TileType.Empty;
                break;
            case 1:
                pickTile = Tile.TileType.MoveingBoxDown;
                break;
        }
    }

    public Tile.TileType getSelectedTile() {
        return pickTile;
    }
}
