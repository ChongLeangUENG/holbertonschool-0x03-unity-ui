using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset = new Vector3(0f, 10f, -10f);

    private void Update()
    {
        if (player != null)
        {
            Vector3 desiredPosition = player.transform.position + offset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime);
        }
    }
}
