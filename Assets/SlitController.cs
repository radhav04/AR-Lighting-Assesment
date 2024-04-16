using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class SlitController : MonoBehaviour
{
    public GameObject topBar;
    public GameObject bottomBar;
    public GameObject rightBar;
    public GameObject leftBar;
    public Material borderMaterial;
    public TextMeshPro count;
    private char[] slitOrder = { 'R', 'D', 'L', 'U', 'R', 'U', 'D', 'L', 'R', 'U', 'D', 'L', 'U', 'R', 'D', 'L', 'L', 'U', 'D', 'R', 'U', 'R', 'D', 'L', 'D', 'R', 'L', 'U', 'R', 'D', 'U', 'L', 'R', 'U', 'D', 'L', 'R', 'D', 'L', 'U', 'L', 'U', 'R', 'D', 'R', 'U', 'D', 'L', 'U', 'R', 'L', 'D', 'R', 'U', 'D', 'L', 'R', 'U', 'L', 'D' };
    private char[] colorOrder = { 'r', 'g', 'o', 'b', 'p', 'y', 'b', 'r', 'g', 'p', 'o', 'y', 'y', 'b', 'g', 'o', 'r', 'p', 'g', 'r', 'b', 'y', 'p', 'o', 'o', 'g', 'b', 'p', 'y', 'r', 'b', 'y', 'p', 'g', 'r', 'o', 'g', 'y', 'r', 'o', 'b', 'p', 'y', 'o', 'g', 'r', 'p', 'b', 'g', 'y', 'p', 'b', 'r', 'o', 'p', 'r', 'g', 'b', 'o', 'y' };
    private int index = -1;
    Color blue = new Color(0, 0, 1);
    Color red = new Color(1, 0, 0);
    Color green = new Color(0, 1, 0);
    Color yellow = new Color(1, 1, 0);
    Color orange = new Color(1, 0.5f, 0);
    Color purple = new Color(0.5f, 0, 1);
    // Start is called before the first frame update
    void Start()
    {
        count.text = "N/A";
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
        count.text = index.ToString();
    }
}
