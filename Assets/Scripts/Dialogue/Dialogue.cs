using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    
    public string[] sentences;
    public bool[] dialogueTurn;
    public int id;
    public int nextId;
    public Quest quest;

    public int getNext()
    {
        if (quest.complete)
        {
            return nextId;
        }

        return id;
    }
}
