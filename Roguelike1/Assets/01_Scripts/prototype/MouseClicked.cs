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
        Debug.Log("clicked");
        Vector3 mousePos = Mouse.current.position.ReadValue();
        Ray ray = camera.ScreenPointToRay(mousePos);

        if(Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            Enemy Currentenemy = hitInfo.collider.gameObject.GetComponent<Enemy>();
            
            if (Currentenemy != null)
            {
                Unit CurrentEnemyUnit = Currentenemy.GetComponent<Unit>();

                BattleManager.Instance.CurrentEnemy(CurrentEnemyUnit);

            }
        }
    }

    private void DoDamage()
    {

    }



}
