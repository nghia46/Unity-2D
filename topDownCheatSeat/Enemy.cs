using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Enemy : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] GameObject player;
    [SerializeField] float speed;
    [SerializeField] float chaseDistance;
    [SerializeField] Animator anim;
    private updateScore Score;
    public float getDamage()
    {
        return damage;
    }
    void Start()
    {
        Score = GameObject.Find("Score").GetComponent<updateScore>();
        player = GameObject.Find("Player");
    }
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance < chaseDistance)
        {
            anim.SetBool("isWalk", true);
            Vector2 targetPosition = player.transform.position;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        else
        {
            anim.SetBool("isWalk", false);
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Bullet"))
        {
            Score.updatedScore();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
