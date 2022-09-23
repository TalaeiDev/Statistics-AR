using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[ExecuteInEditMode]
public class LineController : MonoBehaviour
{
    public enum _LineAxis { PX, PY, PZ, NX, NY, NZ }
    public _LineAxis lineAxis;
    public GameObject lineHead;
    public LineRenderer mainLine;
    public Material lineMaterial;
    public MeshRenderer meshRenderer;

    public List<Material> lineMaterials;
    [Range(0, 100)]
    public  float lineLength;

    public  float lineMaxLenght;
    public  float lineSpeed;
    

    [Range(-100, 100)]
    public float GradientHeight01;
    [Range(-100, 100)]
    public float GradientHeight02;



    private void Awake()
    {
        if (Application.isPlaying)
            lineLength = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Application.isPlaying)
            lineLength = Mathf.Lerp(lineLength, lineMaxLenght, lineSpeed);

        if (lineHead == null || mainLine == null)
            return;
        switch (lineAxis)
        {
            case _LineAxis.PX:
                mainLine.SetPosition(1, new Vector3(lineLength, 0, 0));
                lineHead.transform.eulerAngles = new Vector3(0, 0, -90);
                lineMaterial = lineMaterials[2];
                mainLine.material = lineMaterial;
                lineMaterial.SetFloat("_Gradient_Height_01", GradientHeight01);
                lineMaterial.SetFloat("_Gradient_Height_02", GradientHeight02);

                break;
            case _LineAxis.PY:
                mainLine.SetPosition(1, new Vector3(0, lineLength, 0));
                lineHead.transform.eulerAngles = new Vector3(0, 0, 0);
                lineMaterial = lineMaterials[0];
                mainLine.material = lineMaterial;
                lineMaterial.SetFloat("_Gradient_Height_01", GradientHeight01);
                lineMaterial.SetFloat("_Gradient_Height_02", GradientHeight02);
                //  lineMaterial.SetKeyword(YInvertKeyword, false);
                break;
            case _LineAxis.PZ:
                mainLine.SetPosition(1, new Vector3(0, 0, lineLength));
                lineHead.transform.eulerAngles = new Vector3(90, 0, 0);
                lineMaterial = lineMaterials[4];
                mainLine.material = lineMaterial;
                lineMaterial.SetFloat("_Gradient_Height_01", GradientHeight01);
                lineMaterial.SetFloat("_Gradient_Height_02", GradientHeight02);
                break;

            case _LineAxis.NX:
                mainLine.SetPosition(1, new Vector3(-lineLength, 0, 0));
                lineHead.transform.eulerAngles = new Vector3(0, 0, 90);
                lineMaterial = lineMaterials[3];
                mainLine.material = lineMaterial;
                lineMaterial.SetFloat("_Gradient_Height_01", GradientHeight01);
                lineMaterial.SetFloat("_Gradient_Height_02", GradientHeight02);
                break;
            case _LineAxis.NY:
                mainLine.SetPosition(1, new Vector3(0, -lineLength, 0));
                lineHead.transform.eulerAngles = new Vector3(0, 0, 180);
                lineMaterial = lineMaterials[1];
                mainLine.material = lineMaterial;
                lineMaterial.SetFloat("_Gradient_Height_01", GradientHeight01);
                lineMaterial.SetFloat("_Gradient_Height_02", GradientHeight02);
                // lineMaterial.SetKeyword(YInvertKeyword, true);
                break;
            case _LineAxis.NZ:
                mainLine.SetPosition(1, new Vector3(0, 0, -lineLength));
                lineHead.transform.eulerAngles = new Vector3(-90, 0, 0);
                lineMaterial = lineMaterials[5];
                mainLine.material = lineMaterial;
                lineMaterial.SetFloat("_Gradient_Height_01", GradientHeight01);
                lineMaterial.SetFloat("_Gradient_Height_02", GradientHeight02);
                break;

        }
        lineHead.transform.position = mainLine.GetPosition(1);


    }

    public static float Linear(float start, float end, float value)
    {
        return Mathf.Lerp(start, end, value);
    }
  
}
