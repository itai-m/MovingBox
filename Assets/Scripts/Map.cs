using UnityEngine;
using System.Collections;
using System;

public class Map : MonoBehaviour {

    private GameObject[,] tiles;
    public int col;
    public int row;

    public GameObject MoveingBoxUp, MoveingBoxDown, MoveingBoxLeft, MoveingBoxRight, NonMovingTile;
    public GameObject ExitTile;

    public GameObject player;

    public Vector2 playerStart;

    void Start() {
    }

    public void LoadMapFromSavedMap(SavedMap map) {
        initMapFormArray(map.GetMap());
        rotateMapRight();
        rotateMapRight();
    }

    public void loadExmpleMap() {
        Tile.TileType[,] newMap = {  { Tile.TileType.NonMovingTile, Tile.TileType.Empty,         Tile.TileType.MoveingBoxDown,   Tile.TileType.Empty,        Tile.TileType.Empty,           Tile.TileType.Empty,            Tile.TileType.NonMovingTile},
                                     { Tile.TileType.NonMovingTile, Tile.TileType.Empty,         Tile.TileType.Empty,            Tile.TileType.Empty,        Tile.TileType.Empty,           Tile.TileType.Empty,            Tile.TileType.MoveingBoxRight },
                                     { Tile.TileType.Exit,          Tile.TileType.Player,         Tile.TileType.MoveingBoxUp,     Tile.TileType.Empty,       Tile.TileType.Player,          Tile.TileType.Empty,            Tile.TileType.MoveingBoxLeft },
                                     { Tile.TileType.NonMovingTile, Tile.TileType.NonMovingTile, Tile.TileType.NonMovingTile,    Tile.TileType.MoveingBoxUp, Tile.TileType.NonMovingTile,   Tile.TileType.NonMovingTile,    Tile.TileType.NonMovingTile },};
        initMapFormArray(newMap);
        rotateMapRight();
        playerStart = new Vector2(1, 1);
    }

    public void loadMap1() {
        Tile.TileType[,] newMap = {{Tile.TileType.NonMovingTile,Tile.TileType.NonMovingTile,Tile.TileType.NonMovingTile,Tile.TileType.NonMovingTile,Tile.TileType.NonMovingTile,Tile.TileType.NonMovingTile,Tile.TileType.NonMovingTile,Tile.TileType.NonMovingTile,Tile.TileType.NonMovingTile,Tile.TileType.NonMovingTile,Tile.TileType.NonMovingTile,Tile.TileType.NonMovingTile,Tile.TileType.NonMovingTile},
                                     {Tile.TileType.NonMovingTile,Tile.TileType.Empty,Tile.TileType.Empty,Tile.TileType.Empty,Tile.TileType.Empty,Tile.TileType.Empty,Tile.TileType.Empty,Tile.TileType.Empty,Tile.TileType.Empty,Tile.TileType.MoveingBoxDown,Tile.TileType.Empty,Tile.TileType.Empty,Tile.TileType.Exit},
                                     {Tile.TileType.NonMovingTile,Tile.TileType.Empty,Tile.TileType.NonMovingTile,Tile.TileType.Empty,Tile.TileType.NonMovingTile,Tile.TileType.Empty,Tile.TileType.NonMovingTile,Tile.TileType.Empty,Tile.TileType.NonMovingTile,Tile.TileType.Empty,Tile.TileType.MoveingBoxRight,Tile.TileType.MoveingBoxRight,Tile.TileType.NonMovingTile},
                                     {Tile.TileType.NonMovingTile,Tile.TileType.Empty,Tile.TileType.NonMovingTile,Tile.TileType.Empty,Tile.TileType.NonMovingTile,Tile.TileType.Empty,Tile.TileType.NonMovingTile,Tile.TileType.Empty,Tile.TileType.NonMovingTile,Tile.TileType.Empty,Tile.TileType.NonMovingTile,Tile.TileType.NonMovingTile,Tile.TileType.NonMovingTile},
                                     {Tile.TileType.NonMovingTile,Tile.TileType.Empty,Tile.TileType.NonMovingTile,Tile.TileType.Empty,Tile.TileType.NonMovingTile,Tile.TileType.MoveingBoxUp,Tile.TileType.NonMovingTile,Tile.TileType.Empty,Tile.TileType.NonMovingTile,Tile.TileType.Empty,Tile.TileType.NonMovingTile,Tile.TileType.NonMovingTile,Tile.TileType.NonMovingTile},
                                     {Tile.TileType.NonMovingTile,Tile.TileType.Empty,Tile.TileType.Empty,Tile.TileType.MoveingBoxUp,Tile.TileType.Empty,Tile.TileType.MoveingBoxDown,Tile.TileType.Empty,Tile.TileType.MoveingBoxUp,Tile.TileType.Empty,Tile.TileType.MoveingBoxDown,Tile.TileType.Empty,Tile.TileType.Empty,Tile.TileType.NonMovingTile},
                                     {Tile.TileType.NonMovingTile,Tile.TileType.MoveingBoxUp,Tile.TileType.Empty,Tile.TileType.Empty,Tile.TileType.Empty,Tile.TileType.Empty,Tile.TileType.Empty,Tile.TileType.Empty,Tile.TileType.Empty,Tile.TileType.Empty,Tile.TileType.NonMovingTile,Tile.TileType.Empty,Tile.TileType.NonMovingTile},
                                     {Tile.TileType.NonMovingTile,Tile.TileType.Empty,Tile.TileType.Empty,Tile.TileType.Empty,Tile.TileType.Empty,Tile.TileType.Empty,Tile.TileType.Empty,Tile.TileType.Empty,Tile.TileType.MoveingBoxUp,Tile.TileType.Empty,Tile.TileType.Empty,Tile.TileType.Empty,Tile.TileType.NonMovingTile},
                                     {Tile.TileType.Empty,Tile.TileType.Player,Tile.TileType.MoveingBoxUp,Tile.TileType.MoveingBoxUp,Tile.TileType.MoveingBoxUp,Tile.TileType.Empty,Tile.TileType.MoveingBoxUp,Tile.TileType.MoveingBoxUp,Tile.TileType.MoveingBoxRight,Tile.TileType.NonMovingTile,Tile.TileType.Empty,Tile.TileType.Empty,Tile.TileType.Empty},
                                     {Tile.TileType.NonMovingTile,Tile.TileType.NonMovingTile,Tile.TileType.NonMovingTile,Tile.TileType.NonMovingTile,Tile.TileType.NonMovingTile,Tile.TileType.NonMovingTile,Tile.TileType.NonMovingTile,Tile.TileType.NonMovingTile,Tile.TileType.NonMovingTile,Tile.TileType.NonMovingTile,Tile.TileType.NonMovingTile,Tile.TileType.MoveingBoxUp,Tile.TileType.NonMovingTile}};
        initMapFormArray(newMap);
        rotateMapRight();
        playerStart = new Vector2(1, 1);
    }

    private GameObject[,] initMap(int col, int row) {
        this.col = col;
        this.row = row;
        GameObject[,] newTiles = new GameObject[col,row];
        return newTiles;
    }

    private void initMapFormArray(Tile.TileType[,] newMap) {
        tiles = initMap(newMap.GetLength(0), newMap.GetLength(1));
        for (int i = 0 ; i < col; i++) {
            for (int j = 0 ; j < row; j++) {
                tiles[i,j] = getTileObject(newMap[i,j]);
            }
        }
    }

    private GameObject getTileObject(Tile.TileType type) {
        switch(type) {
            case Tile.TileType.Empty:
                return null;

            case Tile.TileType.Exit:
                return ExitTile;

            case Tile.TileType.MoveingBoxDown:
                return MoveingBoxDown;

            case Tile.TileType.MoveingBoxLeft:
                return MoveingBoxLeft;

            case Tile.TileType.MoveingBoxRight:
                return MoveingBoxRight;

            case Tile.TileType.MoveingBoxUp:
                return MoveingBoxUp;

            case Tile.TileType.NonMovingTile:
                return NonMovingTile;

            case Tile.TileType.Player:
                return player;

            default:
                return null;
        }
    }

    public GameObject tileIn(int x, int y) {
        return tiles[x,y];
    }

    public GameObject tileIn(Postion2D pos) {
        return tileIn(pos.X, pos.Y);
    }

    private void rotateMapRight() {
        if (tiles.GetLength(0) == 0) {
            return;
        }
        tiles = RotateMatrixCounterClockwise(tiles);
        swapMapSizes();
    }

    private void swapMapSizes() {
        int temp = col;
        col = row;
        row = temp;
    }

    private GameObject[,] RotateMatrixCounterClockwise(GameObject[,] oldMatrix) {
        GameObject[,] newMatrix = new GameObject[oldMatrix.GetLength(1), oldMatrix.GetLength(0)];
        int newColumn, newRow = 0;
        for (int oldColumn = oldMatrix.GetLength(1) - 1; oldColumn >= 0; oldColumn--) {
            newColumn = 0;
            for (int oldRow = 0; oldRow < oldMatrix.GetLength(0); oldRow++) {
                newMatrix[oldMatrix.GetLength(1) - 1 - newRow, oldMatrix.GetLength(0) - 1 - newColumn] = oldMatrix[oldRow, oldColumn];
                newColumn++;
            }
            newRow++;
        }
        return newMatrix;
    }

    public void swapTiles(int x1, int y1, int x2, int y2) {
        GameObject temp = tiles[x1, y1];
        tiles[x1, y1] = tiles[x2, y2];
        tiles[x2, y2] = temp;
    }

    public void swapTiles(Postion2D pos1, Postion2D pos2) {
        swapTiles(pos1.X, pos1.Y, pos2.X, pos2.Y);
    }

    public bool isEmptyTile(Postion2D pos) {
        if (pos.X < 0 || pos.Y < 0 || pos.X >= col || pos.Y >= row) {
            return false;
        }
        return (tiles[pos.X, pos.Y] == null);
    }

}

