using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class onHoverChangeSprite : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public AudioSource audioSource;
    public AudioClip menuSelect;
    public void OnPointerEnter(PointerEventData eventData)
    {
        audioSource.PlayOneShot(menuSelect);
        gameObject.GetComponentInChildren<TMP_Text>().fontMaterial.SetColor(ShaderUtilities.ID_FaceColor, Color.black);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        audioSource.PlayOneShot(menuSelect);
        gameObject.GetComponentInChildren<TMP_Text>().fontMaterial.SetColor(ShaderUtilities.ID_FaceColor, Color.white);
    }
}
