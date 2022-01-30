using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TargetRenderQueue : MonoBehaviour
{

    public Image target;

    // Use this for initialization
    void Start()
    {
        Material targetMaterial = target.GetComponent<MeshRenderer>().material;
        targetMaterial.renderQueue = 2000 + 1;
    }

}
