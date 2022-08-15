using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attracted : MonoBehaviour
{

[SerializeField] private bool rotateToCenter = true;
[SerializeField] Attractor currentAttractor;

Transform m_transform;
Collider2D m_collider;
Rigidbody2D m_rigidbody;

    // Start is called before the first frame update
    private void Awake()
    {
        m_transform = GetComponent<Transform>();
        m_collider = GetComponent<Collider2D>();
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentAttractor != null)
        {
            if (!currentAttractor.AttractedObjects.Contains(m_collider)) currentAttractor = null;
            if (rotateToCenter) RotateToCenter();
        }
        
    }

    public void Attract(Attractor artgra)
    {
        Vector2 attractionDir = (Vector2)artgra.planetTransform.position - m_rigidbody.position;
        m_rigidbody.AddForce(attractionDir.normalized * artgra.gravity * 100 * Time.fixedDeltaTime);

        if (currentAttractor == null)
        {
            currentAttractor = artgra;
        }
    }

    void RotateToCenter()
    {
        Vector2 distanceVector = (Vector2)currentAttractor.planetTransform.position - (Vector2)m_transform.position;
        float angle = Mathf.Atan2(distanceVector.y, distanceVector.x) * Mathf.Rad2Deg;
        m_transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
    }
}
