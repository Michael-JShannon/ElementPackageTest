using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerElementDisplay : MonoBehaviour
{
    [SerializeField]
    Player player;

    Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        image.color = player.GetComponentInParent<ElementHolder>().element.color;
    }
}
