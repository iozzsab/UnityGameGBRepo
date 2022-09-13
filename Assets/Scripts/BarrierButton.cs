using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BarrierButton : MonoBehaviour
{
    [SerializeField] private Material buttonMaterial;
    [SerializeField] private GameObject Electricity;
    float timer = 10f;
        
    void Start()
    {
        buttonMaterial = GetComponentInChildren<Renderer>().material;
    }
    public void OnTriggerEnter(Collider myTrigger)
    {
        if (myTrigger.gameObject.tag == "bullet")
        {
            buttonMaterial.color = Color.red;
            Electricity.SetActive(false);
            Debug.Log("Барьер выключен");
            StartCoroutine(Waiter());
        }
        
    }
    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(timer);
        buttonMaterial.color = Color.green;
        Electricity.SetActive(true);
    }
}


