using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamWeaponScript : MonoBehaviour
{
    public Transform shootingTransform;
    public LayerMask shootableLayer;
    public LineRenderer lineRenderer;
    public Light lights;
    public float range;

    public void BeamCreation() 
    {
        StartCoroutine(Beam());
    }

    IEnumerator Beam()
    {
        lights.enabled = true;
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, shootingTransform.position);
        if (Physics.Raycast(shootingTransform.position, shootingTransform.forward, out RaycastHit hitInfo, range, shootableLayer)) 
        {
            lineRenderer.SetPosition(1, hitInfo.point);
        }
        else
        {
            lineRenderer.SetPosition(1, shootingTransform.position + shootingTransform.forward * range);
        }
        yield return new WaitForEndOfFrame();
        lights.enabled = false;
        lineRenderer.enabled = false;
    }
}
