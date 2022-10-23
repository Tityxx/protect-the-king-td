using System.Collections;
using System.Collections.Generic;
using ToolsAndMechanics.Utilities;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    [SerializeField]
    protected float movementSpeed = 1f;
    [SerializeField]
    protected float rotationSpeed = 1f;
    [SerializeField]
    protected float stopDistance = 1.5f;

    public virtual void UpdateMove(Vector3 target)
    {
        if (!Utilities.IsDistanceLess2D(transform.position, target, stopDistance))
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime, Space.Self);
    }

    public virtual void UpdateRotation(Transform target)
    {
        Vector3 t = transform.position;
        if (target == null)
        {
            Vector2 random = Random.insideUnitCircle * 10f;
            t += new Vector3(random.x, 0f, random.y);
        }
        UpdateRotation(t);
    }

    public virtual void UpdateRotation(Vector3 target)
    {
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, target - transform.position, rotationSpeed * Time.deltaTime, 0f);

        var lookRotation = Quaternion.LookRotation(newDirection);
        lookRotation.x = 0;
        lookRotation.z = 0;

        transform.rotation = lookRotation;
    }
}