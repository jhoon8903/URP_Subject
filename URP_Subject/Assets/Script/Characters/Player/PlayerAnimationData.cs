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

    public Dictionary<string, int> GroundParameterHash { get; set; } = new();
    public Dictionary<string, int> IdleParameterHash { get; set; } = new();
    public Dictionary<string, int> WalkParameterHash { get; set; } = new();
    public Dictionary<string, int> RunParameterHash { get; set; }= new();
    
    public Dictionary<string, int> AirParameterHash { get; set; }= new();
    public Dictionary<string, int> JumpParameterHash { get; set; }= new();
    public Dictionary<string, int> FallParameterHash { get; set; }= new();
    
    public Dictionary<string, int> AttackParameterHash { get; set; } = new();
    public Dictionary<string, int> ComboAttackParameterHash { get; set; } = new();

    public void Initialize()
    {                                                          
        GroundParameterHash.Add("@Ground",Animator.StringToHash(groundParameterName));
        IdleParameterHash.Add("Idle",Animator.StringToHash(groundParameterName));
        WalkParameterHash.Add("Walk",Animator.StringToHash(groundParameterName));
        RunParameterHash.Add("Run",Animator.StringToHash(groundParameterName));
        
        AirParameterHash.Add("Air",Animator.StringToHash(groundParameterName));
        JumpParameterHash.Add("Jump",Animator.StringToHash(groundParameterName));
        FallParameterHash.Add("Fall",Animator.StringToHash(groundParameterName));
        
        AttackParameterHash.Add("Attack",Animator.StringToHash(groundParameterName));
        ComboAttackParameterHash.Add("Combo",Animator.StringToHash(groundParameterName));
    }
}
