using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float health = 100;
    [SerializeField] int scoreValue = 150;
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetShots = 0.2f;
    [SerializeField] float maxTimeBetShots = 10f;
    [SerializeField] GameObject proyectile;
    [SerializeField] float proyectileSpeed;
    [SerializeField] GameObject deathVFX;
    [SerializeField] float durationOfExplosion = 1f;
    [SerializeField] AudioClip deathSound;
    [SerializeField] [Range(0,1)] float deathSoundVolume = 0.7f;
    [SerializeField] AudioClip enemyShootSound;
    [SerializeField] [Range(0, 1)] float shootSoundVolume = 0.5f;


    void Start()
    {

        shotCounter = UnityEngine.Random.Range(minTimeBetShots, maxTimeBetShots);
    }

    void Update()
    {
        CountAndShoot();
    }

    private void CountAndShoot()
    {
        shotCounter -= Time.deltaTime;

        if(shotCounter <= 0f)
        {
            Fire();
            shotCounter = UnityEngine.Random.Range(minTimeBetShots, maxTimeBetShots);
        }
    }

    private void Fire()
    {
        GameObject laser = Instantiate(proyectile, transform.position, Quaternion.identity) as GameObject;

        AudioSource.PlayClipAtPoint(enemyShootSound, Camera.main.transform.position, shootSoundVolume);

        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -proyectileSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
       
        if (!damageDealer)
        {
            return;
        }

        Hit(damageDealer);
    }

    private void Hit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            
            Die();
        }
    }

    private void Die()
    {
        FindObjectOfType<Score>().AddToScore(scoreValue);
        Destroy(this.gameObject);
        GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation) as GameObject;
        Destroy(explosion, durationOfExplosion);
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
    }










    /* [SerializeField] float moveSpeed = 1f;
    [SerializeField] float rotSpeed = .4f;
    [SerializeField] float padding = 1f;


    float xMin;
    float xMax;
    float yMin;
    float yMax;

    private int dir = 1;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] PolygonCollider2D pc;

    void Start()
    {
        SetMoveBoundaries();
        rb = GetComponent<Rigidbody2D>();
        pc = GetComponent<PolygonCollider2D>();


    }

    void Update()
    {
        Move();

        if(transform.position.x == xMax || transform.position.x == xMin)
        {
            dir = dir * -1;
        }

    }

    private void Move()
    {
        //movimiento horizontal
        var deltaX = dir * Time.deltaTime * moveSpeed;  //puede usarse el keydown 
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var deltaY = Time.deltaTime * -moveSpeed;
        var newYPos = transform.position.y + deltaY;
       //var newYPos = 
       transform.position = new Vector2(newXPos, newYPos);
    }

    private void SetMoveBoundaries()
    {
        Camera gameCamera = Camera.main;

        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }*/
}
