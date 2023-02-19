using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject[] prefabs;

    List<GameObject>[] pools;

    public Transform[] spawnPoints;
    private void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];
        for(int i = 0; i <pools.Length; ++i)
        {
            pools[i] = new List<GameObject>();
        }
    }

    public GameObject Get(int index)
    {
        GameObject select = null;

        foreach(GameObject item in pools[index])
        {
            if (!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }

        if (!select)
        {
            Managers.Resource.Instantiate("Enemy_Pig",callback: (go) =>
            {
                EnemyController mc = go.GetOrAddComponent<EnemyController>();
                mc.speed = 3f;
                
                select = go;
                go.transform.position = spawnPoints[Random.Range(1, spawnPoints.Length)].position;
                pools[index].Add(select);
            });
        }

        return select;
    }
}
