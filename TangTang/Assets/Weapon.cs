using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int id;
    public int count;
    public int prefabId;
    public float speed = 150;

    public void Start()
    {
        Init();
    }
    public void Init()
    {
        Managers.Resource.Instantiate("Mele", callback: go =>
        {
            go.transform.parent = transform;
        });
    }
    
    private void FixedUpdate()
    {
        transform.Rotate(Vector3.back * speed);

    }
    void Batch()
    {
        for (int i = 0; i < count; i++)
        {
            Transform bullet = Managers.Game._poolManager.Get(prefabId).transform;
            bullet.parent = transform;
            
        }
    }
}

