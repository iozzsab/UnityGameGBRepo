using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeal : MonoBehaviour
{
    [SerializeField] private int maximumHP = 100;
    int currentHP;          
    void Start()
    {
        currentHP = maximumHP;
    }

    public void RecountHP(int deltaHP)
    {
        if (deltaHP < 0)
        {
            currentHP = currentHP + deltaHP;
        }
        else if (currentHP > maximumHP)
        {
            currentHP = maximumHP;
        }

        print("Количество жизней " + currentHP);
        if (currentHP <= 0)
        {
            GetComponent<Rigidbody>().freezeRotation = false;
            GetComponent<Shoot>().enabled = false;
            GetComponent<FirstPersonController>().enabled = false;
        }
    }
}
