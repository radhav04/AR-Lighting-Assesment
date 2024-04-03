using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SlitController : MonoBehaviour
{
    public GameObject topBar;
    public GameObject bottomBar;
    public GameObject rightBar;
    public GameObject leftBar;
    public Material borderMaterial;
    private char[] slitOrder = { 'R', 'D', 'U', 'L', 'U', 'R', 'L', 'D', 'U', 'L', 'R', 'D', 'R', 'L', 'D', 'U', 'U', 'L', 'R', 'R', 'D', 'L', 'U', 'D', 'R', 'U', 'D', 'L', 'L', 'R', 'U', 'R', 'D', 'U', 'L', 'D', 'R', 'R', 'U', 'L', 'L', 'R', 'D', 'U', 'D', 'R', 'L', 'U', 'D', 'L', 'R', 'R', 'L', 'U', 'D', 'U', 'D', 'L', 'R', 'R' };
    private char[] colorOrder = { 'b', 'o', 'g', 'y', 'o', 'r', 'o', 'g', 'r', 'b', 'p', 'y', 'o', 'y', 'p', 'g', 'r', 'b', 'r', 'o', 'b', 'p', 'g', 'y', 'g', 'b', 'o', 'y', 'r', 'p', 'y', 'b', 'r', 'p', 'o', 'g', 'y', 'r', 'p', 'o', 'b', 'g', 'p', 'o', 'y', 'g', 'r', 'b', 'r', 'g', 'o', 'p', 'y', 'b', 'y', 'r', 'b', 'p', 'g', 'o' };
    private int index = 0;
    Color blue = new Color(0, 0, 1);
    Color red = new Color(1, 0, 0);
    Color green = new Color(0, 1, 0);
    Color yellow = new Color(1, 1, 0);
    Color orange = new Color(1, 0.5f, 0);
    Color purple = new Color(0.5f, 0, 1);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [SerializeField]
    public void nextBox() {
        topBar.SetActive(true);
        bottomBar.SetActive(true);
        leftBar.SetActive(true);
        rightBar.SetActive(true);
        index++;
        switch(slitOrder[index]) {
            case 'U':
                topBar.SetActive(false);
                break;
            case 'D':
                bottomBar.SetActive(false);
                break;
            case 'L':
                leftBar.SetActive(false);
                break;
            case 'R':
                rightBar.SetActive(false);
                break;
        }
        switch(colorOrder[index]) {
            case 'b':
                borderMaterial.SetColor("_Color", blue);
                break;
            case 'r':
                borderMaterial.SetColor("_Color", red);
                break;
            case 'g':
                borderMaterial.SetColor("_Color", green);
                break;
            case 'y':
                borderMaterial.SetColor("_Color", yellow);
                break;
            case 'o':
                borderMaterial.SetColor("_Color", orange);
                break;
            case 'p':
                borderMaterial.SetColor("_Color", purple);
                break;
	    }
    }
}
