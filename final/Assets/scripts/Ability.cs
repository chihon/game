using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject {

    public string aName = "New Ability";
    public Sprite aSprite;
    public bool aBaseLock = true;

    public abstract void Initialize(GameObject obj);
    public abstract void TriggerAbility();
}