using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class healthSlider : MonoBehaviour
{
    public gameHealthScriptableObject gameHealthSO;
    public Image healthBar;
    [SerializeField]
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        // gameHealthSO.healthChangeEvent.AddListener(changeHealthBar);
    }

    void changeHealthBar(int amount)
    {
        slider.value -= amount;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemyFinishBoard")
        {
            gameHealthSO.decreaseHealth(10);
        }
    }
}
