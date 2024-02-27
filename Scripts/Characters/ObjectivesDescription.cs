using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivesDescription : InitializationManagerInitialized {
    [SerializeField, SerializeReference, SubclassSelector]
    private List<Objective> objectives;

    private static ObjectivesDescription instance;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        FindObjectOfType<ObjectiveManager>(true).SetObjectives(objectives);
    }

    public override InitializationManager.InitializationStage GetInitializationStage() {
        return InitializationManager.InitializationStage.AfterLevelLoad;
    }

    public override PleaseRememberToCallDoneInitialization OnInitialized(DoneInitializingAction doneInitializingAction) {
        foreach (var objective in objectives) {
            objective.OnRegister();
        }
        return doneInitializingAction?.Invoke(this);
    }
    protected override void OnDestroy() {
        foreach (var objective in objectives) {
            objective.OnUnregister();
        }
        base.OnDestroy();
    }
    
    public static List<Objective> GetObjectives() {
        if (instance == null) {
            instance = FindObjectOfType<ObjectivesDescription>();
        }

        if (instance == null) {
            return null;
        }

        return instance.objectives;
    }
}
