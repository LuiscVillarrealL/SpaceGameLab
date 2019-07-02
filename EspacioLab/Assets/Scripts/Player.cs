using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Player")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float rotSpeed = .4f;
    [SerializeField] float padding = 1f;
    [SerializeField] int health = 200;
    [SerializeField] [Range(0, 1)] float deathSoundVolume = 0.7f;
    [SerializeField] AudioClip deathSound;


    float xMin;
    float xMax;
    float yMin;
    float yMax;

    [SerializeField] Rigidbody2D rb;

    void Start()
    {
        SetMoveBoundaries();
        rb = GetComponent<Rigidbody2D>();
        

    }

    
    // Update is called once per frame
    void Update()
    {
        Move();
        // Shoot();
       


    }

    private void Shoot()
    {
        
                
    }

    private void Move()
    {

        //movimiento horizontal
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;  //puede usarse el keydown 

        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
 
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2(newXPos, newYPos);



        /*float speedX = rb.velocity.x;
       // print(speedX);
        if (deltaX > .001)
        {
            transform.Rotate(0f, -rotSpeed, 0f);
            print(deltaX);
            
        }else if(deltaX < -.001)
        {
            transform.Rotate(0f, rotSpeed, 0f);
            print(deltaX);

        }
        else
        {
          //  transform.rotation = Quaternion.identity;
        }

    */
        //movimiento vertical
        //var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;


    }

    private void SetMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0,0,0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;

        
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) {
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
        FindObjectOfType<LevelController>().LoadGameOver();
        Destroy(this.gameObject);
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
    }

}
