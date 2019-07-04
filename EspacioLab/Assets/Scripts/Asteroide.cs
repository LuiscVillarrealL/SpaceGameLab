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
        rb = GetComponent<Rigidbody2D>();
        rb.angularVelocity = UnityEngine.Random.Range(-tumble, tumble) ;
    }
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.angularVelocity = UnityEngine.Random.Range(-tumble, tumble);
       // transform.rotation = new Quaternion(UnityEngine.Random.Range(-tumble, tumble), UnityEngine.Random.Range(-tumble, tumble), 0, 0);
        transform.Rotate(UnityEngine.Random.Range(-tumble, tumble), UnityEngine.Random.Range(-tumble, tumble), UnityEngine.Random.Range(-tumble, tumble));

    }


    void Update()
    {
        transform.Rotate(UnityEngine.Random.Range(-tumble, tumble), UnityEngine.Random.Range(-tumble, tumble), UnityEngine.Random.Range(-tumble, tumble));
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
            player.GolpeAsteroide();
            Destroy(gameObject);

            print("hit collider 3d");
        } else
            return;



    }




}

