using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CharacterStateMachine : MonoBehaviour
{
    public enum BaseStates { Idle, Moving, Dashing, Attacking }
    public BaseStates currentBaseState = BaseStates.Idle;
    public delegate void BaseStateChangedDelegate(BaseStates newBaseState);
    public BaseStateChangedDelegate baseStateChangedDelegate;
    
    public enum SubStates { Normal, Damaged, Invulnerable }
    public SubStates currentSubState = SubStates.Normal;
    public delegate void SubStateChangedDelegate(SubStates newSubState);
    public SubStateChangedDelegate subStateChangedDelegate;
    
    public BaseStates CurrentBaseState
    {
        get
        {
            return currentBaseState;
        }
        set
        { 
            currentBaseState = value;
            baseStateChangedDelegate?.Invoke(currentBaseState);
        } 
    }
    
    public SubStates CurrentSubState
    {
        get
        {
            return currentSubState;
        }
        set
        { 
            currentSubState = value;
            subStateChangedDelegate?.Invoke(currentSubState);
        } 
    }
}
