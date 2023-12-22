using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [field: Header("References")]
    [field: SerializeField] public PlayerSO Data { get; set; }

    [field: Header("Animations")]
    [field: SerializeField] public PlayerAnimationData AnimationData { get; set; }

    public Rigidbody RigidBody { get; set; }
    public Animator Animator { get; set; }
    public PlayerInput Input { get; set; }
    public CharacterController Controller { get; set; }

    private PlayerStateMachine _playerStateMachine;

    private void Awake()
    {
        AnimationData.Initialize();

        RigidBody = GetComponent<Rigidbody>();
        Animator = GetComponentInChildren<Animator>();
        Input = GetComponent<PlayerInput>();
        Controller = GetComponent<CharacterController>();
        _playerStateMachine = new PlayerStateMachine(this);
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _playerStateMachine.ChangeState(_playerStateMachine.IdleState);
    }

    private void Update()
    {
        _playerStateMachine.HandleInput();
        _playerStateMachine.Update();
    }

    private void FixedUpdate()
    {
        _playerStateMachine.PhysicsUpdate();
    }
}
