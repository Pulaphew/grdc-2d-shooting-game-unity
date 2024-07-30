using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Vector2 input;
    public Rigidbody2D rb;
    public float speed = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        rb.velocity = input * speed;
    }

    public void OnHit()
    {
        SceneManager.LoadScene(0);
    }
}
