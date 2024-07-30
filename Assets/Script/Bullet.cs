using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed = 10;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Init(Vector2 dir)
    {
        rb.velocity = dir.normalized * speed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Enemy enemy = col.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.OnHit();
            Destroy(this.gameObject);
            ScoreText.score++ ;
        }
    }
}