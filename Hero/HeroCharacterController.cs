using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCharacterController : MonoBehaviour
{
    [SerializeField] LayerMask groundLayers;
    [SerializeField] private float runSpeed = 8f;
    [SerializeField] private float jumpHeight = 2;

    private bool isGrounded;
    private float gravity = -50f;
    private CharacterController characterControler;
    private Vector3 velocity;
    private float horizontalx;
    



    // Start is called before the first frame update
    void Start()
    {
        characterControler = GetComponent<CharacterController>();   
    }

    // Update is called once per frame
    void Update()
    {
        horizontalx = 1;

        //FaceFoward
        transform.forward = new Vector3(horizontalx, 0, Mathf.Abs(horizontalx) - 1);


        //IsGrounded
        isGrounded = Physics.CheckSphere(transform.position, 0.1f, groundLayers, QueryTriggerInteraction.Ignore);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
        }
        else
        {
            //Gravity
            velocity.y += gravity * Time.deltaTime;
        }

        characterControler.Move(new Vector3 (horizontalx * runSpeed, 0, 0) * Time.deltaTime);

        if (Input.GetButtonDown ("Jump"))
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        //Vertical Velocity
        characterControler.Move(velocity * Time.deltaTime);
    }
}
