using UnityEngine;

public class Flip : MonoBehaviour
{
    public bool facingRight = true;
    private Camera mainCamera;
    public float xPointFromScreen;
    public float xPointFromWorld;

    private void Awake()
    {
        mainCamera = Camera.main;
    }
    
    public void Rotate(Vector2 pointOnscreen)
    {
        xPointFromScreen = mainCamera.ScreenToViewportPoint(pointOnscreen).x;
        xPointFromWorld = mainCamera.WorldToViewportPoint(transform.position).x;
        if (xPointFromScreen > xPointFromWorld && !facingRight || xPointFromScreen < xPointFromWorld && facingRight)
        {
            facingRight = !facingRight;
            transform.Rotate((new Vector3(0, 180, 0)));
        }
    }
}