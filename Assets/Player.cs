using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public float maxLife = 5;
    public float life;

    public float score = 0;

    public float nextLevel = 100;

    public float level = 1;
    public Bullet bullet;
    public Transform bulletStartOffset;
    bool horizontalFacing = false;
    AudioSource audioFire; 
    Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        life = maxLife;
        audioFire = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInputMovement();
        GetInputFire();
        LevelUp();
        PlayerGameOver();
    }

    void FixedUpdate()
    {
        Move();
    }

    public void IncrementScore()
    {
        score += 10;
    }

    void LevelUp()
    {
        if (score >= nextLevel)
        {
            level += 1;
            nextLevel = (100 * level) * 1.5f;
            Debug.Log("nextLevel " + nextLevel);
        }
    }
    void PlayerGameOver()
    {
        if (life <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }

    }

    void GetInputMovement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        movement = new Vector2(moveX, moveY);
        if (moveX != 0 || moveY != 0)
            animator.SetBool("isMoving", true);
        else
            animator.SetBool("isMoving", false);

        if (moveX < 0 && !horizontalFacing)
            FlipPlayer();
        else if (moveX > 0 && horizontalFacing)
            FlipPlayer();

    }

    void GetInputFire()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Instantiate(bullet, bulletStartOffset.position, transform.rotation);
            audioFire.Play();
        }
    }

    void FlipPlayer()
    {
        horizontalFacing = !horizontalFacing;
        transform.Rotate(0f, 180f, 0f);
    }

    void Move()
    {
        rb.velocity = new Vector2(movement.x * speed, movement.y * speed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var enemyCollision = other.collider.GetComponent<Enemy>();
        if (enemyCollision)
        {
            Destroy(enemyCollision.gameObject);
            life -= 1;
        }

    }


}
