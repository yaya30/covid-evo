using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    private PlayerInput m_InputsMgr;
    private InputAction m_MoveAction;
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

    // Update is called once per frame
    void Update()
    {
        Vector2 move = m_MoveAction.ReadValue<Vector2>();
        transform.Translate(Vector3.forward * Time.deltaTime * m_Speed * move.y);
        transform.Translate(Vector3.right * Time.deltaTime * m_Speed * move.x);
    }
}
