using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser1 : MonoBehaviour
{
    [Header("Proyectiles")]
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float laserSpeed = 10f;
    [SerializeField] float tiempoDeDisparo = 0.1f;
    [SerializeField] AudioClip playerShootSound;
    [SerializeField] [Range(0, 1)] float shootSoundVolume = 0.5f;

    Coroutine firingCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
          firingCoroutine =  StartCoroutine(DispararContinuo());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
        }
    }

    IEnumerator DispararContinuo()
    {
        while (true)
        {
            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;

            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, laserSpeed);
            AudioSource.PlayClipAtPoint(playerShootSound, Camera.main.transform.position, shootSoundVolume);

            yield return new WaitForSeconds(tiempoDeDisparo);
        }
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       /* if (collision.gameObject.GetComponent<Enemy>())
        {
            print(collision);
            Destroy(collision);
        }*/
        print(collision);
    }
}
