using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;


public class healthSlider : MonoBehaviour
{
    public gameScriptableObject gameHealthSO;
    public Image healthBar;
    private float amtSlider;
    // Start is called before the first frame update
    void Start()
    {
        gameHealthSO.healthChangeEvent.AddListener(changeHealthBar);
        healthBar.GetComponentInChildren<TMP_Text>().text = string.Format("{0}/{1}", gameHealthSO.health, gameHealthSO.maxHealth);
    }

    void changeHealthBar()
    {
        if (healthBar != null)
        {
            amtSlider = ((float)gameHealthSO.health / (float)gameHealthSO.maxHealth);

            healthBar.GetComponent<Image>().fillAmount = amtSlider;
            healthBar.GetComponentInChildren<TMP_Text>().text = string.Format("{0}/{1}", gameHealthSO.health, gameHealthSO.maxHealth);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            gameHealthSO.decreaseHealth(1);
            if (gameHealthSO.health == 0)
            {
                gameHealthSO.healthZero();
            }
        }
    }
}
