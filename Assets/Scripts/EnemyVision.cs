using UnityEngine;
using System.Collections;
using UnityEngine.AI;


public class EnemyVision : MonoBehaviour
{

    public Vector3 offset;
    public Transform target;
    public Transform homePos;
    private NavMeshAgent navMesh;
    public string targetTag = "Player";
    public int rays = 5;
    public int distance = 5;
    public float angle = 35;

    public bool visionInfo;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag(targetTag).transform;
        navMesh = GetComponent<NavMeshAgent>();
    }

    bool RayToScan()
    {
        bool result = false;
        bool a = false;
        bool b = false;
        float j = 0;
        for (int i = 0; i < rays; i++)
        {
            var x = Mathf.Sin(j);
            var y = Mathf.Cos(j);

            j += angle * Mathf.Deg2Rad / rays;

            Vector3 dir = transform.TransformDirection(new Vector3(x, 0, y));
            if (GetRaycast(dir)) a = true;

            if (x != 0)
            {
                dir = transform.TransformDirection(new Vector3(-x, 0, y));
                if (GetRaycast(dir)) b = true;
            }
        }
        if (a || b) result = true;
        return result;
    }
    bool GetRaycast(Vector3 dir)
    {
        bool result = false;
        RaycastHit hit = new RaycastHit();
        Vector3 pos = transform.position + offset;
        if (Physics.Raycast(pos, dir, out hit, distance))
        {
            if (hit.transform == target)
            {
                result = true;
                Debug.DrawLine(pos, hit.point, Color.green);
            }
            else
            {
                Debug.DrawLine(pos, hit.point, Color.blue);
            }
        }
        else
        {
            Debug.DrawRay(pos, dir * distance, Color.red);
        }
        return result;
    }

    void FixedUpdate()
    {
        /*if (Vector3.Distance(transform.position, target.position) < distance)
        {
            
        }
        else
        {

        } */
        if (RayToScan())
        {
            navMesh.SetDestination(target.position);
            visionInfo = true;

        }
        else
        {
            visionInfo = false;
            StartCoroutine(Waiter());
        }
    }
    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(3f);
    }
}