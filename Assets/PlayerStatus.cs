using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public Text life;
    public Text score;
    public Text level;
    public Player player;

    void Update()
    {
        string lifes = "";
        for (int i = 0; i < player.life; i++)
        {
            lifes += " X";
        }
        life.text = "LIFE " + lifes;
        score.text = "SCORE " + player.score.ToString();
        level.text = "LEVEL " + player.level.ToString();

    }


}
