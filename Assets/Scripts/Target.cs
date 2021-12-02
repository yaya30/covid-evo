using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour
{
    [SerializeField]
    private float health;

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            if (this.gameObject.tag == "Player")
            {
                SceneManager.LoadScene("EndScene");
            }
        } 
    }

    public void Hit(float damage)
    {
        health -= damage;

        GameObject m_Player = GameObject.FindWithTag("Player");
    }
}
