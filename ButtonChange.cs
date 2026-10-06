using UnityEngine;

public class ButtonChange : MonoBehaviour
{
    public Material red;
    public Material white;
    public AudioSource sound;

    private Renderer objectRenderer;

    void Start()
    {
        objectRenderer = gameObject.GetComponent<Renderer>();
    }

    void OnTriggerEnter()
    {
        objectRenderer.material = red;
        sound.Play();
    }

    void OnTriggerExit()
    {
        objectRenderer.material = white;
        sound.Stop();
    }
}
