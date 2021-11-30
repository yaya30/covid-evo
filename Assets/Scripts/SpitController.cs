using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitController : MonoBehaviour
{
    [SerializeField]
    private int seconds;

    [SerializeField]
    private float damage;
    
    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, seconds);
    }

    private void OnTriggerEnter(Collider _other)
    {
        Target target = _other.gameObject.GetComponent<Target>();
        
        if (target != null)
        {
            target.Hit(damage);
            Destroy(gameObject);
        }
    }
}
