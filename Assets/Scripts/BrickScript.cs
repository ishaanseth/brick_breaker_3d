using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour
{
    
    public int points;
    public int hitsToBreak;
    public Material hitMaterial;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BreakBrick(){
        hitsToBreak--;
        GetComponent<MeshRenderer>().material = hitMaterial;
    }
}
