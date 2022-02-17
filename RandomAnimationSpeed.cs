using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAnimationSpeed : MonoBehaviour
{
    Animator MyAnimator;

    // Start is called before the first frame update
    void Start()
    {
        MyAnimator = GetComponent<Animator>();
        PickRandom();
    }

    public void PickRandom()
    {
        MyAnimator.speed = Random.Range(0.6f, 1f); 
    }    
}
