using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int damage = 10;
    public float range = 100f;
    public float fireRate = 15f;

    public Transform ShotStart;

    private float nextTimeToFire = 0f;

    [SerializeField] AudioSource speaker;
    [SerializeField] float force = 10f;

    public GameObject player;
    private PlayerMover playerMover;
    [SerializeField] private Rigidbody rb;

    void Awake()
    {
        playerMover = player.GetComponent<PlayerMover>();
        rb = player.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            
        }
    }

    void shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(ShotStart.position, ShotStart.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            EnemyDamage enemydamage = hit.transform.GetComponent<EnemyDamage>();
            if (enemydamage != null)
            {
                enemydamage.TakeDamage(damage);
            }
        }
    }


    void PlayClip(AudioClip clip)
    {
        speaker.PlayOneShot(clip);
    }

    void KnockBack()
    {
        
        rb.AddForce(Vector3.up * 200);
    }

}
