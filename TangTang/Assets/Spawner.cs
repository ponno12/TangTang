using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    float timer =0f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 0.2f)
        {
            Spawn();
            timer = 0f;
        }
    }

    void Spawn()
    {
        Managers.Game._poolManager.Get(0);
    }
}
