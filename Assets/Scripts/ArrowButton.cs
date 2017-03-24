using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ArrowButton : MonoBehaviour {

    public enum Direction { Up, Down, Right, Left };
    public Direction direction;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void clickDown() {
        Move();
    }

    public void clickUp() {
        StopMove();
    }

    private void Move() {
        switch (direction) {
            case Direction.Up:
                CrossPlatformInputManager.SetAxisPositive("Vertical");
                break;
            case Direction.Down:
                CrossPlatformInputManager.SetAxisNegative("Vertical");
                break;
            case Direction.Right:
                CrossPlatformInputManager.SetAxisPositive("Horizontal");
                break;
            case Direction.Left:
                CrossPlatformInputManager.SetAxisNegative("Horizontal");
                break;
            default:

                break;
        }
    }

    private void StopMove() {
        switch (direction) {
            case Direction.Up:
            case Direction.Down:
                CrossPlatformInputManager.SetAxisZero("Vertical");
                break;
            case Direction.Right:
            case Direction.Left:
                CrossPlatformInputManager.SetAxisZero("Horizontal");
                break;
            default:

                break;
        }
    }
}
