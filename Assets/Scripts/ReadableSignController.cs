using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(SpriteRenderer))]
public class ReadableSignController : Interactable
{
    public Canvas panel;
    public TextMeshProUGUI textMesh;
    public string messageText;

    private TextMeshProUGUI _textMeshProUGUI;

    void Start()
    {
        panel.gameObject.SetActive(false);
    }

    public override void Interact()
    {
        textMesh.text = messageText;
        panel.gameObject.SetActive(true);
    }
}