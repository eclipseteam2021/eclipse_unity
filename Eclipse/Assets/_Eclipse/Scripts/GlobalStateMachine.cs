using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalStateMachine : MonoBehaviour
{
    public enum PhaseStates { Light, Dark }
    protected PhaseStates currentPhaseState = PhaseStates.Light;
    public delegate void PhaseStateChangedDelegate(PhaseStates newPhaseState);
    public PhaseStateChangedDelegate phaseStateChangedDelegate;

    public enum VulnerabilityStates { Normal, Damaged, Invulnerable }
    protected VulnerabilityStates currentVulnerabilityState = VulnerabilityStates.Normal;
    public delegate void VulnerabilityStateChangedDelegate(VulnerabilityStates newSubState);
    public VulnerabilityStateChangedDelegate vulnerabilityStateChangedDelegate;

    public PhaseStates CurrentPhaseState
    {
        get
        {
            return currentPhaseState;
        }
        set
        {
            currentPhaseState = value;
            phaseStateChangedDelegate?.Invoke(currentPhaseState);
        }
    }

    public VulnerabilityStates CurrentVulnerabilityState
    {
        get
        {
            return currentVulnerabilityState;
        }
        set
        {
            currentVulnerabilityState = value;
            vulnerabilityStateChangedDelegate?.Invoke(currentVulnerabilityState);
        }
    }
}
