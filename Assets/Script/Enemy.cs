using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform target;
    public float speed = 3;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = FindObjectOfType<Player>().transform;
    }

    void Update()
    {
        Vector2 moveDirection = target.position - transform.position;
        rb.velocity = moveDirection.normalized * speed;
    }

    public void OnHit()
    {
        Destroy(this.gameObject);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Player player = col.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.OnHit();
            Destroy(this.gameObject);
        }
    }
}
