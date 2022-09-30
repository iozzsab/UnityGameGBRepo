using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLvl : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
          print("Конец уровня");
          SceneManager.LoadScene(2);//для зацикливания
        }
    }
}
