using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class ErmsEventSystem : MonoBehaviour
{
    [Header("MADE BY Ermology (@erm.dev) | DO NOT STEAL OR CLAIM AS YOURS")]
    [Space]

    [Header("What Invokes the Event")]
    [Tooltip("Determines if the event is invoked On Trigger Enter")]
    public bool TriggerEnter;
    [Tooltip("Determines if the event is invoked On Trigger Exit")]
    public bool TriggerExit;
    [Tooltip("Determines if the event is invoked On Awake")]
    public bool onAwake;
    [Tooltip("Determines if the event is invoked On Disable")]
    public bool Disable;
    [Tooltip("Determines if the event is invoked On Start")]
    public bool onStart;
    [Tooltip("Determines if the event is invoked On Enable")]
    public bool Enabled;
    [Tooltip("Determines if the event is invoked On Disabled")]
    public bool Disabled;
    [Header("The Unity Event")]
    [Tooltip("The Unity Event that gets Invoked")]
    public UnityEvent theEvent;
    [Header("ONLY FOR ON TRIGGER")]
    [Tooltip("The tag that activates the event")]
    public string Tag;
    [Tooltip("Determines if you use a tag to invoke the event")]
    public bool useTag;
    [Header("Debug")]
    [Tooltip("USED TO INVOKE THE EVENT THROUGH THE EDITOR")]
    public bool editorToggle;


    // Use this for initialization
    void Start()
    {
        if (onStart)
        {
            theEvent.Invoke();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (editorToggle)
        {
            theEvent.Invoke();
            editorToggle = false;
        }
    }

    void Awake()
    {
        if (onAwake)
        {
            theEvent.Invoke();
        }
    }

    void OnEnable()
    {
        if (Enabled)
        {
            theEvent.Invoke();
        }
    }

    void OnDisable()
    {
        if (Disable)
        {
            theEvent.Invoke();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (TriggerEnter)
        {
            if (useTag)
            {
                if (other.CompareTag(Tag))
                {
                    theEvent.Invoke();
                }
            }
            else
            {
                theEvent.Invoke();
            }
        }
    }

    void OnTriggerExit()
    {
        if (TriggerExit)
        {
            theEvent.Invoke();
        }
    }
}
