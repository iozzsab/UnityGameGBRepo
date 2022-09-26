using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHeal : MonoBehaviour
{
    
    [SerializeField] private int maximumHP = 100;
    [SerializeField] private int currentHP;
    public Image bar;
    public float fill;
    void Start()
    {
        fill = 1f;
        currentHP = maximumHP;
    }
    private void Update()
    {
        fill = currentHP * 0.01f;
        bar.fillAmount = fill;
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

        if (deltaHP > 0 && currentHP < maximumHP)
            currentHP = currentHP + deltaHP;
        else if (currentHP > maximumHP)
            currentHP = maximumHP;

        print("Количество жизней " + currentHP);
        if (currentHP <= 0)
        {
            GetComponent<Rigidbody>().freezeRotation = false;
            GetComponent<Shoot>().enabled = false;
            GetComponent<FirstPersonController>().enabled = false;
        }
    }
}
