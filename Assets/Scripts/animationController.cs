using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationController : MonoBehaviour
{
 [SerializeField] Animator animator;

 public void grab()
 {
    animator.Play("Armature|Hand_Select");
 }
 public void select()
 {
     animator.Play("Armature|Hand_Object");
 }
 public void idlobject()
 {
        animator.Play("Armature|Hand_Object_Idlev1");
 }
    public void drop()
    {
        animator.Play("Armature|Hand_Object_Drop");
    }
    public void fix()
    {
        animator.Play("Armature|Hand_Build");
    }
}
