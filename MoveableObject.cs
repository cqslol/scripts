using UnityEngine;

public class MoveableObject : MonoBehaviour
{

    [Header("Up & Down Settings")]
    public float speed = 1f; 
    public float amplitude = 1f; 

    [Header("Spin Settings")]
    public float rotationSpeed = 50f; 
    
    public bool spinLeft = false; 
    public bool spinRight = false; 
    public bool spinVertical = false; 

    private float originalYAxis;

    private void Start()
    {
        originalYAxis = transform.position.y;
    }

    private void Update()
    {
        float newY = originalYAxis + amplitude * Mathf.Sin(speed * Time.time);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        if (spinLeft)
        {
            Rotate(Vector3.up, -rotationSpeed);
        }
        else if (spinRight)
        {
            Rotate(Vector3.up, rotationSpeed);
        }
        else if (spinVertical)
        {
            Rotate(Vector3.right, rotationSpeed);
        }
    }

    private void Rotate(Vector3 axis, float speed)
    {
        transform.Rotate(axis, speed * Time.deltaTime);
    }
}
