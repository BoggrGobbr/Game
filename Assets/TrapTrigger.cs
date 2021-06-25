using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    [SerializeField] float interval = 1f;
    Animator animator;
    BoxCollider2D collider;
    void Start()
    {
        animator = GetComponent<Animator>();
        collider = GetComponent<BoxCollider2D>();
        StartCoroutine("Wait");
       
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(interval);
        animator.enabled = true;
        collider.enabled = true;
        StartCoroutine(OnCompleteAnimation(animator.GetCurrentAnimatorStateInfo(0).length));
    }

    IEnumerator OnCompleteAnimation(float animationLength)
    {
        yield return new WaitForSeconds(animationLength);
        Destroy(gameObject);
    }
}
