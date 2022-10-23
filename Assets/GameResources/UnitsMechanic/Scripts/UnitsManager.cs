using System.Collections;
using System.Collections.Generic;
using ToolsAndMechanics.ObjectPool;
using UnityEngine;
using Zenject;

public class UnitsManager : MonoBehaviour, ITeamUnits
{
    public List<BaseUnit> Units => units;

    [SerializeField]
    private List<UnitsManager> enemiesTeams;
    [SerializeField]
    private PoolableObjectData unitData;
    [SerializeField]
    private float spawnDelay = 2f;
    [SerializeField]
    private List<Transform> spawnPoints;

    [Inject]
    private ObjectPoolController pool;

    private List<ITeamUnits> iEnemiesTeams = new List<ITeamUnits>();
    private List<BaseUnit> units = new List<BaseUnit>();

    private void Start()
    {
        foreach (var team in enemiesTeams) iEnemiesTeams.Add(team);
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        while (enabled)
        {
            Vector3 pos = spawnPoints[Random.Range(0, spawnPoints.Count)].position;
            BaseUnit unit = pool.GetObject(unitData, pos, true).GetComponent<BaseUnit>();
            units.Add(unit);
            unit.Spawn(this, iEnemiesTeams);

            yield return new WaitForSeconds(spawnDelay);
        }
    }
}