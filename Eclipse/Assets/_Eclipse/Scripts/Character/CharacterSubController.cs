using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSubController : MonoBehaviour
{
    protected CharacterStateMachine stateMachine;
    protected CharacterMasterController masterController;

    protected virtual void Start()
    {
        masterController = CharacterMasterController.Instance;
        stateMachine = masterController.CharacterStateMachine;
    }

}
