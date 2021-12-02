using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBarImage;
    public Target target;

    public void UpdateHealthBar()
    {
        //healthBarImage.fillAmount = playerController.health;
        Debug.Log("check valeur fill !!!!! = " + healthBarImage.fillAmount);
        healthBarImage.fillAmount = target.Health;
        Debug.Log("check valeur fill 2 !!!!! = " + healthBarImage.fillAmount);
    }
}
