using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

    public enum TileType {MoveingBoxUp, MoveingBoxDown, MoveingBoxLeft, MoveingBoxRight, Empty, NonMovingTile, Exit, Player};
    public TileType type;
    public Postion2D pos;
}

public class Postion2D {
    int x;
    int y;

    public int X {
        get {
            return x;
        }

        set {
            x = value;
        }
    }

    public int Y {
        get {
            return y;
        }

        set {
            y = value;
        }
    }

    public Postion2D(int x, int y) {
        updatePostion(x, y);
    }

    public Postion2D updatePostion(int x, int y) {
        updateX(x);
        updateY(y);
        return this;
    }

    public Postion2D(Postion2D pos) {
        x = pos.X;
        y = pos.Y;
    }

    public Postion2D updateX(int x) {
        this.X = x;
        return this;
    }

    public Postion2D updateY(int y) {
        this.Y = y;
        return this;
    }

    public int getX() {
        return X;
    }

    public int getY() {
        return Y;
    }

    public override string ToString() {
        return x + "," + y;
    }
}
