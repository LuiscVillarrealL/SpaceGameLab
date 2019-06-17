using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float rotSpeed = .4f;
    [SerializeField] float padding = 1f;
    

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
        Shoot();
        


    }

    private void Shoot()
    {
        
                
    }

    private void Move()
    {

        //movimiento horizontal
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;  //puede usarse el keydown 
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        transform.position = new Vector2(newXPos, transform.position.y);

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
    }

}
