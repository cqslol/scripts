using System;
using UnityEngine;
using Photon.Voice.Unity;
using easyInputs;

public class WalkieTalkie : MonoBehaviour
{
    [Header("Script made by Lix ♥")]
    [Space]
    [Header("Settings")]
    [Space]
    public EasyHand walkieTalkieHand;
    public activationType activationType;
    [Space]
    public Recorder recorder;

    private void Start()
    {
        if (recorder == null)
        {
            Debug.LogError($"Recorder is not assigned! Please assign a Recorder component to the '{gameObject.name}' GameObject for proper functionality.");
        }
    }

    private void Update()
    {
        if (recorder != null)
        {
            recorder.TransmitEnabled = activationType switch
            {
                activationType.Trigger => EasyInputs.GetTriggerButtonDown(walkieTalkieHand),
                activationType.Grip => EasyInputs.GetGripButtonDown(walkieTalkieHand)
            };
        }
    }

    private void OnDisable()
    {
        recorder.TransmitEnabled = true;
    }
}

public enum activationType
{
    Trigger,
    Grip
}