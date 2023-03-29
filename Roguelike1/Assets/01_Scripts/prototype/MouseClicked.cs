using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseClicked : MonoBehaviour
{
    private Camera camera;

    private void Start()
    {
        camera = Camera.main;
    }
    public void CheckIfMouseClickIsEnemy()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        Ray ray = camera.ScreenPointToRay(mousePos);

        if(Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            Enemy Currentenemy = hitInfo.collider.gameObject.GetComponent<Enemy>();
            
            if (Currentenemy != null)
            {
                Unit CurrentEnemyUnit = Currentenemy.GetComponent<Unit>();
                Debug.Log(BattleManager.Instance);

                Debug.Log("we have hit an Enemy!");
                BattleManager.Instance.CurrentEnemy(CurrentEnemyUnit);

            }
            else
            {
                Debug.Log("We haven't hit an Enemy");
            }
        }
    }

    private void DoDamage()
    {

    }



}
