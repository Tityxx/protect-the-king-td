using System.Collections;
using System.Collections.Generic;
using ToolsAndMechanics.UserInterfaceManager;
using UnityEngine;
using Zenject;

public class WindowsControllerInstaller : MonoInstaller
{
    [SerializeField]
    private WindowsController controller;

    public override void InstallBindings()
    {
        WindowsController c = Container.InstantiatePrefabForComponent<WindowsController>(controller);
        Container.Bind<WindowsController>().FromInstance(c).AsSingle().NonLazy();
    }
}