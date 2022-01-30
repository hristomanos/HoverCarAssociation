using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControlActive2Players : MonoBehaviour {

    public HoverCarControl m_hoverCarControlP1;
    public HoverCarControl m_hoverCarControlP2;

    // Use this for initialization
    void Start()
    {
        m_hoverCarControlP1.enabled = true;
        m_hoverCarControlP2.enabled = true;
    }
}
