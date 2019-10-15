using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationChanger : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void ChangeAnimationController(Animator animatorToChangeTo)
    {
        animator = animatorToChangeTo;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChangeToMovementAnimation();
    }

    private void ChangeToMovementAnimation()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rigidBody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            animator.SetBool("movingHorizontally", true);
            transform.localScale = new Vector2(Mathf.Sign(rigidBody.velocity.x), 1f);
        }
        else
        {
            animator.SetBool("movingHorizontally", false);
        }

    }
}
