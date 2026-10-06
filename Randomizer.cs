using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizer : MonoBehaviour
{
    [Header("Script made by Lix ♥")]
    [Space]
    [SerializeField] private GameObject[] Objects;

    private void Start()
    {
        foreach(GameObject game in Objects)
        {
            game.SetActive(false);
        }

        Objects[Random.Range(0, Objects.Length)].SetActive(true);
    }
}
