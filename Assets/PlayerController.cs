using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerInput playerInput;
    Vector2 move;
    Timer timeManager;
    Rigidbody rb;
    public float mvmtSpeed = 5.0f;
    public float jumpForce = 100.0f;
    public bool isRetrocausal = false;
    // Start is called before the first frame update
    void Awake()
    {
        timeManager = FindObjectOfType<Timer>();
        playerInput = new PlayerInput();
        playerInput.Enable();

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((isRetrocausal && timeManager.rewinding) || (!isRetrocausal && !timeManager.rewinding))
        {
            playerInput.Player.RewindToggle.performed += cntxt => ToggleRewind();
            playerInput.Player.Move.performed += cntxt => move = cntxt.ReadValue<Vector2>();
            playerInput.Player.Move.canceled += cntxt => move = Vector2.zero;

            playerInput.Player.Jump.performed += cntxt => Jump();
            rb.velocity = new Vector3(move.x * mvmtSpeed * Time.deltaTime, rb.velocity.y, move.y * mvmtSpeed * Time.deltaTime);
        }
    }
    
    void ToggleRewind()
    {
        //timeManager.rewinding = !timeManager.rewinding;
    }

    void Jump()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, 1.0f);   

        if (hit.collider)
          rb.AddForce(transform.up * jumpForce);
        
    }
}
