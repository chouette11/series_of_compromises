using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sliderRotation : MonoBehaviour
{
    public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        canvas.transform.rotation = Camera.main.transform.rotation;
    }
}
