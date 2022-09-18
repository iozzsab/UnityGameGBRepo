using UnityEngine;

public class HealPoint : MonoBehaviour
{
    [SerializeField] private int pointvlue = 35;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHeal>().RecountHP(pointvlue);
            Destroy(gameObject);
        }
    }
}
