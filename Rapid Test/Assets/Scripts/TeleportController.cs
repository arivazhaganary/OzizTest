using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TeleportController : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI m_Object;
    [SerializeField] TextMeshProUGUI mTxt;
    [SerializeField] Button jumpInButton;
    [SerializeField] Button zoomInButton;
    [SerializeField] Button zoomOutButton;
    [SerializeField] Camera cam3D;
    [SerializeField] Camera cam2D;
    [SerializeField] GameObject player;
    Vector3 mousePosition;
    Vector3 clickedPos;

    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            mTxt.gameObject.SetActive(false);
            cam3D.gameObject.SetActive(false);
            cam2D.gameObject.SetActive(true);
            zoomInButton.gameObject.SetActive(true);
            zoomOutButton.gameObject.SetActive(true);

        }
 
        if (cam2D.gameObject.activeSelf)
        {

            RaycastHit hit;


            m_Object.gameObject.transform.position = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {

                m_Object.text = Mathf.FloorToInt(hit.point.x) + "," + Mathf.FloorToInt(hit.point.z);
                mousePosition = hit.point;

                if (Input.GetMouseButtonDown(1))
                {
                    jumpInButton.gameObject.SetActive(true);
                    clickedPos = hit.point;
                    Vector2 mousePosition = Input.mousePosition;
                    jumpInButton.gameObject.GetComponent<RectTransform>().anchoredPosition = Vector2.Scale(Camera.main.ScreenToViewportPoint(mousePosition), new Vector2(Screen.width, Screen.height));
                }
               
            }
            else
            {
                m_Object.text = "";
            }
        }

    }
    public void Teleport() 
    {
        Debug.Log(clickedPos);
        cam3D.gameObject.SetActive(true);
        cam2D.gameObject.SetActive(false);
        var tempY = cam3D.transform.position.y;
        cam3D.gameObject.transform.position = new Vector3(clickedPos.x, tempY, clickedPos.z);
        player.transform.position = new Vector3(clickedPos.x, tempY, clickedPos.z);
        zoomInButton.gameObject.SetActive(false);
        zoomOutButton.gameObject.SetActive(false);
        jumpInButton.gameObject.SetActive(false);
        m_Object.text = "";
        mTxt.gameObject.SetActive(true);
    }
    public void ZoomIn() 
    {
      
        if (cam2D.orthographicSize > 5)
        {
            cam2D.orthographicSize -= 5;
        }
    }
    public void ZoomOut() 
    {
        if (cam2D.orthographicSize < 20)
        {
            cam2D.orthographicSize += 5;
        }
    }
}
