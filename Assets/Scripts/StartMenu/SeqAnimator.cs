using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeqAnimator : MonoBehaviour
{
    List<Animator> _animators;

    public float WaitBetween = 0.10f;
    public float WaitEnd = 1f;
   
    void Start()
    {
        _animators = new List<Animator>(GetComponentsInChildren<Animator>());

        StartCoroutine(DoAnimation());
    }


    IEnumerator DoAnimation()
    {
        while (true)
        {
            foreach (var animator in _animators)
            {
                animator.SetTrigger("DoAnimation");
                yield return new WaitForSeconds(WaitBetween);
            }

            yield return new WaitForSeconds(WaitEnd);
        }

    }
}
