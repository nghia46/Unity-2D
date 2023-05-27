using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    [Header("Player")]
    [SerializeField][Range(0, 20f)] float h_speed;
    [SerializeField][Range(0, 10f)] float v_speed;
    [SerializeField][Range(0f, 1f)] float flipSpeed = .2f; // Adjust the speed of turning here
    [SerializeField] Vector2 vertical_mapBoder;
    private bool isFacingRight;
    private float h_input, v_input;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        isFacingRight = true;
        //speed = 5f;
        //jumpForce = 6f;
    }
    void Update()
    {
        h_input = Input.GetAxisRaw("Horizontal");
        v_input = Input.GetAxisRaw("Vertical");
        Vector2 moveDir = new Vector2(h_input * h_speed, v_input * v_speed);
        rb.velocity = moveDir;
        playerAnim(moveDir);
        getKeyInput();
        playerFlip();
        mapBoder();
    }

    private void mapBoder()
    {
        if (transform.position.y > vertical_mapBoder.x || transform.position.y < vertical_mapBoder.y)
        {
            if (transform.position.y > vertical_mapBoder.x)
            {
                transform.position = new Vector2(transform.position.x, vertical_mapBoder.x);
            }
            if (transform.position.y < vertical_mapBoder.y)
            {
                transform.position = new Vector2(transform.position.x, vertical_mapBoder.y);
            }
        }
    }
    private void playerAnim(Vector2 moveDir)
    {
        if (moveDir != Vector2.zero)
        {
            anim.SetBool("isMove", true);
        }
        else
        {
            anim.SetBool("isMove", false);
        }
    }
    void playerFlip()
    {
        if (h_input > 0 && !isFacingRight)
        {
            StartCoroutine(TurnPlayer(1));
        }
        else if (h_input < 0 && isFacingRight)
        {
            StartCoroutine(TurnPlayer(-1));
        }
    }
    void getKeyInput()
    {

    }
    IEnumerator TurnPlayer(int direction)
    {
        float targetScaleX = direction;
        float elapsedTime = 0f;
        float initialScaleX = transform.localScale.x;

        while (elapsedTime < flipSpeed)
        {
            float t = elapsedTime / flipSpeed;
            float scaleX = Mathf.Lerp(initialScaleX, targetScaleX, t);
            transform.localScale = new Vector3(scaleX, 1f, 1f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = new Vector3(targetScaleX, 1f, 1f);
        isFacingRight = (direction == 1);
    }
}
