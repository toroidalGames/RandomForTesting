using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Absorber : MonoBehaviour
{
    [SerializeField] int takeOverPower = 15;
    [SerializeField] bool takeOverMode = false;

    IControllable controllableTarget = null;


    void Update()
    {
        if (Input.GetKeyDown("space") && controllableTarget != null)
        {
            TakeOverCharacter();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IControllable collidedTarget = collision.gameObject.GetComponent<IControllable>();
        if (collidedTarget != null)
        {
            controllableTarget = collidedTarget;
        }
    }

    private void TakeOverCharacter()
    {
        controllableTarget.TakeOver(takeOverPower);
    }
}
