using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeColourChanger : MonoBehaviour
{
    Material mat;
    MeshRenderer m_renderer;
    // Start is called before the first frame update
    void Start()
    {
        m_renderer = gameObject.GetComponent<MeshRenderer>();
        mat = m_renderer.material;

        Element ele = gameObject.GetComponent<ElementHolder>().element;

        mat.color = ele.color;
    }
}
