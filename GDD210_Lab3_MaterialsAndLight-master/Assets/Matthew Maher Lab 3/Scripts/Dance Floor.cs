using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceFloor : MonoBehaviour
{
    public int start;
    Color[] colors = new Color[] { Color.red, Color.magenta, Color.yellow, Color.green, Color.cyan };
    private float timePassed;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Renderer>().material.SetColor("_EmissionColor", colors[start]);
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed >= 0.35f)
        {
            this.GetComponent<Renderer>().material.SetColor("_EmissionColor", colors[start]);
            timePassed = 0f;
            start += 1;
            if (start > 4)
            {
                start = 0;
            }
        }
    }
}
