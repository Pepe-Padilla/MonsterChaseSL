using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Constants
    private static string WALK_ANIMATION = "Walk";

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
    }

    // Movimiento horizontal (so far)
    private void PlayerMoveKeyboard() {
        movmentX =  Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movmentX, 0f, 0f) * moveForce * Time.deltaTime;
    }
}
