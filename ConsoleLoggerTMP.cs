using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class ConsoleLoggerTMP : MonoBehaviour
{
    [Header("Made By Cqs")]
    [Space]
    [Header("Socials")]
    [Header("Discord - https://discord.gg/4xQuzQPmxq")]
    [Header("Youtube - @CqsTuts")]
    [Space]

    [Header("Console Text")]
    public TextMeshPro consoleText;
    [Space]
    [Header("Time To Clear")]
    public float TimerToClearText = 10f; 
    private List<string> consoleMessages = new List<string>();

    void OnEnable() => Application.logMessageReceived += HandleLog;

    void OnDisable() => Application.logMessageReceived -= HandleLog;

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        consoleMessages.Add(logString);
        consoleText.text = string.Join("\n", consoleMessages.ToArray());
        StartCoroutine(ClearConsoleText());
    }

    IEnumerator ClearConsoleText()
    {
        yield return new WaitForSeconds(TimerToClearText);
        consoleMessages.Clear();
        consoleText.text = "";
    }
}
