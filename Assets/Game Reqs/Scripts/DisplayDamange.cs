using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] Canvas ImpactCanvas;
    [SerializeField] float ImpactTime = 0.25f;
    
    
    void Start()
    {
        ImpactCanvas.enabled = false;    
    }

    public void ShowDamageImpact()
    {
        StartCoroutine(ControlImpactCanvas());
    }

    public IEnumerator ControlImpactCanvas()
    {
        ImpactCanvas.enabled = true;    
        yield return new WaitForSeconds(ImpactTime);
        ImpactCanvas.enabled = false;    
    }
}
