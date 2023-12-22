using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerBaseState : IState
{
    protected PlayerStateMachine StateMachine;
    protected readonly PlayerGroundData GroundData;

    public PlayerBaseState(PlayerStateMachine playerStateMachine)
    {
        StateMachine = playerStateMachine;
        GroundData = StateMachine.Player.Data.GroundData;
    }

    public virtual void Enter()
    {
        AddInputActionsCallbacks();
    }

    public virtual void Exit()
    {
       RemoveInputActionCallbacks();
    }

    public virtual void HandleInput()
    {
        ReadMovementInput();
    }

    public virtual void Update()
    {
        Move();
    }

    public virtual void PhysicsUpdate()
    {
    }

    protected virtual void AddInputActionsCallbacks()
    {
        PlayerInput input = StateMachine.Player.Input;
        input.PlayerActions.Movement.canceled += OnMovementCanceled;
        input.PlayerActions.Run.started += OnRunStarted;
    }

    protected virtual void OnRunStarted(InputAction.CallbackContext obj)
    {
    }

    protected virtual void OnMovementCanceled(InputAction.CallbackContext obj)
    {
    }

    protected virtual void RemoveInputActionCallbacks()
    {
        PlayerInput input = StateMachine.Player.Input;
        input.PlayerActions.Movement.canceled -= OnMovementCanceled;
        input.PlayerActions.Run.started -= OnRunStarted;
    }

    private void ReadMovementInput()
    {
        StateMachine.MovementInput = StateMachine.Player.Input.PlayerActions.Movement.ReadValue<Vector2>();
    }

    private void Move()
    {
        Vector3 movementDirection = GetMovementDirection();
        Rotate(movementDirection);
        Move(movementDirection);
    }

    private Vector3 GetMovementDirection()
    {
        Vector3 forward = StateMachine.MainCameraTransform.forward;
        Vector3 right = StateMachine.MainCameraTransform.right;
        
        // 카메라가 바닥을 보지않도록
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        return forward * StateMachine.MovementInput.y + right * StateMachine.MovementInput.x;
    }

    private void Move(Vector3 movementDirection)
    {
        float movementSpeed = GetMovementSpeed();
        StateMachine.Player.Controller.Move(movementDirection * movementSpeed * Time.deltaTime);
    }

    private void Rotate(Vector3 movementDirection)
    {
        if (movementDirection != Vector3.zero)
        {
            Transform playerTransform = StateMachine.Player.transform;
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection);
            playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, targetRotation, StateMachine.RotationDamping * Time.deltaTime);
        }
    }

    private float GetMovementSpeed()
    {
        return StateMachine.MovementSpeed * StateMachine.MovementSpeedModifier;
    }

    protected void StartAnimation(Dictionary<string, int>animationHash)
    {
        foreach (var hash in animationHash)
        {
            Debug.Log($" Start : {hash.Key}");
            StateMachine.Player.Animator.SetBool(hash.Value, true);
        }
    }

    protected void StopAnimation(Dictionary<string, int>animationHash)
    {
        foreach (var hash in animationHash)
        {
            Debug.Log($" Start : {hash.Key}");
            StateMachine.Player.Animator.SetBool(hash.Value, false);
        }
    }
}
