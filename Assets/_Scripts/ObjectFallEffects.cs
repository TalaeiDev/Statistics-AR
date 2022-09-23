using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFallEffects : MonoBehaviour
{
    public float MoveSpeed;
    public iTween.EaseType ease;
    public GameObject currentObject;
    public Vector3 transformObject;

    // Start is called before the first frame update
    void Start()
    {
      //  FallEffect();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FallEffect()
    {
        iTween.MoveTo(currentObject, iTween.Hash("position",transformObject,"time",MoveSpeed,"easeType",ease));
    }
}
