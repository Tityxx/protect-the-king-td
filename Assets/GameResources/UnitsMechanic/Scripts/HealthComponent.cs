using System;
using System.Collections;
using System.Collections.Generic;
using ToolsAndMechanics.Utilities;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public event Action<float> onHealthChange = delegate { };
    public event Action onDied = delegate { };

    public float Health
    {
        get
        {
            return currentHealth;
        }
        set
        {
            currentHealth = Math.Max(value, 0);
            onHealthChange(currentHealth);
            if (currentHealth <= 0 && canDied)
            {
                Died();
            }
        }
    }

    public float MaxHealth => health;

    [SerializeField]
    private float health = 15f;
    [SerializeField, CustomReadOnly]
    private float currentHealth;

    private bool canDied = true;

    protected virtual void Awake()
    {
        ResetHealth();
    }

    public virtual void ResetHealth()
    {
        Health = health;
        canDied = true;
    }

    protected virtual void Died()
    {
        canDied = false;
        onDied();
    }
}