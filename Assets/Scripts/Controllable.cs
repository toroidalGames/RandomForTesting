using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Character))]
public class Controllable : MonoBehaviour
{
    [SerializeField] bool canBeTakenOver = true;
    [SerializeField] int requiredTakeOverPower = 10;
    [SerializeField] GameObject gameObjectThatWillBeAbsorbed = null;
    

    public bool CanBeTakenOver()
    {
        return canBeTakenOver;
    }

    public void BeTakenOver(int takeOverPower)
    {
        if (takeOverPower > requiredTakeOverPower)
        {
            Debug.Log("You have enough power to take over: " + GetComponent<Character>().name);

        }
    }
    
    public GameObject GameObjectThatWillBeAbsorbed()
    {
        return gameObjectThatWillBeAbsorbed;
    }
}
