using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogue : MonoBehaviour
{
    public GameObject DialogueBox;

    public void StartDialogueBox()
    {
        DialogueBox.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
