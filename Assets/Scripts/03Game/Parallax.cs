using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public GameObject[] levels;
    private Camera mainCamera;
    private Vector2 screenBounds;
    public float choke;
    public float scrollSpeed;

    private Vector3 lastScreenPosition;

    void Start()
    {
        mainCamera = gameObject.GetComponent<
            Camera>();
        screenBounds =
            mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        lastScreenPosition = transform.position;
    }

    void Update()
    {
        Vector3 velocity = Vector3.zero;
        Vector3 desiredPosition = transform.position + new Vector3(scrollSpeed, 0, 0);
        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, 0.3f);
        transform.position = smoothPosition;
    }

    void LateUpdate()
    {
        foreach (GameObject obj in levels)
        {
            float parallaxSpeed = 1 - Mathf.Clamp01(Mathf.Abs(transform.position.z / obj.transform.position.z));
            float difference = transform.position.x - lastScreenPosition.x;
            obj.transform.Translate(Vector3.right * difference * parallaxSpeed);
        }

        lastScreenPosition = transform.position;
    }
}