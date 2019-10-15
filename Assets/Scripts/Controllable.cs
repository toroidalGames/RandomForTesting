using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Character))]
[RequireComponent(typeof(Stats))]
public class Controllable : MonoBehaviour
{
    [SerializeField] bool canBeTakenOver = true;
    [SerializeField] int requiredTakeOverPower = 10;
    [SerializeField] GameObject gameObjectThatWillBeAbsorbed = null;
    

    public bool CanBeTakenOver(int takeOverPower)
    {
        return canBeTakenOver && takeOverPower > requiredTakeOverPower;
    }
    
    public GameObject GameObjectThatWillBeAbsorbed()
    {
        return gameObjectThatWillBeAbsorbed;
    }
}
