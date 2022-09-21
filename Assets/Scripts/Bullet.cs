using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    void Update()
    {
        StartCoroutine(WaiterForDestroy());
    }
    IEnumerator WaiterForDestroy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
