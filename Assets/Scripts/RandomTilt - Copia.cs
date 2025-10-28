using UnityEngine;

public class RandomTilt : MonoBehaviour
{
    [SerializeField] private float maxTiltAngle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void ApplyRandomTilt()
    {   
        float randomZRotation = Random.Range(-maxTiltAngle, maxTiltAngle);
        transform.rotation = Quaternion.Euler(0f, 0f, randomZRotation);
    }

    void Start()
    {
        ApplyRandomTilt();
    }

    
    
}
