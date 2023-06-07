using UnityEngine;

public class moveToward : MonoBehaviour
{

    [SerializeField] float speed = 10;
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
