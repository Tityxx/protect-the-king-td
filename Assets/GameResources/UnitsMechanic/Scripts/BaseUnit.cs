using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ToolsAndMechanics.ObjectPool;
using ToolsAndMechanics.Utilities;
using UnityEngine;
using Zenject;

public class BaseUnit : MonoBehaviour, IPoolableObject, IAttackable
{
    [SerializeField]
    protected HealthComponent health;
    [SerializeField]
    protected MovementComponent movement;
    [SerializeField]
    protected AttackComponent attack;

    protected ObjectPoolController objectPool;
    protected PoolableObjectData poolData;

    protected ITeamUnits alliesTeam;
    protected List<ITeamUnits> enemiesTeams;

    public virtual void Spawn(ITeamUnits allies, List<ITeamUnits> enemies)
    {
        alliesTeam = allies;
        enemiesTeams = enemies;
        health.ResetHealth();
        health.onDied += OnDied;
    }

    protected virtual void OnDisable()
    {
        health.onDied -= OnDied;
    }

    protected virtual void Update()
    {
        var nearest = FindNearestEnemy();
        movement?.UpdateMove(nearest.GetPosition().position);
        movement?.UpdateRotation(nearest.GetPosition().position);
        attack?.SetTarget(nearest);
    }

    public void InitPoolableObject(ObjectPoolController pool, PoolableObjectData data)
    {
        objectPool = pool;
        poolData = data;
    }

    public void TakeDamage(float damage)
    {
        health.Health -= damage;
        transform.GetChild(0).DOScale(0.8f, 0.25f).SetLoops(2, LoopType.Yoyo);
    }

    public Transform GetPosition()
    {
        return transform;
    }

    protected virtual void OnDied()
    {
        objectPool.ReturnObject(gameObject, poolData);
    }

    private IAttackable FindNearestEnemy()
    {
        IAttackable nearest = null;
        float minDistance = float.MaxValue;
        foreach (var team in enemiesTeams)
        {
            var units = team.Units.Where(c => Utilities.IsDistanceLess2D(GetPosition().position, c.GetPosition().position, minDistance));
            foreach (var unit in units)
            {
                float d = Utilities.GetDistance2D(GetPosition().position, unit.GetPosition().position);
                if (d < minDistance)
                {
                    minDistance = d;
                    nearest = unit;
                }
            }
        }
        return nearest;
    }
}