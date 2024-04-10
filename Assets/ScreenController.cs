using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class ScreenController : MonoBehaviour
{
    public Material borderMaterial;
    public TextMeshPro count;
    public TextMeshPro text;
    private char[] colorOrder = {'r', 'o', 'b', 'y', 'g', 'p', 'y', 'b', 'g', 'r', 'p', 'o', 'p', 'g', 'o', 'b', 'r', 'y', 'r', 'p', 'g', 'y', 'o', 'b', 'b', 'y', 'p', 'o', 'r', 'g' };
    private string[] textOrder = { "EFPT", "OZLP", "EDPE", "DPEC", "FDED", "FCZP", "FELD", "PZDD", "EFPO", "TECL", "EFOD", "PCTF", "DFLT", "CEOF", "HOLC", "FTOO", "QRTP", "DECL", "RTBU", "FGDA", "LQPO", "YXZW", "NMKI", "HJED", "WCRF", "VXPL", "SKJY", "GDFQ", "MLPA", "WNDX" };
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
    public void nextBox()
    {  
        index++;
        int curSize = index / 6;
        if (curSize == 0)
        {
            text.fontSize = 0.1f;
	    }
        else if (curSize == 1)
        {
            text.fontSize = 0.08f;
	    }
        else if (curSize == 2)
        {
            text.fontSize = 0.06f;
	    }
        else if (curSize == 3)
        {
            text.fontSize = 0.04f;
	    }
        else
        {
            text.fontSize = 0.02f;
		}
        switch (colorOrder[index])
        {
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
        text.text = textOrder[index];
        count.text = index.ToString();
    }
}
