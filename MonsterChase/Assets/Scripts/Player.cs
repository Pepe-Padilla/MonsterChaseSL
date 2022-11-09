using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Constants
    private static string WALK_ANIMATION = "walk";
    private static string GROUND_TAG = "Ground";

    // SerializedFields
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;

    // private vars
    private float movmentX;
    private Rigidbody2D myBody;
    private SpriteRenderer sr;
    private Animator anim;
    private bool isGrounded;

    private void Awake() {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        PlayerMoveKeyboard();
        AnimatePlayer();
    }

    private void FixedUpdate() {
        playerJump();
    }

    // Movimiento horizontal (so far)
    private void PlayerMoveKeyboard() {
        movmentX =  Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movmentX, 0f, 0f) * moveForce * Time.deltaTime;
    }

    private void AnimatePlayer() {
        if(movmentX > 0) {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        } else if(movmentX < 0) {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        } else {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }

    private void playerJump() {
        if(Input.GetButton("Jump") && isGrounded) {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f,jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag(GROUND_TAG)) {
            isGrounded = true;
        }
    }
}
