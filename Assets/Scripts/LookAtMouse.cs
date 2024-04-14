using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    [SerializeField] private FieldOfView fieldOfView;

    void Update()
    {
        Vector3 WorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        fieldOfView.SetAimDirection(WorldPoint.normalized);
        fieldOfView.SetOrigin(transform.position);
    }
}
