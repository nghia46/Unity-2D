using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float Speed = 6f;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float h_move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(h_move*Speed,rb.velocity.y);
    }
}
