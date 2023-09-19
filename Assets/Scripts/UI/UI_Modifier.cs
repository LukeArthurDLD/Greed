using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Modifier : MonoBehaviour
{
    [SerializeField]
    internal UI_Management scriptUIManagement;

    internal string[] modifiers = { "Speed Buff", "Speed Nerf", "Damage Buff", "Damage Nerf", "Health Buff", "Health Nerf" };
    
    void Start()
    {
        RandomModifier();
    }

    private void RandomModifier()
    {
        int _rand = Random.Range(0, modifiers.Length);
        scriptUIManagement.activeModifier = modifiers[_rand];
    }
}
