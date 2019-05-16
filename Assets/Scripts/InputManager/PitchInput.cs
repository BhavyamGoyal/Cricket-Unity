using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class PitchInput : MonoBehaviour,IDragHandler
{
    public GameObject Marker;
    // Start is called before the first frame update
    void Start()
    {
    }
    public Vector3 GetMarkerPosition()
    {
        return Marker.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMouseDown()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 markerPos = hit.point; //objectHit.position;
            markerPos.y = 0.16f;
            Marker.transform.position = markerPos;

            // Do something with the object that was hit by the raycast.
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("dragging");
        Debug.Log("dragging");
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 markerPos = hit.point; //objectHit.position;
            markerPos.y = 0.16f;
            Marker.transform.position = markerPos;

            // Do something with the object that was hit by the raycast.
        }
    }
}
