using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBare : MonoBehaviour
{
    
    public Image healthBarImage;
    public PlayerController playerController;
    public void UpdateHealthBare()
    {
        //healthBarImage.fillAmount = playerController.health;
        Debug.Log("check valeur fill !!!!! = " + healthBarImage.fillAmount);
        healthBarImage.fillAmount = playerController.health;
       
        //healthBarImage.fillAmount = 0.5f; 
    }
}
