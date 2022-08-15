using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBall : MonoBehaviour
{
Vector2 difference = Vector2.zero;

    // Start is called before the first frame update

    

    private void OnMouseDown()
    {
        difference = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
    }

    private void OnMouseDrag()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference; // puts circle in mouse radius
    }    




    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      //  transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition); // keeps ball at cursor position
    }
}
