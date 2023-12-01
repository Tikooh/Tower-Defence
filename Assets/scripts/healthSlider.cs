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
    public Image healthTxt;
    private float amtSlider;
    // Start is called before the first frame update
    void Start()
    {
        gameHealthSO.healthChangeEvent.AddListener(changeHealthBar);
    }

    void changeHealthBar()
    {
        if (healthBar != null)
        {
            amtSlider = ((float)gameHealthSO.health / (float)gameHealthSO.maxHealth);
            Debug.Log(amtSlider);
            healthBar.GetComponent<Image>().fillAmount = amtSlider;
            // healthTxt.GetComponent<text = string.Format("{0}/{1}", gameHealthSO.health, gameHealthSO.maxHealth);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            gameHealthSO.decreaseHealth(1);
        }
    }
}
