using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerAirData : MonoBehaviour
{
    [field: Header("JumpData")]
    [field: SerializeField]
    [field: Range(0f, 25f)]
    public float JumpForce { get; set; } = 4f;
}
