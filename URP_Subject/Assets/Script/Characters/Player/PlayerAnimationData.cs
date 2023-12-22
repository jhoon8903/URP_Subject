using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerAnimationData
{
    [Header("Ground Parameter")]
    [SerializeField] private string groundParameterName = "@Ground";
    [SerializeField] private string idleParameterName = "Idle";
    [SerializeField] private string walkParameterName = "Walk";
    [SerializeField] private string runParameterName = "Run";

    [Header("Air Parameter")]
    [SerializeField] private string airParameterName = "@Air";
    [SerializeField] private string jumpParameterName = "Jump";
    [SerializeField] private string fallParameterName = "Fall";
    
    [Header("Attack Parameter")]
    [SerializeField] private string attackParameterName = "@Attack";
    [SerializeField] private string comboAttackParameterName = "ComboAttack";
    
    public int GroundParameterHash { get; set; }
    public int IdleParameterHash { get; set; }
    public int WalkParameterHash { get; set; }
    public int RunParameterHash { get; set; }
    
    public int AirParameterHash { get; set; }
    public int JumpParameterHash { get; set; }
    public int FallParameterHash { get; set; }
    
    public int AttackParameterHash { get; set; }
    public int ComboAttackParameterHash { get; set; }

    public void Initialize()
    {
        GroundParameterHash = Animator.StringToHash(groundParameterName);
        IdleParameterHash = Animator.StringToHash(groundParameterName);
        WalkParameterHash = Animator.StringToHash(groundParameterName);
        RunParameterHash = Animator.StringToHash(groundParameterName);
        
        AirParameterHash = Animator.StringToHash(groundParameterName);
        JumpParameterHash = Animator.StringToHash(groundParameterName);
        FallParameterHash = Animator.StringToHash(groundParameterName);
        
        AttackParameterHash = Animator.StringToHash(groundParameterName);
        ComboAttackParameterHash = Animator.StringToHash(groundParameterName);
    }
}
