using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Player player;

    public Transform playerTransform;
    public EnemyHealthBar healthBar;
    public float speed = 5f;
    public float maxLife = 3;
    public float life;
    private float distance;
    private bool horizontalFacing = false;

    void Start()
    {
        life = maxLife;
        player = FindObjectOfType<Player>();
    }
    void Update()
    {
        MoveEnemy();
        healthBar.SetHealth(life, maxLife);
    }

    void MoveEnemy()
    {
        distance = Vector2.Distance(transform.position, playerTransform.position);
        Vector2 direction = playerTransform.position - transform.position;
        transform.position = Vector2.MoveTowards(this.transform.position, playerTransform.position, speed * Time.deltaTime);

        if (direction.x < 0 && !horizontalFacing)
            FlipEnemy();
        else if (direction.x > 0 && horizontalFacing)
            FlipEnemy();
    }

    void FlipEnemy()
    {
        horizontalFacing = !horizontalFacing;
        transform.Rotate(0f, 180f, 0f);
    }

}
