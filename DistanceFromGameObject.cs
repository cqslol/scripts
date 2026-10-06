using Photon.Pun;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

[System.Serializable]
public class DistanceObjects
{
    public GameObject GM;
    public bool isActive;
}

public class DistanceFromGameObject : MonoBehaviour
{
    [Header("Script made by Lix ♥")]
    [Space]
    [Header("GameObjects")]
    [Space]
    public List<DistanceObjects> distanceObjects = new List<DistanceObjects>();
    [SerializeField] private GameObject player;
    public bool thisIsPlayer;
    [Space]
    [Header("Text Object")]
    [Space]
    [SerializeField] private TMP_Text text;
    [Space]
    [Unity.XR.CoreUtils.ReadOnly]
    public string Distance;
    [Unity.XR.CoreUtils.ReadOnly]
    public string CurrentGameObjectSee;

    // variables
    [Unity.XR.CoreUtils.ReadOnly]
    [SerializeField]
    private bool metric;
    [Unity.XR.CoreUtils.ReadOnly]
    [SerializeField]
    private bool imperial;
    [Space]
    [Unity.XR.CoreUtils.ReadOnly]
    public bool InRoom;

    private GameObject currentGameObject;

    // Start is called before the first frame update
    void Start()
    {
        RegionInfo regionInfo = RegionInfo.CurrentRegion;

        if (regionInfo.IsMetric)
        {
            metric = true;
        }
        else
        {
            imperial = true;
        }

        if (player == null)
        {
            if (thisIsPlayer)
            {
                player = this.gameObject;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PhotonNetwork.InLobby || PhotonNetwork.InRoom)
        {
            InRoom = true;
            #region Checker
            foreach (DistanceObjects distanceObject in distanceObjects)
            {
                Debug.Log(distanceObject);
                if (distanceObject.GM != null)
                {
                    if (distanceObject.isActive == true)
                    {
                        distanceObject.GM.SetActive(true);
                        currentGameObject = distanceObject.GM;
                    }
                    else
                    {
                        distanceObject.GM.SetActive(false);
                        if (currentGameObject == distanceObject.GM)
                        {
                            currentGameObject = null;
                        }
                    }
                }
            }
            #endregion Checker

            if (currentGameObject != null)
            {
                Vector3 _GM = currentGameObject.transform.position;
                Vector3 _player = player.transform.position;

                float _distance = Vector3.Distance(_player, _GM);

                if (metric)
                {
                    int distance = Mathf.RoundToInt(_distance);
                    string unit = distance > 1 ? "meters" : "meter";
                    text.text = $"{distance} {unit}";
                    Distance = $"{distance} {unit}";
                }

                else if (imperial)
                {
                    float __distance = _distance * 3.280839895f;
                    int distance = Mathf.RoundToInt(__distance);
                    string unit = distance > 1 ? "feet" : "foot";
                    text.text = $"{distance} {unit}";
                    Distance = $"{distance} {unit}";
                }
            }
        }
    }
}