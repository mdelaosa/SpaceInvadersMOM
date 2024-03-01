using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public AudioSource audioSource;
    public AudioClip shootingClip;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            audioSource.PlayOneShot(shootingClip);
        }
    }
}
