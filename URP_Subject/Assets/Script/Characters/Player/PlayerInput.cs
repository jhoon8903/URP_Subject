using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    #region Propertires

    public PlayerInputAction InputAction { get; set; }
    public PlayerInputAction.PlayerActions PlayerActions { get; set; }

    #endregion

    private void Awake()
    {
        InputAction = new PlayerInputAction();
        PlayerActions = InputAction.Player;
    }

    private void OnEnable()
    {
        InputAction.Enable();
        
    }

    private void OnDisable()
    {
        InputAction.Disable();
    }
}
