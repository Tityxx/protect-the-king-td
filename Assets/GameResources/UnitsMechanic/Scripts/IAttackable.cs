using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackable
{
    public void TakeDamage(float damage);
    public Transform GetPosition();
}