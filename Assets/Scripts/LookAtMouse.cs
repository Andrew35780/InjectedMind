using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    [SerializeField] private FieldOfView fieldOfView;

    void Update()
    {
        Vector3 WorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Vector3 Difference = (WorldPoint - transform.position).normalized;


        fieldOfView.SetAimDirection(WorldPoint.normalized);
        fieldOfView.SetOrigin(transform.position);
    }
}
