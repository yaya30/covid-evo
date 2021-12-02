using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour
{
    [SerializeField]
    private float m_health;

    [SerializeField]
    public HealthBar healthBar = null;

    public float Health {
        get { return m_health; }
        set { m_health = value; }
    }

    private void Update()
    {
        if (Health <= 0)
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
        Health -= damage;

        if (healthBar != null)
        {
            healthBar.UpdateHealthBar();
        }
    }
}
