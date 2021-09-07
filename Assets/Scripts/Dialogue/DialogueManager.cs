using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject DialogueBox;
    public Button NextSpeech;
    public Text NpcName;
    public Text CurrentSpeech;
    public GameObject FoxTurn;
    public GameObject NpcTurn;
    public string name;
    public string[] sentences;
    public bool[] dialogueTurn;
    private int sentenceNum;

    private void Start()
    {
        NpcName.text = name;
        sentenceNum = 0;
        NextSpeech.onClick.AddListener(() => NextSentence());
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        EndDialogue();
    }

    public void EndDialogue()
    {
        DialogueBox.SetActive(false);
        NextSpeech.onClick.RemoveListener(() => NextSentence());
        sentenceNum = 0;
    }

    public void NextSentence()
    {
        if (sentenceNum < sentences.Length)
        {
            if (dialogueTurn[sentenceNum])
            {
                FoxTurn.SetActive(true);
                NpcTurn.SetActive(false);
            }
            else
            {
                FoxTurn.SetActive(false);
                NpcTurn.SetActive(true);
            }

            CurrentSpeech.text = sentences[sentenceNum];
            sentenceNum++;
        }
        else
        {
            EndDialogue();
        }
    }
}

