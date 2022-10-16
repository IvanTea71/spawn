using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private Enemy _template;
    [SerializeField] private List<GameObject> _spawns = new List<GameObject>();
    
    private Coroutine _spawner;
    private static int _waitSeconds = 2;
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(_waitSeconds);

    private void Start()
    {
        CoroutineControl();
    }

    private void CoroutineControl()
    {
        if (_spawner != null)
        {
            StopCoroutine(_spawner);
        }

        _spawner = StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        for (int i = 0; i < _spawns.Count; i++)
        {
            Enemy enemy = Instantiate(_template, Vector3.zero, Quaternion.identity);
            Transform enemyTransform = enemy.GetComponent<Transform>();
            enemyTransform.position = _spawns[i].transform.position;
            
            yield return _waitForSeconds;
        }
    }
}
