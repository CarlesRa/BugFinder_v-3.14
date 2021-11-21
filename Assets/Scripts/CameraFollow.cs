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
    }
}
