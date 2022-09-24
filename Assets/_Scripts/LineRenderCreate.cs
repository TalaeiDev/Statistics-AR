using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRenderCreate : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public LineRenderer curreRender;
    public List<Vector3> postions;
    public int linePostion;

    public float lineSpeed;

    private Vector3 currentPos;
    private Vector3 posupdate;

    public bool drawline;
    private void Awake()
    {
      // for (int i = 0; i < lineRenderer.positionCount; i++)
      // {
      //     postions.Add(lineRenderer.GetPosition(i));
      // }
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(postions.Count);
        drawline = true;

        lineRenderer.positionCount = 3;


    }

    // Update is called once per frame
    void Update()
    {
        if(drawline == true)
        {
            for (int i = 0; i < postions.Count; i++)
            {
                
                //lineRenderer.positionCount = lineRenderer.positionCount + 1;
               
                currentPos = lineRenderer.GetPosition(i);

                currentPos = Vector3.Lerp(currentPos, postions[i], 0.01f);
                lineRenderer.SetPosition(i + 1, currentPos);

               // if (lineRenderer.GetPosition(i + 1) != postions[i])
                    
                // lineRenderer.SetPosition(i + 1, postions[i]);
            }

            drawline = false;
        }

      //for (int i = 0; i < postions.Count; i++)
      //    {
      //       Debug.Log("X");
      //      // lineRenderer.positionCount = lineRenderer.positionCount +1;
      //       //lineRenderer.SetPosition(i + 1, postions[i]);
      //    }
      //curreRender.SetVertexCount(postions.Count);

            // for (var i: int = 0; i < pathNodes.length; i++){
            //     curreRender.SetPosition(i, pathNodes[i].transform.position);
            // }

            // for (int i = 0; i < postions.Count; i++)
            // {
            //     currentPos = postions[i];
            //
            //     if (postions[i - 1].y < 0)
            //         posupdate = Vector3.zero;
            //     else
            //         posupdate = postions[i - 1];
            //
            //
            //     curreRender.SetVertexCount(curreRender.positionCount + 1);
            //     //curreRender.SetPositions(postions);
            //     posupdate = Vector3.Lerp(posupdate, currentPos, 0.001f);
            //     if (curreRender.GetPosition(i) != currentPos)
            //     {
            //         curreRender.SetPosition(i, posupdate);
            //     }
            // 
            //     //curreRender.SetPosition(i, postions[i]);
            // }
    }
}
