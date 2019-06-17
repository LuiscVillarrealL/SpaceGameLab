using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
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
    }
}
