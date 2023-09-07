using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationController : MonoBehaviour
{
 [SerializeField] Animator animator;

 public void grab()
 {
    animator.Play("metarig|metarigAction");
 }
 public void drop()
 {
     animator.Play("drop");
 }
 public void fix()
 {
     animator.Play("fix");
 }
}
