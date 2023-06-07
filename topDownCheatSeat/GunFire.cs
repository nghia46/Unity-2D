using UnityEngine;

public class GunFire : MonoBehaviour
{
    [SerializeField] AudioSource gunShotGFX;
    [SerializeField] GameObject bullet;
    [SerializeField] ParticleSystem ps;
    [SerializeField] float fireRate = 0.2f; // Adjust the fire rate as desired

    private float lastFireTime;

    private void Start()
    {
        lastFireTime = -fireRate; // Set an initial value to allow firing immediately
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time - lastFireTime > fireRate)
        {
            Fire();
            PlayGunfireSound();
            PlayParticle();
            lastFireTime = Time.time;
        }
    }

    private void Fire()
    {
        Quaternion bulletRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - 90f);
        GameObject bulletObject = Instantiate(bullet, transform.position, bulletRotation, GameObject.Find("Bullet Parent").transform);
    }

    private void PlayParticle()
    {
        ps.Play();
    }

    private void PlayGunfireSound()
    {
        gunShotGFX.Play();
    }
}
