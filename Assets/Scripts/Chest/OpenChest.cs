using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenChest : MonoBehaviour
{
    public Button actionButton;
    public Quest Quest;
    private SpriteRenderer spriteRenderer;
    public Sprite openChestSprite;
    public bool isOpen;

    private void Start()
    {
        actionButton.onClick.AddListener(() => Open());
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Open()
    {
        isOpen = true;
        spriteRenderer.sprite = openChestSprite;
        actionButton.gameObject.SetActive(false);
        if (Quest!=null)
        {
            Quest.FinishQuest();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isOpen)
        {
            actionButton.gameObject.SetActive(false);
        }
    }
}
