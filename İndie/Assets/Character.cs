using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{

    public LayerMask underGround;
    private Rigidbody rbCharacter;
    private Camera mainCam;
    private Animator animCharacter;
    private Vector3 targetPoint;
    [Range(0, 5)] public float speed;


    private void Awake()
    {
        rbCharacter = GetComponent<Rigidbody>();
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        animCharacter = GetComponent<Animator>();
        targetPoint = transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        



    }

    // Update is called once per frame
    void Update()
    {
        moveUnder();
        if(Vector3.Distance(transform.position, targetPoint) > 0.1f)
        {
            animCharacter.Play("SlowRun");
        }
        else
        {
            animCharacter.Play("idle");
        }

        if(transform.position != targetPoint)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPoint, Time.deltaTime * speed);
            transform.LookAt(targetPoint);
        }
    }



    void moveUnder()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Ray rayOrigin = mainCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo = new RaycastHit();
            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                Vector2 firstPos = Input.mousePosition;
                Vector3 newPos = mainCam.ScreenToWorldPoint(firstPos);

                Debug.Log(hitInfo.point);

                targetPoint = new Vector3(hitInfo.point.x,transform.position.y, transform.position.z);

               

                
            }
        }

    }



}
