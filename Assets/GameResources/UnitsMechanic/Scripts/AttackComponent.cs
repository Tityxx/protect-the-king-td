using System;
using System.Collections;
using System.Collections.Generic;
using ToolsAndMechanics.Utilities;
using UnityEngine;

public class AttackComponent : MonoBehaviour
{
    public event Action onAttack = delegate { };

    [SerializeField]
    protected float attackDistance = 1.6f;
    [SerializeField]
    protected float attacksPerSecond = 1f;
    [SerializeField]
    protected float damage = 2f;

    protected IAttackable target;

    protected virtual void OnEnable()
    {
        StartCoroutine(AttackCoroutine());
    }

    public void SetTarget(IAttackable t)
    {
        target = Utilities.IsDistanceLess2D(t.GetPosition().position, transform.position, attackDistance) ? t : null;
    }

    private IEnumerator AttackCoroutine()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(1 / attacksPerSecond);
            Attack();
        }
    }

    protected virtual void Attack()
    {
        if (target == null) return;

        target.TakeDamage(damage);
        onAttack();
    }
}