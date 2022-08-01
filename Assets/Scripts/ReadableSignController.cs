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
    private bool _isActive;

    void Start()
    {
        _isActive = false;
        panel.gameObject.SetActive(_isActive);
    }

    public override void Interact()
    {
        textMesh.text = messageText;
        _isActive = !_isActive;

        panel.gameObject.SetActive(_isActive);
    }
}