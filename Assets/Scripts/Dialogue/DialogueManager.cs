using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject DialogueBox;
    public Button NextSpeech;
    public Text NpcName;
    public Text CurrentSpeech;
    public GameObject PlayerTurn;
    public GameObject NpcTurn;
    
    public string Name;
    public Dialogue[] Dialogues;
    private Queue<string> sentencesQueue;
    private Queue<bool> turnsQueue;
    private int dialogueId = 0;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (dialogueId != 0)
        {
            dialogueId = Dialogues[dialogueId].getNext();
        }
        sentencesQueue = new Queue<string>(Dialogues[dialogueId].sentences);
        turnsQueue = new Queue<bool>(Dialogues[dialogueId].dialogueTurn);
        NpcName.text = Name;
        NextSpeech.onClick.AddListener(() => NextSentence());
        CurrentSpeech.text = sentencesQueue.Dequeue();
        turnsQueue.Dequeue();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        EndDialogue();
        if (dialogueId == 0)
        {
            dialogueId = Dialogues[dialogueId].getNext();
        }
    }

    public void EndDialogue()
    {
        DialogueBox.SetActive(false);
        NextSpeech.onClick.RemoveAllListeners();
    }

    public void NextSentence()
    {
        if (sentencesQueue.Count>0)
        {
            if (turnsQueue.Dequeue())
            {
                PlayerTurn.SetActive(true);
                NpcTurn.SetActive(false);
            }
            else
            {
                PlayerTurn.SetActive(false);
                NpcTurn.SetActive(true);
            }

            CurrentSpeech.text = sentencesQueue.Dequeue();
        }
        else
        {
            EndDialogue();
        }
    }
}

