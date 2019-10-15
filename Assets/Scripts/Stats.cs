using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] float hp = 100f;
    [SerializeField] float attackDamage = 1f;
    [SerializeField] int strength = 1;
    [SerializeField] int dexterity = 1;
    [SerializeField] int charisma = 1;
    [SerializeField] int intelligence = 1;
    [SerializeField] int constitution = 1;

    public float ReturnHP() { return hp; }
    public float ReturnAttackDamage() { return attackDamage; }
    public int ReturnStrength(){return strength; }
    public int ReturnDexterity() { return dexterity; }
    public int ReturnCharisma() { return charisma; }
    public int ReturnIntelligence() { return intelligence; }
    public int ReturnConstitution() { return constitution; }

    public void ChangeStatsToTargets(Stats targetsStats)
    {
        hp = targetsStats.hp;
        Debug.Log("Your hp is now: " + hp);
    }

}
