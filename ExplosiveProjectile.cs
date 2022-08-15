using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ExplosiveProjectile : MonoBehaviour
{
    public GameObject projectile;
    public GameObject explosionTexture;
    private bool collides;
    public float explosionRadius;
    public float explosionForce;
    public float explosionTime;
    Collider2D[] colliders;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) || collides == true)
        {
            explosionTexture.SetActive(true);
            Destroy(projectile.GetComponent<CircleCollider2D>());
            AddExplosionForce();           
            Destroy(projectile, explosionTime);// destroy proj after explosionTime sec
        }
    }

    private void OnCollisionEnter2D()
    {
        collides = true;
    }

    void AddExplosionForce()
    {
        colliders = Physics2D.OverlapCircleAll(projectile.transform.position, explosionRadius);
        foreach (Collider2D coll in colliders)
        {
            Rigidbody2D rigid = coll.GetComponent<Rigidbody2D>();
            if (rigid != null) //  && !rigid.CompareTag("Player")
            {
                Vector2 forceDirection = (rigid.transform.position - projectile.transform.position);
                if (forceDirection.magnitude > 0)
                {
                    Vector2 exForce = forceDirection.normalized * explosionForce * (forceDirection.magnitude / explosionRadius);
                    rigid.AddForce(exForce);
                }
            }

        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}





/*

        

        var forceDirection = (rigid.transform.position - exPosition);
        rigid.velocity = new Vector2(rigid.velocity.x * exForce, rigid.velocity.y * exForce);
rigid.AddForce(baseForce);
rigid.velocity = new Vector3(rigid.velocity.x * baseForce, rigid.velocity.y * baseForce);



    void Update()
    {
         if (Input.GetMouseButtonDown(1) || collides == true)
         {
             Destroy(projectile.GetComponent<CircleCollider2D>());
             Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
             foreach(Collider2D coll in colliders)
             {
                if (coll.GetComponent<Rigidbody2D>()) //  && !coll.CompareTag("Player")
                {
                    AddExplosionForce(coll.GetComponent<Rigidbody2D>(), explosionForce, explosionRadius, projectile.transform.position);
                }
             }
             Destroy(projectile, explosionTime);// destroy proj after explosionTime sec
         }
    }

    private void OnCollisionEnter2D()
    {
        collides = true;
    }

    private void AddExplosionForce(Rigidbody2D rigid, float exForce, float exRadius, Vector3 exPosition)
    {
        var forceDirection = (rigid.transform.position - exPosition);
        Vector3 baseForce = forceDirection.normalized * exForce * (forceDirection.magnitude / exRadius);
        rigid.AddForce(baseForce);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

}

    
            
        Vector3 baseForce = forceDirection.normalized * exForce * (forceDirection.magnitude / exRadius);
        rigid.AddForce(baseForce);
        */
