using UnityEngine;
using System.Collections;
using Completed;

public class MoveingBox : Tile {

    public enum Direction {Up, Down, Right, Left};
    public Direction direction;
    public int tilesToMove = 1;
    public float moveSpeed = 1F;
    public float delta = 0.001F;

    private bool moving = false;
    private Vector2 destPos;

    private BoardManager boardManager;

    // Use this for initialization
    void Start () {
        boardManager = RefManager.Instance.GetBoardManager(); ;
    }
	
	// Update is called once per frame
	 void Update () {
        if (!moving) {
            return;
        }
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, destPos, step);
            
        if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y), destPos) <= delta) {
            moving = false;
        }
	}

    public void move() {
        
        if (moving) {
            return;
        }
        switch (direction) {
            case Direction.Up:
                moveTo(new Postion2D(pos.X, pos.Y + tilesToMove));
                //if (!boardManager.CanMoveTile(new Postion2D(pos.X, pos.Y + tilesToMove))) {
                //    return;
                //}
                //pos.Y = pos.Y + tilesToMove;
                //destPos = new Vector2(transform.position.x, transform.position.y + tilesToMove);
                break;
            case Direction.Down:
                moveTo(new Postion2D (pos.X, pos.Y - tilesToMove));
                //if (!boardManager.CanMoveTile(new Postion2D(pos.X, pos.Y - tilesToMove))) {
                //    return;
                //}
                //pos.Y = pos.Y - tilesToMove;
                //destPos = new Vector2(transform.position.x, transform.position.y - tilesToMove);
                break;
            case Direction.Right:
                moveTo(new Postion2D(pos.X + tilesToMove, pos.Y));
                //if (!boardManager.CanMoveTile(new Postion2D(pos.X + tilesToMove, pos.Y ))) {
                //    return;
                //}
                //pos.X = pos.X + tilesToMove;
                //destPos = new Vector2(transform.position.x + tilesToMove, transform.position.y);
                break;
            case Direction.Left:
                moveTo(new Postion2D(pos.X - tilesToMove, pos.Y));
                //if (!boardManager.CanMoveTile(new Postion2D(pos.X - tilesToMove, pos.Y))) {
                //    return;
                //}
                //pos.X = pos.X - tilesToMove;
                //destPos = new Vector2(transform.position.x - tilesToMove, transform.position.y);
                break;
            default:

                break;
        }
        //moving = true;
    }

    private bool moveTo(Postion2D newPos) {
        if (!boardManager.CanMoveTile(newPos)) {
            return false;
        }
        boardManager.swapTiles(pos, newPos);
        pos = new Postion2D(newPos);
        destPos = new Vector2(pos.X, pos.Y);
        moving = true;
        return true;
    }
}
