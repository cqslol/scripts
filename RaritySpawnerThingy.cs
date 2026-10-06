using UnityEngine;

public class RaritySpawnerThingy : MonoBehaviour {

    [Header("Script made by pxpp, It's my first script so")]
    [Header("sorry if it fucking sucks.")]
    [Header("credit would be nice")]
    [Header("Edited by Cqs")]
    [Header("Added Percentaged")]
    public GameObject spawningShit;
    [Range(0f, 100f)]
    public float rarityPercentage = 5f;
    bool shouldtheshitSpawn;

    void Start() {
        spawningShit.SetActive(false);

        float randomValue = Random.Range(0f, 100f);
        shouldtheshitSpawn = (randomValue <= rarityPercentage);

        if (shouldtheshitSpawn) {
            spawningShit.SetActive(true);
        }
    }
}
