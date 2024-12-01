using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CommandRunner : MonoBehaviour
{
    [SerializeField] private Command command;
    private Button _button;
    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(HandleClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(HandleClick);
    }

    private void HandleClick()
    {
        if(command != null)
        {
            var input = GameObject.FindObjectOfType<TMP_InputField>().text;
            string[] args = input.Split(' ');
            command.Execute(args);
        }
        else
            Debug.LogError($"{name}: {nameof(command)} is null!", gameObject);
    }
}
