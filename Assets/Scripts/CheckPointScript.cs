using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour
{
    private Collider2D collider;

    private void Start()
    {
        collider = GetComponent<Collider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerScript player = collision.gameObject.GetComponent<PlayerScript>();
        if (!player)
            return;
        collider.enabled = false;
        player.checkPointPosition = new Vector2(transform.position.x, transform.position.y);
    }
}
