using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyController : MonoBehaviour
{
    [Inject] DiContainer _container;
    [Inject] private IDataService _dataService;
    [Inject] private IEnemyService _enemyService;

    private List<WafeData> _wafes = new List<WafeData>();
    private List<Enemy> _enemys = new List<Enemy>();

    private void Start()
    {
        _wafes = _dataService.GetData().Waves;
        _enemys = _enemyService.GetEnemies();
        StartCoroutine(SpawnMob());
    }

    IEnumerator SpawnMob()
    {
        GameObject Obj = new GameObject();
        Obj.name = "Enemys";
        for (int i = 0; i < _wafes.Count; i++)
        {
            yield return new WaitForSeconds(_wafes[i].Delay);
            for (int i2 = 0; i2 < _wafes[i].Count; i2++)
            {
                yield return new WaitForSeconds(_wafes[i].SpawnCooldown);
                _container.InstantiatePrefab(_enemys[_wafes[i].MobID],Obj.transform);
            }
        }
    }
}
