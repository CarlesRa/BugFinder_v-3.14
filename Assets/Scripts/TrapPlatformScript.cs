using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPlatformScript : MonoBehaviour
{
    private BoxCollider2D rigidbody2;
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        rigidbody2 = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
            StartCoroutine(DisableBoxColaider2D());
    }

    IEnumerator DisableBoxColaider2D()
    {
        Debug.Log("Colission enter");
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(1);
        rigidbody2.enabled = false;
        StartCoroutine(EnableBoxColider2D());
    }

    IEnumerator EnableBoxColider2D()
    {
        yield return new WaitForSeconds(1);
        rigidbody2.enabled = true;
        spriteRenderer.color = Color.white;
    }
}
