using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FireScript : MonoBehaviour {
    public float speed = 1;
    public float distneceFormPlayer = 0.5F;
    public enum Direction { Up = 90, Down = 270, Right = 0, Left = 180 };

    private Direction direction;
    private Rigidbody2D body;

    public void Shot(Direction direction) {
        this.direction = direction;
        transform.Rotate(new Vector3(0, 0, direction.GetHashCode()));
        switch (direction) {
            case Direction.Down:
                transform.position = new Vector2(transform.position.x, transform.position.y - distneceFormPlayer);
                break;
            case Direction.Up:
                transform.position = new Vector2(transform.position.x, transform.position.y + distneceFormPlayer);
                break;
            case Direction.Right:
                transform.position = new Vector2(transform.position.x + distneceFormPlayer, transform.position.y );
                break;
            case Direction.Left:
                transform.position = new Vector2(transform.position.x - distneceFormPlayer, transform.position.y );
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("MovingTiles")) {
            other.GetComponent<MoveingBox>().move();
            GameObjectUtil.Destroy(gameObject);
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("NonMovingTiles")) {
            GameObjectUtil.Destroy(gameObject);
        }
    }

    private void Start() {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        switch (direction) {
            case Direction.Down:
                body.AddForce(new Vector2(0, -speed));
                break;
            case Direction.Up:
                body.AddForce(new Vector2(0, speed));
                break;
            case Direction.Right:
                body.AddForce(new Vector2(speed, 0));
                break;
            case Direction.Left:
                body.AddForce(new Vector2(-speed, 0));
                break;
        }
    }
}
