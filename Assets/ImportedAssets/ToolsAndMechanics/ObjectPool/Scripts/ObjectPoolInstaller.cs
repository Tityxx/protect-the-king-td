using System;
using System.Collections;
using System.Collections.Generic;
using ToolsAndMechanics.ObjectPool;
using UnityEngine;
using Zenject;

public class ObjectPoolInstaller : MonoInstaller
{
    [SerializeField]
    private ObjectPoolController controller;

    public override void InstallBindings()
    {
        ObjectPoolController p = Container.InstantiatePrefabForComponent<ObjectPoolController>(controller);
        Container.Bind<ObjectPoolController>().FromInstance(p).AsSingle().NonLazy();
    }
}