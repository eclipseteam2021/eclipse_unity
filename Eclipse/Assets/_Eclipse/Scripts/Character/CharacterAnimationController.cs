using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : CharacterSubController
{
    [SerializeField]
    private Animator animator;
    
    public Animator Animator
    {
        get { return animator; }
    }
}
