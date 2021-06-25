using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    Animator animator;
    [SerializeField] GameObject sprite;
    private string currentState;
    void Start()
    {
        animator = sprite.GetComponent<Animator>();
    }

    public void ChangeAnimationState(string newState)
    {
        //stop the same animation from interrupting itself
        if (currentState == newState) return;

        //play the animation
        animator.Play(newState);

        //reasign the current animation state
        currentState = newState;
    }
}
