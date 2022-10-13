using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour, Controls.IGameplayActions
{
    Controls control;

    [SerializeField] private Rigidbody2D player;
    
    [SerializeField] private float jumpForce = 400f;	// Amount of force added when the player jumps.
    [SerializeField] private float speed = 10f;

    [SerializeField] private bool isMoving;
    public void OnEnable()
    {
        if (control == null)
        {
            control = new Controls();
            // Tell the "gameplay" action map that we want to get told about
            // when actions get triggered.
            control.Gameplay.SetCallbacks(this);
        }
        control.Gameplay.Enable();
    }

    private void OnDestroy()
    {
        control.Dispose();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.performed){
            player.AddForce(new Vector2(0,jumpForce));
        }
    }

    private void FixedUpdate()
    {
        if(isMoving){
            Vector2 vec = control.Gameplay.Move.ReadValue<Vector2>();
            MoveX(vec.x);
        }
        else
        {
            MoveX(player.velocity.x-Mathf.Lerp(player.velocity.x, 0, Time.deltaTime));
        }
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        
        if(context.started)
        {
            isMoving = true;
        }
        
        else if (context.canceled)
        {
            isMoving = false;
        }
    }

    private void MoveX(float distance)
    {
        player.velocity = new Vector2(distance * speed, player.velocity.y);
    }
    
    private void MoveY(float distance)
    {
        player.velocity = new Vector2(player.velocity.x, distance * speed);
    }
}
