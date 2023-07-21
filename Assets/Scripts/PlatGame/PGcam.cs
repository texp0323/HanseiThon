using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PGcam : MonoBehaviour
{
    [SerializeField] private Transform player1;
    [SerializeField] private Transform player2;
    private float pinX;

    void Update()
    {
        if(PGplayerController.pinPlayer == 1)
            pinX = player1.position.x;
        if(PGplayerController.pinPlayer == 2)
            pinX = player2.position.x;
        transform.position = Vector3.Lerp(transform.position,
            new Vector3(pinX + 3, transform.position.y, -10), Time.deltaTime * 7);
    }
}
