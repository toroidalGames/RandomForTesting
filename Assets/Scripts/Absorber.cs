using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Stats))]
public class Absorber : MonoBehaviour
{
    [SerializeField] int takeOverPower = 15;
    [SerializeField] bool takeOverMode = false;

    Controllable controllableTarget = null;
    SpriteRenderer spriteRenderer;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown("space") && controllableTarget != null)
        {
            TakeOverCharacter();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Controllable collidedTarget = collision.gameObject.GetComponent<Controllable>();
        if (collidedTarget != null)
        {
            controllableTarget = collidedTarget;
        }
    }

    private void TakeOverCharacter()
    {
        if (controllableTarget.CanBeTakenOver(takeOverPower))
        {
            AbsorbTargetsSpriteAndAnimator();
            AbsorbStats();
        }
    }

    private void AbsorbTargetsSpriteAndAnimator()
    {
        spriteRenderer.sprite = controllableTarget.GameObjectThatWillBeAbsorbed().GetComponentInChildren<SpriteRenderer>().sprite;
        animator.runtimeAnimatorController = controllableTarget.GameObjectThatWillBeAbsorbed().GetComponent<Animator>().runtimeAnimatorController;
    }

    private void AbsorbStats()
    {
        Stats targetsStats = controllableTarget.GetComponent<Stats>();
        if (targetsStats != null)
        {
            GetComponent<Stats>().ChangeStatsToTargets(targetsStats);
        }
    }
}
