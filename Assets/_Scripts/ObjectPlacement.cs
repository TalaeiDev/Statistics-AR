using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System;

[RequireComponent(typeof(ARRaycastManager))]
public class ObjectPlacement : MonoBehaviour
{
    public GameObject appManager;
    [SerializeField]
    GameObject _placedObject;

    public GameObject placedObject
    {
        get { return _placedObject; }
        set { _placedObject = value; }
    }

    private int placementMode;
    private bool fallMode;
    private ObjectFallEffects _fallManager;
    public Material _featurePlaneMat;
   
    public GameObject spawnedObject { get; private set; }


    public static event Action onPlacedObject;

    ARRaycastManager m_RaycastManager;

    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

    private bool objectExist;
    private float objectY;

    void Awake()
    {
        _featurePlaneMat = appManager.GetComponent<AppManager>().detectionPlaneMat;
        fallMode = appManager.GetComponent<AppManager>().fallEffect;
        _fallManager = appManager.GetComponent<AppManager>().fallManager;
       // _featurePlaneMat.SetColor("_TexTintColor", new Color(1, 1, 1, 0f));
        switch (appManager.GetComponent<AppManager>().objectPlacementMode)
        {
            case AppManager._objectPlacementMode.changePosition:
                placementMode = 0;
            break;

            case AppManager._objectPlacementMode.instantiate:
                 placementMode = 1;
            break;
        }

        m_RaycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {

       

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (m_RaycastManager.Raycast(touch.position, s_Hits, TrackableType.PlaneWithinPolygon))
                {
                    Pose hitPose = s_Hits[0].pose;
                    _featurePlaneMat.SetColor("_TexTintColor", new Color(1, 1, 1, 0f));

                    if (placementMode == 0)
                    {
                        if (spawnedObject == null)
                        {
                            if (fallMode == true)
                            {
                                spawnedObject = Instantiate(_placedObject,new Vector3( hitPose.position.x, hitPose.position.y+ 0.3f, hitPose.position.z), hitPose.rotation);
                                 
                                _fallManager.currentObject = spawnedObject;
                                _fallManager.transformObject = hitPose.position;
                                _fallManager.FallEffect();

                                if(appManager.GetComponent<AppManager>().rotate == true)
                                {
                                    spawnedObject.GetComponent<Lean.Touch.LeanTwistRotateAxis>().enabled = true;
                                }
                                if (appManager.GetComponent<AppManager>().scale == true)
                                {
                                    spawnedObject.GetComponent<Lean.Touch.LeanPinchScale>().enabled = true;
                                }
                                if (appManager.GetComponent<AppManager>().move == true)
                                {
                                    spawnedObject.GetComponent<Lean.Touch.LeanDragTranslate>().enabled = true;
                                }
                            }

                            else
                            {
                                spawnedObject = Instantiate(_placedObject, hitPose.position, hitPose.rotation);
                           
                            }
                           
                        }

                        else
                        {
                            if (fallMode == true)
                            {
                                Debug.Log("Do Nothing");
                                if (appManager.GetComponent<AppManager>().move == false)
                                {
                                    spawnedObject.transform.position = new Vector3(hitPose.position.x, hitPose.position.y + 0.3f, hitPose.position.z);
                                    _fallManager.currentObject = spawnedObject;
                                    _fallManager.transformObject = hitPose.position;
                                    _fallManager.FallEffect();

                                }
                               
                            }

                            else
                            {
                                Debug.Log("Do Nothing");
                                if (appManager.GetComponent<AppManager>().move == true)
                                {
                                    spawnedObject.transform.position = hitPose.position;
                                }
                                   
                            }
                            
                          //  spawnedObject.transform.localRotation = hitPose.rotation;
                        }

                      
                    }

                    else if(placementMode == 1)
                    {
                        spawnedObject = Instantiate(_placedObject, hitPose.position, hitPose.rotation);
                    }            

                    if (onPlacedObject != null)
                    {
                        onPlacedObject();
                    }
                }
            }
        }
    }
}

