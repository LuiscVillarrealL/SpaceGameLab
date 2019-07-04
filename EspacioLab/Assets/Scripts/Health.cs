using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfLives;

    public Image[] vidas;
    public Sprite vidaLLena;

   
    //public Sprite sinVida;

    public Player player;

    void Update()
    {
        for (int i = 0; i < vidas.Length; i++)
        {
            if (i < numOfLives)
            {
                vidas[i].enabled = true;
            }else
                vidas[i].enabled = false;
        }

        numOfLives = player.health;

    }

    void FixedUpdate()
    {
      
    }

    public void bajarVida()
    {
        numOfLives--;
    }



}
