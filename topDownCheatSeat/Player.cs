using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] HealthBar healthBar;
    [SerializeField] float speed;
    [SerializeField] float maxHealth;
    float currentHealth;
    float h_move, v_move;
    private bool isHealthReducing = false;
    private void Awake() {
        
    }
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.updateHealth(currentHealth, maxHealth);
    }
    void Update()
    {
        //move
        h_move = Input.GetAxisRaw("Horizontal");
        v_move = Input.GetAxisRaw("Vertical");
        Vector2 move = new Vector2(h_move, v_move) * speed;
        transform.position += (Vector3)move * Time.deltaTime;
        //look
        Vector2 mousePos = Input.mousePosition;
        Vector2 mousePosCamera = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 dir = mousePosCamera - (Vector2)this.transform.position;
        //dir.Normalize();
        Debug.DrawRay(this.transform.position, dir, Color.red);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        this.transform.eulerAngles = new Vector3(0, 0, angle);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (!isHealthReducing)
        {
            StartCoroutine(ReduceHealthWithDelay());
        }
    }
    private IEnumerator ReduceHealthWithDelay()
    {
        isHealthReducing = true;
        currentHealth -= GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>().getDamage();
        healthBar.updateHealth(currentHealth, maxHealth);
        yield return new WaitForSeconds(1f);
        isHealthReducing = false;
    }
}
