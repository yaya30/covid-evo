using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 m_CurrentPos;
    public float m_Speed = 20f;
    public GameObject m_Player;
    public float damage;
    void Start()
    {
       m_Player =  GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        m_CurrentPos = transform.position;
        if(m_Player !=null){
            Vector3 diff = m_Player.transform.position - m_CurrentPos;
            transform.Translate(diff * Time.deltaTime * m_Speed );
        }
        
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
