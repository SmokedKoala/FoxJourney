using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestTrigger : MonoBehaviour
{
    public GameObject actionButton;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        actionButton.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        actionButton.SetActive(false);
    }
}
