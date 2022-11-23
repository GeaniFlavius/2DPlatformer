using UnityEngine;

public class Look : MonoBehaviour
{
    private Transform firePoint;
    private Vector2 lookDirection;
    private float lookAngle;
    private Camera mainCamera;
    private Quaternion rotation;
    private float distanceToPoint;

    private void Awake()
    {
        firePoint = GetComponentInChildren<Transform>().Find("FirePoint");
        mainCamera = Camera.main;
    }

    public void LookDirection(Vector2 position)
    {
        lookDirection = mainCamera.ScreenToWorldPoint(position) - firePoint.position;
        LookAngle(lookDirection);
    }

    private void LookAngle(Vector2 position)
    {
        lookAngle = Mathf.Atan2(position.y, position.x) * Mathf.Rad2Deg;
        Rotation(lookAngle);
    }

    private void Rotation(float angle)
    {
        firePoint.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public Transform FirePoint
    {
        get => firePoint;
    }
    public float Angle
    {
        get => lookAngle;
    }
    
    
}
