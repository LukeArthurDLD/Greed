using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    public int selectedAbility = 0;
    public Transform[] abilities;

    private void Start()
    {
        

    }

    void Update()
    {
       

    }
    public void SelectAbility(int index)
    {
        selectedAbility = index;
        for (int i = 0; i < abilities.Length; i++)
        {
            if (i == index)
                abilities[i].gameObject.SetActive(true);
            else
                abilities[i].gameObject.SetActive(false);

        }
    }

}
