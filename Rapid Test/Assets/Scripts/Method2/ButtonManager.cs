using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Button jumpIn;
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private GameObject player;
    float offsetX = 900f, offsetY = 520f;
    string mainCordinates;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && CameraManager.instance.isMapOn)
        {
            RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
            try
            {
                if (rayHit.collider.tag == "Tile")
                {
                    var tile = rayHit.transform.gameObject;
                    Debug.Log(tile.GetComponent<Tile>().transform.GetChild(1).GetComponent<TextMeshPro>().text);
                    mainCordinates = tile.GetComponent<Tile>().transform.GetChild(1).GetComponent<TextMeshPro>().text;

                    Vector2 mousePosition = Input.mousePosition;
                    Debug.Log(mousePosition);
                    jumpIn.gameObject.SetActive(true);
                    jumpIn.gameObject.GetComponent<RectTransform>().anchoredPosition = Vector2.Scale(Camera.main.ScreenToViewportPoint(mousePosition), new Vector2(Screen.width, Screen.height));
                   jumpIn.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(jumpIn.gameObject.GetComponent<RectTransform>().anchoredPosition.x - offsetX, jumpIn.gameObject.GetComponent<RectTransform>().anchoredPosition.y - offsetY, 0f);
                }
            }
            catch { }

        }
        //float scroll = Input.GetAxis("Mouse ScrollWheel");
        //tileParent.transform.position = new Vector3(tileParent.transform.position.x, tileParent.transform.position.y, Mathf.Clamp(tileParent.transform.position.z, 5f, 10f));
        float scrollWheelDelta = Input.GetAxis("Mouse ScrollWheel");
        if (scrollWheelDelta != 0)
        {

            Vector3 position = rectTransform.position;
            position.z += scrollWheelDelta * 1f;
            rectTransform.position = position;
        }

    }
    [ContextMenu("jump")]
    public void Jump() 
    {
        Camera.main.cullingMask = CameraManager.instance.oldCullingMask;
        CameraManager.instance.isMapOn = false;
        CameraManager.instance.mouseLook.enabled = true;
        string[] pointList = mainCordinates.Split(",");
        var y = player.transform.position.y;
        player.transform.position = new Vector3(int.Parse(pointList[0]),y,int.Parse( pointList[1]));
        jumpIn.gameObject.SetActive(false);
        Camera.main.transform.localPosition = new Vector3(0, 1, 0);
        player.GetComponent<PlayerController>().enabled = true;
    }
}
