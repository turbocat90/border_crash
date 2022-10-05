using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Hedgehog : MonoBehaviour
{
    [Range(0,9)] public int PuddledegreeOfStrength;   
    [Range(0,9)] public int OildegreeOfStrength;
    [Range(0,9)] public int LittleRockdegreeOfStrength;
    [Range(0,9)] public int TreedegreeOfStrength;
    [Range(0,9)] public int FencedegreeOfStrength;
    [Range(0,9)] public int BetondegreeOfStrength;
    [Range(0,9)] public int ZombiedegreeOfStrength;
    public TextMeshPro value;
    public Animator animator;
    public int LittleRockDamage;
    public int TreeDamage;
    public int BarrelDamage;
    public int FenceDamage;
    public int BetonDamage;
    public int BarellExpForce;
    public float TreeHP;
    public float FenceHP;
    public float BetonHP;
    public float LittleRockHP;
    public int ZombieParts;
    public ParticleSystem BarellParticleExp;
    public TypeTrap trap;
    private int PuddleDamage = 0;
    private int OilDamage = 0;
    private int BigRockdegreeOfStrength = 9;
    private int BigRockDamage = 0;
    private int ZombieDamage = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent(out Car car))
        {
            if (trap == TypeTrap.Puddle)
                car.TakeDamage(PuddledegreeOfStrength, PuddleDamage);
            if (trap == TypeTrap.BigRock)
                car.TakeDamage(BigRockdegreeOfStrength, BigRockDamage, true);
            if (trap == TypeTrap.Oil)
                car.Skidding();
            if (trap == TypeTrap.LittleRock)
            {
                if (car.GetDamage() >= LittleRockHP)
                {
                    car.TakeDamage(LittleRockdegreeOfStrength, PuddleDamage);
                    ActionSystem.AddParts((int)LittleRockHP);
                    SetTextValue((int)LittleRockHP);
                    gameObject.SetActive(false);
                }
                else
                {
                    LittleRockHP -= car.GetDamage();
                    ActionSystem.AddParts((int)car.GetDamage());
                    SetTextValue((int)car.GetDamage());
                }
            }
            if (trap == TypeTrap.Tree)
            {
                if (car.GetDamage() >= TreeHP)
                {
                    car.TakeDamage(TreedegreeOfStrength, TreeDamage);
                    ActionSystem.AddParts((int)TreeHP);
                    SetTextValue((int)TreeHP);
                    gameObject.SetActive(false);
                }
                else
                {
                    TreeHP -= car.GetDamage();
                    ActionSystem.AddParts((int)car.GetDamage());
                    SetTextValue((int)car.GetDamage());
                }
            }
            if (trap == TypeTrap.Fence)
            {
                if (car.GetDamage() >= FenceHP)
                {
                    car.TakeDamage(FencedegreeOfStrength, FenceDamage);
                    ActionSystem.AddParts((int)FenceHP);
                    SetTextValue((int)FenceHP);
                    gameObject.SetActive(false);
                }
                else
                {
                    FenceHP -= car.GetDamage();
                    ActionSystem.AddParts((int)car.GetDamage());
                    SetTextValue((int)car.GetDamage());
                }
            }
            if (trap == TypeTrap.Beton)
            {
                if (car.GetDamage() >= BetonHP)
                {
                    car.TakeDamage(BetondegreeOfStrength, BetonDamage);
                    ActionSystem.AddParts((int)BetonHP);
                    SetTextValue((int)BetonHP);
                    gameObject.SetActive(false);
                }
                else
                {
                    BetonHP -= car.GetDamage();
                    ActionSystem.AddParts((int)car.GetDamage());
                    SetTextValue((int)car.GetDamage());
                }
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.TryGetComponent(out Car car))
        {
            if (trap == TypeTrap.Oil)
                car.TakeDamage(OildegreeOfStrength, OilDamage);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (trap == TypeTrap.Barell)
        {
            if (other.TryGetComponent(out Car car))
            {
                car.TakeDamage(0, BarrelDamage);
                if (other.TryGetComponent(out Rigidbody rb))
                {
                    rb.AddExplosionForce(BarellExpForce, transform.position, 0, 0, ForceMode.Impulse);
                    SetTextValue(500);
                    BarellParticleExp.Play();
                    StartCoroutine(DelayDestroy());
                }
            }
        }
        if (trap == TypeTrap.Zombie)
        {
            ActionSystem.AddParts(ZombieParts);
           
            if (other.TryGetComponent(out Car car))
            {
                SetTextValue(ZombieParts);
                car.TakeDamage(ZombiedegreeOfStrength, ZombieDamage);
            }
        }
    }
    IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }
    public void SetTextValue(int value)
    {
        if (this.value != null)
        {
            this.value.text = value.ToString();
            this.value.gameObject.transform.rotation = Quaternion.Euler(80, 0, 0);
        }
        
        animator.SetTrigger("StartText");
    }
}
[Serializable]
public enum TypeTrap
{
    Puddle,
    Oil,
    BigRock,
    LittleRock,
    Tree,
    Barell,
    Fence,
    Beton,
    Zombie
}

