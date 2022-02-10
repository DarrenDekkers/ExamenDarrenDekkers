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


    public GameObject player;
    private PlayerMover playerMover;
    [SerializeField] private Rigidbody rb;

    public int currentAmmo = 1;
   public int maxAmmo = 1;


    void Awake()
    {
        playerMover = player.GetComponent<PlayerMover>();
        rb = player.GetComponent<Rigidbody>();



    }

    void Update()
    {
        print(playerMover.currentDir);
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;


        }
    }

    void shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(ShotStart.position, ShotStart.forward, out hit, range) && currentAmmo != 0)
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

    public void AmmoChange(int ammoDif)
    {

        currentAmmo += ammoDif;
    }
}
