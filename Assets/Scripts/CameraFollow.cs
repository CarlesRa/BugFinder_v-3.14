using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    private void Update()
    {
        if (player == null)
            return;
        Vector3 position = transform.position;
        position.x = player.transform.position.x;
        transform.position = position;
        if (heart1 == null)
            return;
        heart1.transform.position = new Vector2(transform.position.x - 1.90f, transform.position.y + 0.93f);
        if (heart2 != null)
            heart2.transform.position = new Vector2(transform.position.x - 1.79f, transform.position.y + 0.93f);
        if (heart3 != null)
            heart3.transform.position = new Vector2(transform.position.x - 1.68f, transform.position.y + 0.93f);
    }
}
