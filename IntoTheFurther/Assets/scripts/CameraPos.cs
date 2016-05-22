using UnityEngine;
using System.Collections;

public class CameraPos : MonoBehaviour {

    public Camera cam;

    void OnDrawGizmos()
    {

        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 1));
    }
}
