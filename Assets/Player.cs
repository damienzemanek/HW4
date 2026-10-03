using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float jumpScalar = 1f;
    public Action OnJump;
    public Action OnDeath;
    public Action<int> OnPass;

    public Animator animator;
    public string jumpAnimName = "Jump";
    

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Jump();
    }

    void ResetVel()
    {
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0;
    }

    void Jump()
    {
        ResetVel();
        rb.AddForce(Vector2.up * jumpScalar, ForceMode2D.Impulse);
        animator.Play(jumpAnimName);
        OnJump?.Invoke();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("KillZone"))
        {
            rb.gravityScale = 0;
            ResetVel();
            OnDeath?.Invoke();
        }

        if (other.CompareTag("Pass"))
        {
            ScoreTracker.Instance.score++;
            OnPass?.Invoke(ScoreTracker.Instance.score);
        }
    }
}
