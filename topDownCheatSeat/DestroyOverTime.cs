using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    [SerializeField] float time;
    private void LateUpdate()
    {
        Invoke("destroyBytime",time);
    }
    private void destroyBytime()
    {
        Destroy(gameObject);
    }
}
