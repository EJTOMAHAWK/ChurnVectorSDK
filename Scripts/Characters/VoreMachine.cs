using System.Collections;
using System.Collections.Generic;
using PenetrationTech;
using UnityEngine;

public abstract class VoreMachine {
    public class VoreStatus {
        public IVorable other;
        public Penetrator dick;
        public Vector3 dickTipPosition;
        public Vector3 dickTipNormal;
        public Vector3 dickTipBinormal;
        public Quaternion dickTipRotation;
        public float progress;
        public float progressAdjusted;
        public float direction;
        public float dickTipRadius;
        public bool didBigSplash;
    }

    public abstract void Initialize(CharacterBase owner);
    public abstract void LateUpdate();
    public abstract bool IsVoring();
    public abstract void StartVore(IVorable churnable);
    public abstract void StopVore();
    public delegate void CockVoreEventAction(VoreStatus status);
    public CockVoreEventAction cockVoreStart;
    public CockVoreEventAction cockVoreUpdate;
    public CockVoreEventAction cockVoreEnd;
}
