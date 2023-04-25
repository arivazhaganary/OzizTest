using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 1f;
    public float zoomSpeed = 1f;

    public Camera camera;
    private Vector3 lastMousePosition;

    private void Start()
    {
       
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - lastMousePosition;
            camera.transform.position += new Vector3(-delta.x, 0, -delta.y) * camera.orthographicSize * moveSpeed * Time.deltaTime;
            lastMousePosition = Input.mousePosition;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        camera.orthographicSize -= scroll * zoomSpeed * camera.orthographicSize;

        camera.orthographicSize = Mathf.Clamp(camera.orthographicSize, 5f, 20f);
    }
}
