using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 m_CurrentPos;
    public float m_Speed = 20f;
    public GameObject m_Player;
    void Start()
    {
       m_Player =  GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        m_CurrentPos = transform.position;
        Vector3 diff = m_Player.transform.position - m_CurrentPos;
        transform.Translate(diff * Time.deltaTime * m_Speed );
    }
}
