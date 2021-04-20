using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Camera camera;
    public float orthographicSize = 5;
    public float aspect = 1.33333f;
    void Start()
    {
        camera = this.gameObject.GetComponent<Camera>();
        Camera.main.projectionMatrix = Matrix4x4.Ortho(
                -orthographicSize * aspect, orthographicSize * aspect,
                -orthographicSize, orthographicSize,
                camera.nearClipPlane, camera.farClipPlane);
    }
}
