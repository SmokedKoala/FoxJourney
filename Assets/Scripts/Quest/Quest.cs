using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public bool complete;
    public string description;

    public void FinishQuest()
        {
            complete = true;
        }
}
