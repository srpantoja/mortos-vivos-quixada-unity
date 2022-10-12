using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 4.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

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
            enemy.TakeHit(1f);
        }
    }

}
