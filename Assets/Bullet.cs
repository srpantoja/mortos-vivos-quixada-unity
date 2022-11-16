using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 4.5f;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);

        var enemy = other.collider.GetComponent<Enemy>();
        if (enemy)
        {
            enemy.life -= 1f;
            if (enemy.life <= 0)
            {
                enemy.player.IncrementScore();
                Destroy(gameObject);
            }
        }
    }

}
