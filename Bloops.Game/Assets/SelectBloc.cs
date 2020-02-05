using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectBloc : MonoBehaviour
{


    public class TakePhoto : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("ON click ici");
            throw new System.NotImplementedException();
        }

        void OnClick()
        {
            Debug.Log("ON click la");
//            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) {
                Debug.Log("ON click ici");

                if (hit.transform.name == "Cube")
                {
                    Debug.Log("CUUUUUBBE");
                }
            }
        }
    }

    void PrintName()
    {
        /*Do whatever here as per your need*/
        Debug.Log("ON click ici");
    }
}
