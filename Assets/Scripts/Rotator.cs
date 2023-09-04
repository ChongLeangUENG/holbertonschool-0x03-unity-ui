using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    void Update()
    {
        // Rotate the coin around the x-axis over time
        transform.Rotate(new Vector3(45, 0, 0) * Time.deltaTime);
    }
}
