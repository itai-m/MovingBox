using UnityEngine;
using System.Collections;

public class PlayerMovment : MonoBehaviour {
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;

    private Rigidbody2D rigidBody;
    private Animator animator;

    private bool isJumping;
    private bool isFalling;

    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    void Update() {
        if (Input.GetAxis("Jump") != 0) {
            Jump();
        }
        if (Input.GetAxis("Horizontal") != 0) {
            Run();
        }
        else if (true) {

        }

        
    }

    private void Jump() {
        rigidBody.AddForce(Vector3.up * jumpSpeed);
    }

    private void Run() {
        animator.SetBool("Run", true);
        rigidBody.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, 0);
        if (Input.GetAxis("Horizontal") < 0) {
            swichSide();
        }

    }

    private void swichSide() {
        transform.localScale = new Vector3(-1, 1, 1);
        transform.position = new Vector3(transform.position.x, transform.position.y , transform.position.z);
    }

}