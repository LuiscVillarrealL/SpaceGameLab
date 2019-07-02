using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroide : MonoBehaviour
{
    public float tumble;
    private Rigidbody2D rb;



    void Start()
    {
        rb.angularVelocity = UnityEngine.Random.Range(-tumble, tumble) ;
    }
    void Awake()
    {
        rb.angularVelocity = UnityEngine.Random.Range(-tumble, tumble);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        print("colllide");


        if (other.gameObject.GetComponent<DamageDealer>() && !other.gameObject.GetComponent<Enemy>())
        {
            DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();

            print("hit collider 2d");
            Destroy(other.gameObject);
            Destroy(gameObject);
        } else if (other.gameObject.GetComponent<Player>()){
            Player player = other.gameObject.GetComponent<Player>();
            Destroy(player.gameObject);
            Destroy(gameObject);

            print("hit collider 3d");
        } else
            return;



    }




}

