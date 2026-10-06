using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class ErmsLiveEvent : MonoBehaviour
{
    public string rawPastebin = "https://pastebin.com/raw/your_pastebin_id";
    public GameObject[] enableStuff;
    public GameObject[] disableStuff;

    void Start()
    {
        InvokeRepeating("CheckPastebin", 0f, 300);
    }

    void CheckPastebin()
    {
        StartCoroutine(FetchPastebinData());
    }

    IEnumerator FetchPastebinData()
    {
        UnityWebRequest request = UnityWebRequest.Get(rawPastebin);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string responseText = request.downloadHandler.text;
            if (responseText.Contains("Active: true"))
            {
                SetObjectsActive(true);
            }
            else
            {
                SetObjectsActive(false);
            }
        }
    }

    void SetObjectsActive(bool isActive)
    {
        foreach (GameObject obj in enableStuff)
        {
            obj.SetActive(isActive);
        }

        foreach (GameObject obj in disableStuff)
        {
            obj.SetActive(!isActive);
        }
    }
}
