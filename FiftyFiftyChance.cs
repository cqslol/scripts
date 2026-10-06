using UnityEngine;

public class FiftyFiftyChance : MonoBehaviour
{
    public Collider collider1;
    public Collider collider2;

    void Start()
    {
        int randomIndex = Random.Range(0, 2);
        collider1.enabled = randomIndex == 0;
        collider2.enabled = randomIndex == 1;
    }
}
