using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    public Color low;
    public Color high;
    public Vector3 offset;
    void Start()
    {
        slider.transform.position = new Vector3(-100f, -100f, 0);
    }
    public void SetHealth(float health, float maxHealth)
    {
        slider.gameObject.SetActive(true);
        slider.value = health;
        slider.maxValue = maxHealth;
    }

    void Update()
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
    }
}
