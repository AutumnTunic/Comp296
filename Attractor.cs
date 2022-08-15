using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Attractor : MonoBehaviour
{

    public LayerMask AttractionLayer;
    public float gravity = 10;
    [SerializeField] private float effectionRadius = 10;
    public List<Collider2D> AttractedObjects = new List<Collider2D>();
    [HideInInspector] public Transform planetTransform;

    // Start is called before the first frame update
    void Awake()
    {
        planetTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        SetAttractedObjects();
    }

    void FixedUpdate()
    {
        AttractedObject();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, effectionRadius);
    }

    void SetAttractedObjects()
    {
        AttractedObjects = Physics2D.OverlapCircleAll(planetTransform.position, effectionRadius, AttractionLayer).ToList();
    }

    void AttractedObject()
    {
        for(int i = 0; i < AttractedObjects.Count; i++)
        {
            AttractedObjects[i].GetComponent<Attracted>().Attract(this);
        }
    }
}
