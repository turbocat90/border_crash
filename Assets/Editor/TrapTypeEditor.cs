using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;

[CustomEditor(typeof(Hedgehog))]
public class TrapTypeEditor : Editor
{
    SerializedProperty Type;
    SerializedProperty PuddledegreeOfStrength;
    SerializedProperty OildegreeOfStrength;
    SerializedProperty ZombiedegreeOfStrength;
    SerializedProperty LittleRockdegreeOfStrength;
    SerializedProperty LittleRockDamage;
    SerializedProperty LittleRockHP;
    SerializedProperty TreedegreeOfStrength;
    SerializedProperty TreeDamage;
    SerializedProperty TreeHP;
    SerializedProperty BarrelDamage;
    SerializedProperty BarellParticleExp;
    SerializedProperty FencedegreeOfStrength;
    SerializedProperty FenceDamage;
    SerializedProperty FenceHP;
    SerializedProperty BetondegreeOfStrength;
    SerializedProperty BetonDamage;
    SerializedProperty BetonHP;
    SerializedProperty ZombieParts;
    SerializedProperty value;
    SerializedProperty animator;
    SerializedProperty BetonFractureObject;
    private void OnEnable()
    {
        Type = serializedObject.FindProperty("trap");
        PuddledegreeOfStrength = serializedObject.FindProperty("PuddledegreeOfStrength");
        OildegreeOfStrength = serializedObject.FindProperty("OildegreeOfStrength");
        ZombiedegreeOfStrength = serializedObject.FindProperty("ZombiedegreeOfStrength");
        LittleRockdegreeOfStrength = serializedObject.FindProperty("LittleRockdegreeOfStrength");
        LittleRockHP = serializedObject.FindProperty("LittleRockHP");
        LittleRockDamage = serializedObject.FindProperty("LittleRockDamage");
        TreedegreeOfStrength = serializedObject.FindProperty("TreedegreeOfStrength");
        TreeHP = serializedObject.FindProperty("TreeHP");
        TreeDamage = serializedObject.FindProperty("TreeDamage");
        BarrelDamage = serializedObject.FindProperty("BarrelDamage");
        BarellParticleExp = serializedObject.FindProperty("BarellParticleExp");
        FencedegreeOfStrength = serializedObject.FindProperty("FencedegreeOfStrength");
        FenceDamage = serializedObject.FindProperty("FenceDamage");
        FenceHP = serializedObject.FindProperty("FenceHP");
        BetondegreeOfStrength = serializedObject.FindProperty("BetondegreeOfStrength");
        BetonDamage = serializedObject.FindProperty("BetonDamage");
        BetonHP = serializedObject.FindProperty("BetonHP");
        BetonFractureObject = serializedObject.FindProperty("BetonFractureObject");
        value = serializedObject.FindProperty("value");
        animator = serializedObject.FindProperty("animator");
        ZombieParts = serializedObject.FindProperty("ZombieParts");
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(Type);
        if (Type.enumValueIndex == (int)TypeTrap.Puddle)
        {
            EditorGUILayout.PropertyField(PuddledegreeOfStrength);
        }
        EditorGUILayout.Space();
        if (Type.enumValueIndex == (int)TypeTrap.Oil)
        {
            EditorGUILayout.PropertyField(OildegreeOfStrength);
        }
        EditorGUILayout.Space();
        if (Type.enumValueIndex == (int)TypeTrap.LittleRock)
        {
            EditorGUILayout.PropertyField(LittleRockdegreeOfStrength);
            EditorGUILayout.PropertyField(LittleRockHP);
            EditorGUILayout.PropertyField(LittleRockDamage);
        }
        EditorGUILayout.Space();
        if (Type.enumValueIndex == (int)TypeTrap.Tree)
        {
            EditorGUILayout.PropertyField(TreedegreeOfStrength);
            EditorGUILayout.PropertyField(TreeHP);
            EditorGUILayout.PropertyField(TreeDamage);
        }
        EditorGUILayout.Space();
        if (Type.enumValueIndex == (int)TypeTrap.Barell)
        {
            EditorGUILayout.PropertyField(BarrelDamage);
            EditorGUILayout.PropertyField(BarellParticleExp);
        }
        EditorGUILayout.Space();
        if (Type.enumValueIndex == (int)TypeTrap.Fence)
        {
            EditorGUILayout.PropertyField(FencedegreeOfStrength);
            EditorGUILayout.PropertyField(FenceDamage);
            EditorGUILayout.PropertyField(FenceHP);
        }
        EditorGUILayout.Space();
        if (Type.enumValueIndex == (int)TypeTrap.Beton)
        {
            EditorGUILayout.PropertyField(BetondegreeOfStrength);
            EditorGUILayout.PropertyField(BetonDamage);
            EditorGUILayout.PropertyField(BetonHP);
            EditorGUILayout.PropertyField(BetonFractureObject);
        }
        EditorGUILayout.Space();
        if (Type.enumValueIndex == (int)TypeTrap.Zombie)
        {
            EditorGUILayout.PropertyField(ZombiedegreeOfStrength);
        }
        if (Type.enumValueIndex == (int)TypeTrap.Zombie)
        {
            EditorGUILayout.PropertyField(ZombieParts);
        }

        EditorGUILayout.PropertyField(value);
        EditorGUILayout.PropertyField(animator);
        serializedObject.ApplyModifiedProperties();
    }
}
