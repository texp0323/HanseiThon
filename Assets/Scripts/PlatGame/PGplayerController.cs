using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PGplayerController : MonoBehaviour
{
    [SerializeField] private PGplayer1Movement pGplayer1;
    [SerializeField] private PGplayer2Movement pGplayer2;
    [SerializeField] private PGcam pGcam;
    static public int pinPlayer = 1;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (pinPlayer == 1) { pinPlayer = 2; }
            else if (pinPlayer == 2) { pinPlayer = 1; }
            ChangeForm();
        }
    }

    private void ChangeForm()
    {
        if (pinPlayer == 1)
        {
            pGplayer2.StopWalk();
            pGplayer2.enabled = false;
            pGplayer1.enabled = true;
        }
        if (pinPlayer == 2)
        {
            pGplayer1.StopWalk();
            pGplayer1.enabled = false;
            pGplayer2.enabled = true;
        }
    }
}
