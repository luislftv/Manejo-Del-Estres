using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTableController : MonoBehaviour
{
    [SerializeField] Animator animator;

    public void V1()
    {
        animator.Play("Armature|table_constrV2");
    }
}
