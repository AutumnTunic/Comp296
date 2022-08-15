using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emmiter : MonoBehaviour
{

    // public GameObject objectToSpawn;
    public Rigidbody2D objectToSpawn;
    public float SpeedMult;
    public float timeSpawnDelay;
    Collider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        spawn();
    }



    public void spawn()
    {
        Vector2 distanceVector = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position; // this works for  a non rotating object but not a rotating one
        float angle = Mathf.Atan2(distanceVector.y, distanceVector.x) * Mathf.Rad2Deg;
        // Quaternion.AngleAxis(angle, Vector3.forward); // somewhat works to aim projectiles

        Rigidbody2D clone = Instantiate(objectToSpawn, transform.position , Quaternion.AngleAxis(angle, Vector3.forward));
        clone.velocity = transform.TransformDirection(distanceVector * SpeedMult);
        collider = clone.GetComponent<Collider2D>();
        Invoke("colliderActivate", timeSpawnDelay);
    }

    void colliderActivate()
    {
        collider.enabled = true;
    }

}
