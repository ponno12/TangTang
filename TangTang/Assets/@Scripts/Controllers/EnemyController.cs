using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : BaseController
{
    public Rigidbody2D target;
    bool isLive =true;

    private void FixedUpdate()
    {
        if (!isLive)
            return;

        Vector2 dirVec = target.position - rb.position;
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + nextVec);
        rb.velocity = Vector2.zero;
        
        
    }

    private void LateUpdate()
    {
        sprite.flipX = target.position.x > rb.position.x;
    }

    private void OnEnable()
    {
        target = Managers.Game._player.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Bullet"))
            return;
        gameObject.SetActive(false);
    }
}
