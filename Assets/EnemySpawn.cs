using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject _template;

    private Coroutine _spawner;
    private List<GameObject> _spawns = new List<GameObject>();

    private void Start()
    {
        AddPoints();
        CoroutineControl();
    }

    private void AddPoints()
    {
        _spawns.Add(GameObject.Find("GameObject"));
        _spawns.Add(GameObject.Find("GameObject (1)"));
        _spawns.Add(GameObject.Find("GameObject (2)"));
        _spawns.Add(GameObject.Find("GameObject (3)"));
        _spawns.Add(GameObject.Find("GameObject (4)"));
        _spawns.Add(GameObject.Find("GameObject (5)"));
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
            GameObject enemy = Instantiate(_template, Vector3.zero, Quaternion.identity);
            Transform enemyTransform = enemy.GetComponent<Transform>();
            enemyTransform.position = _spawns[i].transform.position;
            yield return new WaitForSeconds(2);
        }
    }
}
