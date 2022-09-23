using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : MonoBehaviour
{

    public bool fallEffect;
    public bool rotate;
    public bool scale;
    public bool move;
    public ObjectFallEffects fallManager;

    public _objectPlacementMode objectPlacementMode;
    public Material detectionPlaneMat;

    public enum _objectPlacementMode { changePosition, instantiate };

    // Start is called before the first frame update
    void Start()
    {
      //  detectionPlaneMat.SetColor("_TexTintColor", new Color(1,1,1,0.6f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
