using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraugrController : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(){
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);
    }
}
