using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Hedgehog : MonoBehaviour
{
    [Range(0,9)] public int PuddledegreeOfStrength;   
    [Range(0,9)] public int OildegreeOfStrength;
    [Range(0,9)] public int LittleRockdegreeOfStrength;
    [Range(0,9)] public int TreedegreeOfStrength;
    [Range(0,9)] public int FencedegreeOfStrength;
    [Range(0,9)] public int BetondegreeOfStrength;
    [Range(0,9)] public int ZombiedegreeOfStrength;
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
                car.TakeDamage(LittleRockdegreeOfStrength, PuddleDamage);
                LittleRockHP -= car.GetDamage();
                if (LittleRockHP <= 0)
                    gameObject.SetActive(false);
            }
            if (trap == TypeTrap.Tree)
            {
                car.TakeDamage(TreedegreeOfStrength, TreeDamage);
                TreeHP -= car.GetDamage();
                if (TreeHP <= 0)
                    gameObject.SetActive(false);
            }
            if (trap == TypeTrap.Fence)
            {
                car.TakeDamage(FencedegreeOfStrength, FenceDamage);
                FenceHP -= car.GetDamage();
                if (FenceHP <= 0)
                    gameObject.SetActive(false);
            }
            if (trap == TypeTrap.Beton)
            {
                car.TakeDamage(BetondegreeOfStrength, BetonDamage);
                BetonHP -= car.GetDamage();
                if (BetonHP <= 0)
                    gameObject.SetActive(false);
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
                    BarellParticleExp.Play();
                    StartCoroutine(DelayDestroy());
                }
            }
        }
        if (trap == TypeTrap.Zombie)
        {
            if (other.TryGetComponent(out Car car))
                car.TakeDamage(ZombiedegreeOfStrength, ZombieDamage);
        }
    }
    IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
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

