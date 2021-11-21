using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinxoScript : MonoBehaviour
{
    private bool colisionEnter;
    private void Start()
    {
        colisionEnter = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerScript player = collision.gameObject.GetComponent<PlayerScript>();
        if (player != null)
        {
            if (colisionEnter == false)
            {
                colisionEnter = true;
                player.LoseLife();
            }    
            player.animator.SetBool("IsPlayerDeath", true);
            player.canMove = false;
        }
            
        StartCoroutine(goPlayerToInitialPosition(collision));
    }

    IEnumerator goPlayerToInitialPosition(Collision2D collision)
    {
        yield return new WaitForSeconds(1.90f);
        PlayerScript player = collision.gameObject.GetComponent<PlayerScript>();
        if (player != null)
            player.animator.SetBool("IsPlayerDeath", false);
        player.goToInitialPosition();
        colisionEnter = false;
    }
}
