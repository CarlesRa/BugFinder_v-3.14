using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour
{
    private Collider2D _collider;

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerScript player = collision.GetComponent<PlayerScript>();
        if (!player)
            return;
        _collider.enabled = false;
        player.checkPointPosition = new Vector2(transform.position.x, transform.position.y);
        StartCoroutine(resetCollider());
    }

    IEnumerator resetCollider()
    {
        yield return new WaitForSeconds(5);
        _collider.enabled = true;
    }
}
