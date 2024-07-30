using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this code calculate the estimate instantanous velocity of the object and use it to control the animation independently from the movement system
// it also make the sprite face the correct direction

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class GameNyanAnimCtrl : MonoBehaviour
{
    Animator animator;
    SpriteRenderer spriteRenderer;

    Vector3 o_pos;
    Vector3 n_pos;
    public Vector3 velocity;

    [SerializeField] float speedThreshold = 0.1f;
    [SerializeField] bool spriteFaceRight = true;

    void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        o_pos = transform.position;
        n_pos = o_pos;
    }

    void FixedUpdate()
    {
        // calculate velocity
        n_pos = transform.position;
        velocity = (n_pos - o_pos) / Time.deltaTime;
        o_pos = n_pos;

        // set animation parameter
        bool isRunning = velocity.magnitude > speedThreshold;
        animator.SetBool("isRunning", isRunning);

        // flip sprite
        if (velocity.x > 0)
        {
            spriteRenderer.flipX = !spriteFaceRight;
        }
        else if (velocity.x < 0)
        {
            spriteRenderer.flipX = spriteFaceRight ? true : false;
        }
    }
}
