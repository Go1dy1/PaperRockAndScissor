using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Card : MonoBehaviour
{


    private void Update()
    {
        if(Input.GetMouseButton(0)){
            transform.DOMove(GetMousePosition(),1);
        }
    }
public  Vector3 GetMousePosition()
{
    Camera MainCamera= Camera.main;
      Ray ray =MainCamera.ScreenPointToRay(Input.mousePosition);
       Plane plane = new Plane(Vector3.up,new Vector3 (0,0.5f,0));
       plane.Raycast(ray,out float enter);
        
       return ray.GetPoint(enter);
  }
public void Place(){

}
}
