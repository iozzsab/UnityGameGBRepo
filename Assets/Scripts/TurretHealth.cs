using StartGameDev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class TurretHealth : MonoBehaviour
{
    [SerializeField] private int maximumHP = 100;
    [SerializeField] private int currentHP;

    private float fill;
    public Image bar;
    [SerializeField] private GameObject BarCanvas;
    [SerializeField] private GameObject Particle;

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

        print("���������� ������ ����� " + currentHP);
        if (currentHP <= 0)
        {

            //agent.enabled = false;

            //characterController.enabled = false;
            Particle.SetActive(true);
            BarCanvas.SetActive(false);
            GetComponent<Turret>().enabled = false;
           

            StartCoroutine(WaterForDestroy());


        }
        IEnumerator WaterForDestroy()
        {
            yield return new WaitForSeconds(2.5f);
            Destroy(gameObject);
        }
    }
}