using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    public Enemy enemy;
    public Player player;
    float count = 0;
    void Start()
    {
        StartCoroutine(EnemyRespawn());
    }
    void Update()
    {
        float timeCount = 1 / player.level;
        count = Time.time;
        if (count % timeCount == 0)
        {
            EnemyRespawn();
        }
    }

    IEnumerator EnemyRespawn()
    {
        var positionX = 18f;
        var positionY = Random.Range(-5f, 4f);
        Vector3 position = new Vector3(positionX, positionY, 0f);
        Instantiate(enemy, position, Quaternion.identity);
        yield return new WaitForSeconds(1f / player.level);
        yield return EnemyRespawn();
    }
}
