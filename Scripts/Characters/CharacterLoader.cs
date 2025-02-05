using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

[SelectionBase]
public class CharacterLoader : InitializationManagerInitialized {
    [SerializeField] private CharacterSpawnInfo characterSpawnInfo;

    public AsyncOperationHandle<Civilian> GetCharacterAsync() {
        Quaternion desiredRotation = QuaternionExtensions.LookRotationUpPriority(transform.forward, Vector3.up);
        return characterSpawnInfo.GetCharacter(transform.position, desiredRotation);
    }

    public override InitializationManager.InitializationStage GetInitializationStage() {
        return InitializationManager.InitializationStage.AfterMods;
    }

    public override async Task OnInitialized() {
        Quaternion desiredRotation = QuaternionExtensions.LookRotationUpPriority(transform.forward, Vector3.up);
        var handle = characterSpawnInfo.GetCharacter(transform.position, desiredRotation);
        await handle.Task;
        var characterBase = handle.Result;
        characterBase.GetBody().position = transform.position;
        characterBase.transform.position = transform.position;
        characterBase.SetFacingDirection(desiredRotation);
        characterBase.transform.rotation = desiredRotation;
        characterBase.GetBody().rotation = desiredRotation;
        characterBase.GetBody().velocity = Vector3.zero;
        gameObject.SetActive(false);
    }
}
