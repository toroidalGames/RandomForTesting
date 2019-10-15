using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Stats))]
public class Absorber : MonoBehaviour
{
    [SerializeField] int takeOverPower = 15;
    [SerializeField] bool takeOverMode = false;
    [SerializeField] float absorbRange = 1f;

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
        if (AbsorbModeWithTargetInRange())
        {
            TakeOverCharacter();
        }

    }

    private bool AbsorbModeWithTargetInRange()
    {
        if (controllableTarget == null) { return false; }
        float targetDistance = Vector2.Distance(transform.position, controllableTarget.transform.position);
        return Input.GetKeyDown("space") && controllableTarget != null && targetDistance <= absorbRange;
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
