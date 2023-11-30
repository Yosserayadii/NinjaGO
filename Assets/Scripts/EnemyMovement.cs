using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] patrolPoints;
    public int currentPoint;
    public float moveSpeed;
    public float timeAtPoints;
    public float waitCounter;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform t  in patrolPoints)
        {
            t.SetParent(null);  
        }
        waitCounter = timeAtPoints;
        anim=GetComponent<Animator>();
        anim.SetBool("isMoving", true);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position= Vector3.MoveTowards(transform.position, patrolPoints[currentPoint].position,moveSpeed);
        if(Vector3.Distance(transform.position , patrolPoints[currentPoint].position) < .001f)
        {
            waitCounter -= Time.deltaTime;
            anim.SetBool("isMoving", false);
            if (waitCounter <= 0)
            {
                currentPoint++;
                if (currentPoint >= patrolPoints.Length)
                {
                    currentPoint = 0;
                }
                waitCounter = timeAtPoints;
                anim.SetBool("isMoving", true);
                if(transform.position.x< patrolPoints[currentPoint].position.x)
                {
                    transform.localScale = new Vector3(-1f, 1, 1f);
                } else
                {
                    transform.localScale = Vector3.one;
                }
            }
           

        }
    }
}
