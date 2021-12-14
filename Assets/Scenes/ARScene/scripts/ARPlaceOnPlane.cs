using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlaceOnPlane : MonoBehaviour
{
    public ARRaycastManager arRaycastMgr;
    public GameObject placeObject;
    public List<ARRaycastHit> hits = new List<ARRaycastHit>();
    public bool click;

    // Start is called before the first frame update
    void Start()
    {
        //생성할 큐브 할당
        //placeObject = GameObject.CreatePrimitive(box);

        //큐브의 크기 설정
        placeObject.transform.localScale = Vector3.one * 0.3f; // * 0.1f

        //AR Raycast Manager 추출
        arRaycastMgr = GetComponent<ARRaycastManager>();

        click = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 0) return;
        Touch touch = Input.GetTouch(0);
        if(touch.phase == TouchPhase.Began && click==false)
        {
            //평면으로 인식한 곳만 레이로 검출
            if(arRaycastMgr.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
            {
                Instantiate(placeObject, hits[0].pose.position, hits[0].pose.rotation);
                print(touch.position);
                click = true;
            }


        }

    }

    private void UpdateCenterObject()
    {
        Vector3 ScreenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));

        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        arRaycastMgr.Raycast(ScreenCenter, hits, TrackableType.Planes);

        Pose placementPose = hits[0].pose;
        placeObject.SetActive(true);
        placeObject.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);

        /*
        if (hits.Count > 0)
        {
            Pose placementPose = hits[0].pose;
            placeObject.SetActive(true);
            placeObject.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else
        {
            placeObject.SetActive(false);
        }
        */
        

    }

    public void disappearObject()
    {
        placeObject.SetActive(false);
    }
}
