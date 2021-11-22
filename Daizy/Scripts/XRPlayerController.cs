using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;


public class XRPlayerController : LocomotionProvider
{
    [SerializeField] private InputActionReference JumpActionReference;
    [SerializeField] private float JumpForce = 100.0f;

    [SerializeField] private InputActionReference SprintActionReference;

    [SerializeField] private float SpintSpeed = 10;
    
    private XRRig _xrRig;

    private ContinuousMoveProviderBase continuousMove;

    public CharacterController _charcter;
    public LayerMask groudLayer;
    private Vector3 playerVelocity;
    private float gravityValue = -9.81f;



    

    bool CheckIfGrounded()
    {
        Vector3 rayStart = transform.TransformPoint(_charcter.center);
        float rayLanth = _charcter.center.y + 0.01f;
        bool hasHit = Physics.SphereCast(rayStart, _charcter.radius, Vector3.down, out RaycastHit hitInfo, rayLanth, groudLayer);
        return hasHit;
    }

    

    void Start() 
    {
        
        
        _charcter = GetComponent<CharacterController>();
        _xrRig = GetComponent<XRRig>();
        continuousMove = GetComponent<ContinuousMoveProviderBase>();
        JumpActionReference.action.performed += OnJump;
        SprintActionReference.action.performed += OnSprint;


    }

    private void Update() 
    {
        bool IsGrounded = CheckIfGrounded();
        CheckIfGrounded();
        
    }

    private void OnSprint(InputAction.CallbackContext context)
    {
     
     
     Debug.Log("Run");

    }
    private void OnJump(InputAction.CallbackContext context)
    {
        bool IsGrounded = CheckIfGrounded();
        if (IsGrounded)
        { playerVelocity.y += Mathf.Sqrt(JumpForce * -2f * gravityValue);}
        
        playerVelocity.y += gravityValue * Time.smoothDeltaTime;
        _charcter.Move(playerVelocity * Time.smoothDeltaTime);
    }
}
