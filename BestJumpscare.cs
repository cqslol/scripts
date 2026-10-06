using System.Collections;
using UnityEngine;

public class BestJumpscare : MonoBehaviour
{
    [Header("Made By Cqs")]
    [Space]
    [Header("Socials")]
    [Header("Discord - https://discord.gg/4xQuzQPmxq")]
    [Header("Youtube - @CqsTuts")]
    [Space]
    [Header("Player")]
    public GameObject GorillaPlayer;

    [Header("Teleportation")]
    public GameObject TeleportTo;

    [Header("Walls")]
    public GameObject[] WallsToDisable;
    public float DisableTime;

    [Header("Jumpscare")]
    public GameObject objectToEnable;
    public float enableTime = 1.0f;
    public string targetTag = "Player";

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag) && other.gameObject.GetComponent<Collider>().enabled)
        {
            DisableWalls();
            StartCoroutine(TeleportAndDisableKinematic());

            ActivateJumpscare();
            StartCoroutine(DisableAfterDelay(enableTime));
        }
    }

    private void DisableWalls()
    {
        foreach (GameObject obj in WallsToDisable)
        {
            obj.SetActive(false);
        }
    }

    private IEnumerator TeleportAndDisableKinematic()
    {
        Rigidbody gorillaRigidbody = GorillaPlayer.GetComponent<Rigidbody>();
        if (gorillaRigidbody != null)
        {
            gorillaRigidbody.isKinematic = true;
        }

        GorillaPlayer.transform.position = TeleportTo.transform.position;

        yield return new WaitForSeconds(DisableTime);

        if (gorillaRigidbody != null)
        {
            gorillaRigidbody.isKinematic = false;
        }

        EnableWalls();
    }

    private void EnableWalls()
    {
        foreach (GameObject obj in WallsToDisable)
        {
            obj.SetActive(true);
        }
    }

    private void ActivateJumpscare()
    {
        objectToEnable.SetActive(true);
    }

    private IEnumerator DisableAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        objectToEnable.SetActive(false);
    }
}
