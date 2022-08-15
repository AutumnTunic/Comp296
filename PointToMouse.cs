using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToMouse : MonoBehaviour
{

    Transform pointer;
    // Start is called before the first frame update
    void Start()
    {
        pointer = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        

        mouseDistance();

        
    }


    void mouseDistance()
    {
        Vector2 distanceVector = (Vector2)transform.position - (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(distanceVector.y, distanceVector.x) * Mathf.Rad2Deg;
        pointer.rotation = Quaternion.AngleAxis(angle - 90, transform.forward);
    }
    }


    

