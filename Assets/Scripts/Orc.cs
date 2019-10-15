using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Character))]
public class Orc : MonoBehaviour, IControllable
{
    [SerializeField] bool canBeTakenOver = true;
    [SerializeField] int requiredTakeOverPower = 10;

    public bool CanBeTakenOver()
    {
        return canBeTakenOver;
    }

    public void TakeOver(int takeOverPower)
    {
        if (takeOverPower > requiredTakeOverPower)
        {
            Debug.Log("You have enough power to take over: " + GetComponent<Character>().name);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
