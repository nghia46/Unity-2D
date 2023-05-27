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
    [SerializeField][Range(0f, 1f)] float flipSpeed = .2f;
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
        //Flip direction
        float targetScaleX = direction;
        //Time for flip
        float elapsedTime = 0f;
        //Asign localScale
        float initialScaleX = transform.localScale.x;
        //check while time is less than flip speed;
        while (elapsedTime < flipSpeed)
        {
            //time = 
            float t = elapsedTime / flipSpeed;
            float scaleX = Mathf.Lerp(initialScaleX, targetScaleX, t);
            transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = new Vector3(targetScaleX, transform.localScale.y, transform.localScale.z);
        isFacingRight = (direction == 1);
    }
}
