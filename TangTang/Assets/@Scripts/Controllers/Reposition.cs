using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    Collider2D _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
            return;

        Vector3 playerPos = Managers.Game._player.transform.position;
        Vector3 myPos = transform.position;
        float diffX = Mathf.Abs(playerPos.x- myPos.x);
        float diffY = Mathf.Abs(playerPos.y- myPos.y);

        Vector3 playerDir = Managers.Game._player.inputVec;
        float dirX = playerDir.x < 0 ? -1 : 1;
        float dirY = playerDir.y < 0 ? -1 : 1;

        switch (transform.tag)
        {
            case "Tile":
                if (diffX > diffY)
                {
                    transform.Translate(Vector3.right * dirX * 36);
                }
                else if (diffX < diffY)
                {
                    transform.Translate(Vector3.up * dirY * 36);
                }
                break;
            case "Enemy":
                if (_collider.enabled)
                {
                    transform.Translate(playerDir * 20+ new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f),0f));
                }
                break;
        }
    }
}
