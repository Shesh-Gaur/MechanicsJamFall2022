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
    public bool onGround = false;
    public Material yellow;
    Material startMat;
    // Start is called before the first frame update
    void Awake()
    {
        startMat = GetComponent<MeshRenderer>().material;
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
            GetComponent<MeshRenderer>().material = yellow;
            playerInput.Player.RewindToggle.performed += cntxt => ToggleRewind();
            playerInput.Player.Move.performed += cntxt => move = cntxt.ReadValue<Vector2>();
            playerInput.Player.Move.canceled += cntxt => move = Vector2.zero;

            playerInput.Player.Jump.performed += cntxt => Jump();
        }
        else
        {
            GetComponent<MeshRenderer>().material = startMat;
        }

        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, 1.0f);

        if (hit.collider)
        {
            onGround = true;
           // if (hit.collider.GetComponent<Rigidbody>())
               // transform.parent = hit.collider.transform;
        }
        else
        {
            onGround = false;
           // transform.parent = null;
        }
    }

    private void FixedUpdate()
    {
       rb.velocity = new Vector3(move.x * mvmtSpeed, rb.velocity.y, move.y * mvmtSpeed);
    }
    void ToggleRewind()
    {
        //timeManager.rewinding = !timeManager.rewinding;
    }

    void Jump()
    {
        if(onGround)
          rb.AddForce(transform.up * jumpForce);      
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Rigidbody>())
            transform.parent = collision.collider.transform;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.GetComponent<Rigidbody>())
            transform.parent = null;
    }
}
