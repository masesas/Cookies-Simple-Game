using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookies : MonoBehaviour
{

    public GameObject cookiesObj;
    private bool isDrag;
    private bool isMatch;
    private float posX, posY;
    private Vector3 resetPos;
   
    void Start()
    {
        resetPos = this.transform.localPosition;
    }

    void Update()
    {
        if(isMatch == false){
            if(isDrag){
                    Vector3 mousePos;
                    mousePos = Input.mousePosition;
                    mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            
                    this.gameObject.transform.localPosition = new Vector3(
                        mousePos.x - posX, 
                        mousePos.y - posY, 
                        this.gameObject.transform.localPosition.z);
            }
        }
      
    }

     private void OnMouseDown(){
       if(Input.GetMouseButtonDown(0)){
           Vector3 mousePos;
           mousePos = Input.mousePosition;
           mousePos = Camera.main.ScreenToWorldPoint(mousePos);
           
           posX = mousePos.x - this.transform.localPosition.x;
           posY = mousePos.y - this.transform.localPosition.y;

           isDrag = true;
       }
    }
    private void OnMouseUp(){
       isDrag = false;

       if(Mathf.Abs(this.transform.localPosition.x - cookiesObj.transform.localPosition.x) <= 0.5f && 
            Mathf.Abs(this.transform.localPosition.y -cookiesObj.transform.localPosition.y) <= 0.5f){
                this.transform.localPosition = new Vector3(
                    cookiesObj.transform.position.x,
                    cookiesObj.transform.position.y,
                    cookiesObj.transform.position.z );
                    isMatch = true;
       }else{
           this.transform.localPosition = new Vector3(
                resetPos.x,
                resetPos.y,
                resetPos.z
           );
       }
    }
}
