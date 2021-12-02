using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{

    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private float shootSpeed = 5f;

    [SerializeField] private GameObject spitPrefab;

    // about healthbar 
    //public int maxHealth = 100;
    //public int health;
    //public int currentHealth;

    public float health, maxHealth;
        //maxHealth;
    public HealthBar healthBar;


    //public HealthBar healthBar;

   

    //public HealthBar healthBar;

    //[SerializeField] private float m_ShootSpeed = 2f;
    //[SerializeField] private GameObject m_SpitOriginal, m_ShootPoint;

    private Vector2 movement;
    private Vector2 aim;
    private bool shoot;
    private bool canShoot = true;

    private Vector3 playerVelocity;

    private CharacterController controller;
    private PlayerControls playerControls;
    private PlayerInput playerInput;



    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerControls = new PlayerControls();
        playerInput = GetComponent<PlayerInput>();

    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }


    // init healthbar game 
    /*void Start()
    {
        currentHealth = maxHealth;
        healthBar = new HealthBar();
        healthBar.SetMaxHealth(maxHealth);
    }*/

    // about health bar
    public void TakeDamage()
    {
        // Use your own damage handling code, or this example one.
        //health -= Mathf.Min(Random.value, health / 4f);
        Debug.Log("etat santé dans TakeDamage= " + health);
        health = health -0.005f;
        
        healthBar.UpdateHealthBar();
    }

    void Update()
    {
        HandleInput();
        HandleMovement();
        HandleRotation();
        HandleShoot();

        // use space button to test healthbar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("etat santé= " + health);
            TakeDamage();
        }
    }

  

    void HandleInput()
    {
        movement = playerControls.Controls.Movement.ReadValue<Vector2>();
        aim = playerControls.Controls.Aim.ReadValue<Vector2>();
        shoot = playerControls.Controls.Shoot.triggered;
    }

    void HandleMovement()
    {
        Vector3 move = new Vector3(movement.x, 0, movement.y);
        controller.Move(move * Time.deltaTime * playerSpeed);
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    void HandleRotation()
    {
        Ray ray = Camera.main.ScreenPointToRay(aim);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;

        if (groundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
            LookAt(point);
        }

    }

    void HandleShoot()
    {
        if (shoot)
        {
            GameObject spitClone = Instantiate(spitPrefab, transform.position, transform.rotation);
            Rigidbody rb = spitClone.GetComponent<Rigidbody>();
            rb.velocity = spitClone.transform.forward * shootSpeed;
            StartCoroutine(CanShoot());
        }
    }

    IEnumerator CanShoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(1f);
        canShoot = true;
    }

    private void LookAt(Vector3 lookPoint)
    {
        Vector3 heightCorrectedPoint = new Vector3(lookPoint.x, transform.position.y, lookPoint.z);
        transform.LookAt(heightCorrectedPoint);
    }
}

/*private float BorderPlayer( float m_CurrentPos, float m_Range){
        if(m_CurrentPos > m_Range){
            m_CurrentPos = m_Range;
        }
        else if(m_CurrentPos < - m_Range){
            m_CurrentPos = -m_Range;
        }
        return m_CurrentPos;
    }*/
