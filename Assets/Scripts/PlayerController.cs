using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    private PlayerInput m_InputsMgr;
    private InputAction m_MoveAction;
    private Vector3 m_CurrentPos;
    public float m_XRange = 10f;
    public float m_ZRange = 10f;
    public float m_Speed = 20f;
    // Start is called before the first frame update
    
    public void Awake()
    {
        m_InputsMgr = GetComponent<PlayerInput>();
        m_MoveAction = m_InputsMgr.actions["Move"];
    }
    void Start()
    {
        
    }
    private float BorderPlayer( float m_CurrentPos, float m_Range){
        if(m_CurrentPos > m_Range){
            m_CurrentPos = m_Range;
        }
        else if(m_CurrentPos < - m_Range){
            m_CurrentPos = -m_Range;
        }
        return m_CurrentPos;
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 move = m_MoveAction.ReadValue<Vector2>();
        transform.Translate(Vector3.forward * Time.deltaTime * m_Speed * move.y);
        transform.Translate(Vector3.right * Time.deltaTime * m_Speed * move.x);
        m_CurrentPos = transform.position;
        m_CurrentPos.x = BorderPlayer(m_CurrentPos.x,m_XRange);
        m_CurrentPos.z = BorderPlayer(m_CurrentPos.z,m_ZRange);
        
        transform.position = m_CurrentPos;
    }
}
