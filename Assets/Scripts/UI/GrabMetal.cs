using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GrabMetal : MonoBehaviour
{
    [SerializeField] private TextMeshPro value;
    [SerializeField] private Animator animator;
    public void SetTextValue(int value)
    {
        this.value.text = value.ToString();
        animator.SetTrigger("StartText");
    }
}
