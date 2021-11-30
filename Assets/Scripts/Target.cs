using UnityEngine;
using System;

public class Target : MonoBehaviour
{
    [SerializeField]
    private float health;

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Hit(float damage)
    {
        health -= damage;
    }
}
