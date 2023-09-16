using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class player_Movement_scr : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject markerPfb;
    public float distance = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray movePos = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(movePos, out var hitInfo))
            {
                agent.SetDestination(hitInfo.point);
                RaycastHit hit;
                if (Physics.Raycast(movePos, out hit, distance))
                {
                    Destroy(GameObject.FindWithTag("marker"));
                    GameObject marker = Instantiate(markerPfb, hit.point, Quaternion.identity);
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "marker")
        {
            Destroy(collision.gameObject);
            
        }
    }
}
