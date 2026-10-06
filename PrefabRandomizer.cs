using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabRandomizer : MonoBehaviour
{
    [Header("Made By Cqs")]
    [Space]
    [Header("Socials")]
    [Header("Discord - https://discord.gg/4xQuzQPmxq")]
    [Header("Youtube - @CqsTuts")]
    [Space]

    [Header("Prefab")]
    public GameObject Prefab;

    [Header("Spawn Positions")]
    public GameObject[] spawnPositions;

    [Header("Number of Prefab to spawn")]
    public int numberOfPrefabToSpawn = 0;

    void Start()
    {
        if (Prefab == null || spawnPositions.Length == 0)
        {
            Debug.LogError("Prefab or SpawnPositions are not assigned.");
            return;
        }

        if (numberOfPrefabToSpawn <= 0)
        {
            Debug.LogWarning("Warning: No Prefab will spawn when number is 0!");
            return;
        }

        StartCoroutine(SpawnPrefab());
    }

    IEnumerator SpawnPrefab()
    {
        List<int> availableIndices = new List<int>(spawnPositions.Length);
        for (int i = 0; i < spawnPositions.Length; i++)
        {
            availableIndices.Add(i);
        }

        for (int i = 0; i < numberOfPrefabToSpawn; i++)
        {
            if (availableIndices.Count == 0)
            {
                Debug.LogWarning("Not enough available spawn positions!");
                yield break;
            }

            int randomIndex = Random.Range(0, availableIndices.Count);
            int selectedIndex = availableIndices[randomIndex];
            availableIndices.RemoveAt(randomIndex);

            Vector3 spawnPosition = spawnPositions[selectedIndex].transform.position;

            GameObject PrefabInstance = Instantiate(Prefab, spawnPosition, Quaternion.identity);

            yield return null;
        }
    }
}