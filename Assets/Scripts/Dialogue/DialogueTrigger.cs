using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject talkButton;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        talkButton.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        talkButton.SetActive(false);
    }
}
