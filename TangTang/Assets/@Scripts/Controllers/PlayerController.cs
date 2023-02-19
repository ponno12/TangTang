using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Etouch = UnityEngine.InputSystem.EnhancedTouch;

public class PlayerController : BaseController
{
    
    public VariableJoystick variableJoystick;
    
    public Vector2 inputVec;

    
    
    public void FixedUpdate()
    {
        //Vector2 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        inputVec = Vector2.up * variableJoystick.Vertical + Vector2.right * variableJoystick.Horizontal;

        //rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);

        rb.MovePosition(rb.position + inputVec.normalized * speed); ;
    }

    private void LateUpdate()
    {
        playerAnimator.SetFloat("Speed", inputVec.magnitude);
        if(inputVec.x != 0)
           {
                sprite.flipX = inputVec.x < 0;
           }   
    }
}
