using UnityEngine;
using TMPro;
using System;


public class SingleGeosampleScreen : MonoBehaviour
{
    public static int id_counter = 0;

    public Geosample Sample;
    public GeoSampleScreens CurrentScreen;

    public GameObject NameScreen;
    public GameObject ZoneScreen;
    public GameObject ColorScreen;
    public GameObject ShapeScreen;
    public GameObject VoiceNotesScreen;

    private void Start()
    {
        NameScreen.SetActive(false);
        ZoneScreen.SetActive(false);
        ColorScreen.SetActive(false);
        ShapeScreen.SetActive(false);
        VoiceNotesScreen.SetActive(false);

        CurrentScreen = GeoSampleScreens.None;
        SetID();
        SetCoordinates();
        SetTime();
        SetSampleName("Sample " + Sample.geosample_id);

        // set zone if within a zone

    }
    public void Load(Geosample Sample_f)
    {
        Sample = Sample_f;
        // Set all relevant data 
    }
    public void SendData()
    {
        GameObject.Find("Controller").GetComponent<WebsocketDataHandler>().SendGeosampleData();
    }

    public enum GeoSampleScreens
    {
        None,
        Name,
        Zone,
        XRFScan,
        Shape,
        Color,
        VoiceNotes,
        TakePhoto
    }

    // ----------------- Buttons -----------------
    public void OnNameButtonPressed()
    {
        if (CurrentScreen != GeoSampleScreens.Name)
        {
            CloseCurrentScreen();
        }
        
        CurrentScreen = GeoSampleScreens.Name;
        NameScreen.SetActive(true);
        
    }
    public void OnZoneButtonPressed()
    {
        if (CurrentScreen != GeoSampleScreens.Zone)
        {
            CloseCurrentScreen();
        }
        
        CurrentScreen = GeoSampleScreens.Zone;
        ZoneScreen.SetActive(true);
        
    }
    public void OnXRFButtonPressed()
    {
        if (CurrentScreen != GeoSampleScreens.XRFScan)
        {
            CloseCurrentScreen();
        }
        else
        {
            CurrentScreen = GeoSampleScreens.XRFScan;
            // XRFScreen.SetActive(true);
        }
    }
    public void OnShapeButtonPressed()
    {
        if (CurrentScreen != GeoSampleScreens.Shape)
        {
            CloseCurrentScreen();
        }
        
        CurrentScreen = GeoSampleScreens.Shape;
        ShapeScreen.SetActive(true);
        
    }
    public void OnColorButtonPressed()
    {
        if (CurrentScreen != GeoSampleScreens.Color)
        {
            CloseCurrentScreen();
        }
        
        CurrentScreen = GeoSampleScreens.Color;
        ColorScreen.SetActive(true);
        
    }
    public void OnPhotoButtonPressed()
    {
        if (CurrentScreen != GeoSampleScreens.Name)
        {
            CloseCurrentScreen();
        }
        
        CurrentScreen = GeoSampleScreens.Name;
        NameScreen.SetActive(true);
        
    }
    public void OnVEGAButtonPressed()
    {
        if (CurrentScreen != GeoSampleScreens.VoiceNotes)
        {
            CloseCurrentScreen();
        }
        
        CurrentScreen = GeoSampleScreens.VoiceNotes;
        VoiceNotesScreen.SetActive(true);
        
    }
    public void CloseCurrentScreen()
    {
        switch (CurrentScreen)
        {
            case GeoSampleScreens.None:
                break;
            case GeoSampleScreens.Name:
                NameScreen.SetActive(false);
                break;
            case GeoSampleScreens.Zone:
                ZoneScreen.SetActive(false);
                break;
            case GeoSampleScreens.XRFScan:
                // NameScreen.SetActive(false);
                break;
            case GeoSampleScreens.Shape:
                ShapeScreen.SetActive(false);
                break;
            case GeoSampleScreens.Color:
                ColorScreen.SetActive(false);
                break;
            case GeoSampleScreens.VoiceNotes:
                VoiceNotesScreen.SetActive(false);
                break;
            case GeoSampleScreens.TakePhoto:
                // PhotoScreen.SetActive(false);
                break;
        }
        CurrentScreen = GeoSampleScreens.None;
    }


    // -------------- Setter Methods --------------
    public TextMeshPro Zone_tmp;
    public TextMeshPro ZoneLetter_tmp;
    public TextMeshPro ZoneNone_tmp;
    public GameObject Zone_icon;
    public TextMeshPro OtherZone_tmp;

    public TextMeshPro RockType_tmp;
    public TextMeshPro XRF_tmp;

    public GeosamplingShapes Shape_visual;
    public GeosamplingColor Color_visual;

    public TextMeshPro Name_tmp;

    public void SetSampleName(string name)
    {
        Name_tmp.text = name;

        // TODO update Sample.name
        SendData();
    }
    public void SetID()
    {
        // this will be automatic assignment based on global ID
        // maybe a static variable for this class or smth
        // called on start function
        Sample.geosample_id = id_counter++;
    }
    public void SetZone(string letter)
    {
        letter = letter.Trim();
        ZoneLetter_tmp.gameObject.SetActive(true);
        ZoneLetter_tmp.text = letter;
        ZoneNone_tmp.text = "";
        Zone_icon.SetActive(true);
        OtherZone_tmp.gameObject.SetActive(true);
        OtherZone_tmp.text = "Zone " + letter;

        Sample.zone_id = letter[0];
        SendData();
    }
    public void SetCoordinates()
    {
        // also automatic assignment
        // called on start function
        Sample.location = GPSUtils.AppPositionToGPSCoords(Camera.main.transform.position + (Camera.main.transform.forward * 0.5f));
    }
    public void SetTime()
    {
        // also automatic assignment
        // called on start function
        Sample.time = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
    }
    public void SetRockType(string name)
    {
        // automatic assignment
        // called after xrf scan
        RockType_tmp.text = name;

        // TODO update Sample.rockType
        SendData();
    }
    [SerializeField]
    public void SetShape(GeosamplingShape shape_in)
    {
        Shape_visual.SetShape(shape_in.shape);

        switch (shape_in.shape)
        {
            case GeosamplingShape.Shape.None:
                Sample.shape = "Shape";
                break;
            case GeosamplingShape.Shape.Polygon:
                Sample.shape = "Polygon";
                break;
            case GeosamplingShape.Shape.Cube:
                Sample.shape = "Cube";
                break;
            case GeosamplingShape.Shape.Cylinder:
                Sample.shape = "Cylinder";
                break;
            case GeosamplingShape.Shape.Cone:
                Sample.shape = "Cone";
                break;
            case GeosamplingShape.Shape.Sphere:
                Sample.shape = "Sphere";
                break;
            case GeosamplingShape.Shape.Crystalline:
                Sample.shape = "Crystalline";
                break;
            case GeosamplingShape.Shape.Ellipsoid:
                Sample.shape = "Ellipsoid";
                break;
            case GeosamplingShape.Shape.Irregular:
                Sample.shape = "Irregular";
                break;
            default:
                Debug.LogError("Shape error");
                break;
        }

        SendData();
        CloseCurrentScreen();
    }
    public void SetColor(string hex)
    {
        Color_visual.SetColor(hex);
        Sample.color = hex;
        SendData();
    }
    public void SetPhoto()
    {
        // TODO show photo

        // TODO update Sample.photo
        SendData();
    }
    public void SetNote()
    {
        // TODO update tmp

        // TODO update Sample.note
        SendData();
    }


    // -------------- Screen Visuals --------------
    private void Update()
    {
        // Rotate to user
        transform.forward = transform.position - Camera.main.transform.position;
    }
    
}
