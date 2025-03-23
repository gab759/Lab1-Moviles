using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailManager : MonoBehaviour
{
    public GameObject trailPrefab;
    public Color currentColor = Color.white;

    private GameObject currentTrail;

    public void StartTrail(Vector3 position)
    {
        currentTrail = Instantiate(trailPrefab, position, Quaternion.identity);
        TrailRenderer trail = currentTrail.GetComponent<TrailRenderer>();
        if (trail != null)
        {
            trail.material.color = currentColor;
            trail.startColor = currentColor;
            trail.endColor = currentColor;
        }
    }

    public void UpdateTrail(Vector3 position)
    {
        if (currentTrail != null)
        {
            currentTrail.transform.position = position;
        }
    }

    public void EndTrail()
    {
        if (currentTrail != null)
        {
            Destroy(currentTrail, 0.2f);
            currentTrail = null;
        }
    }
}