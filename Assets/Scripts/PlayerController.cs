using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public ScoreController scoreController;
    public Animator animator;
    public float movementSpeed;
    public float jumpForce = 20f;
    private Rigidbody2D rb2d;
    private BoxCollider2D rb2dBox;
    public Transform feet;
    public LayerMask groundLayer;
    public HealthController health;
    public GameOverController gameOverController;
    public LevelCompleteScripts levelCompleteScript;
    public DummyScript EnemyControllerObject;
    private Vector2 lookDir;
    public float recoilForce;
    private Vector3 scale;
   
    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        rb2dBox = gameObject.GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if(Input.GetButtonDown("Jump") && isGrounded())
            {
                Jump();
                MovementSound();
            }
    }
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        PlayerMovement(horizontal);
        PlayCrouchAnimation();
        PlayJumpAnimation(vertical);
        PlayHorizontalAnimation(horizontal);
    }
    public void PickUpKey()
    {
        scoreController.IncreaseScore(10);
    }
    public void KillPlayer()
    {
        PlayDeathAnimation();
        SoundManager.Instance.Play(Sounds.PlayerDieSound);
        StartCoroutine(TimeSkip());
        Destroy(EnemyControllerObject.gameObject, 0.25f);
    }
    private void MovementSound()
    {
        SoundManager.Instance.Play(Sounds.PlayerMove);
    }
    private void PlayerMovement(float horizontal)
    {
        Vector3 position = transform.position;
        position.x += horizontal * movementSpeed * Time.deltaTime;
        transform.position = position;
        lookDir = Camera.main.ScreenToWorldPoint(position);

    }
    private void PlayCrouchAnimation()
    {
        animator.SetBool("Crouch", Input.GetKey(KeyCode.LeftControl));
    }
    private void PlayJumpAnimation(float vertical)
    {
        animator.SetBool("Jump", vertical > 0);
    }
    private void PlayHorizontalAnimation(float horizontal)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        scale = transform.localScale;
        
        scale.x = (horizontal < 0 ? -1 : (horizontal > 0 ? 1 : scale.x)) * Mathf.Abs(scale.x);
        transform.localScale = scale;
    }
    private void PlayDeathAnimation()
    {
        animator.SetBool("Die", true);
    }
    private void Jump()
    {
        Vector2 movement = new Vector2(rb2d.velocity.x, jumpForce);
        rb2d.velocity = movement;
    }
    public bool isGrounded()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayer);

        if(groundCheck != null)
        {
            return true;
        }
        return false;
    }
    public void DamagePlayer()
    {
        scale = transform.localScale;
        if(scale.x == 1)
        {
            rb2d.AddForce(lookDir * recoilForce, ForceMode2D.Impulse);
        }
        else
        {
            rb2d.AddForce(-lookDir * recoilForce, ForceMode2D.Impulse);
        }
        
        health.healthReduce();
    }
    public void PlayHurtAnimation()
    {
        animator.SetBool("Hurt", true);
        StartCoroutine(Timedelay());
    }
    IEnumerator Timedelay()
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("Hurt", false);
    }
    IEnumerator TimeSkip()
    {
        yield return new WaitForSeconds(1f);
        gameOverController.PlayerDied();
    }

}
