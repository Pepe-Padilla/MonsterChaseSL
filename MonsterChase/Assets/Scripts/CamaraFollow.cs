using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFollow : MonoBehaviour
{
    // Constants
    private static string PLAYER_TAG = "Player";

    // SerializedFields
    [SerializeField]
    private float minX, maxX;

    // private vars
    private Transform player;
    private Vector3 tempPos;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.FindWithTag(PLAYER_TAG).transform;
    }

    // Update is called once per frame
    void LateUpdate() {
        tempPos = transform.position;
        tempPos.x = player.position.x; //todo agegar un max
        transform.position = tempPos;
    }
}
