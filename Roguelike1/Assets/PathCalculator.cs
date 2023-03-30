using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathCalculator : MonoBehaviour
{
    public Vector3Int PathCalculation(Vector3Int playerPosition, Vector3Int EnemyPosition)
    {
        int deltaX = CalculateTheDifferenceBetweenDistance(playerPosition.x, EnemyPosition.x);
        int deltaZ = CalculateTheDifferenceBetweenDistance(playerPosition.z, EnemyPosition.z);
        Debug.Log("playerPosition.z = " + playerPosition.z);
        Debug.Log("playerPosition.x = " + playerPosition.x);


        bool useXAxis = CheckWhichValueIsHigher(deltaX, deltaZ);
        Debug.Log("useXAxis = " + useXAxis);

        Vector3Int nextStep;
        nextStep = NextStep(useXAxis, playerPosition, EnemyPosition);

        return nextStep;
    }

    private int CalculateTheDifferenceBetweenDistance(int Value1, int Value2)
    {
        int deltaValue;
        if(Value1 > Value2)
        {
            deltaValue = Value1 - Value2;
        }
        else
        {
            deltaValue = Value2 - Value1;
        }

        return deltaValue;
    }
    private bool CheckWhichValueIsHigher(int Value1, int Value2)
    {
        if (Value1 > Value2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private Vector3Int NextStep(bool useXAxis, Vector3Int playerPosition, Vector3Int EnemyPosition)
    {
        Vector3Int nextStep;
        bool PlayerPosition;

        // als de x-as kleiner is 
        if (useXAxis)
        {
            PlayerPosition = CheckWhichValueIsHigher(playerPosition.x, EnemyPosition.x);
            
            if(PlayerPosition)
            {
                EnemyPosition.x = EnemyPosition.x + 1;
            }
            else
            {
                EnemyPosition.x = EnemyPosition.x - 1;
            }
        }
        else
        {
            PlayerPosition = CheckWhichValueIsHigher(playerPosition.z, EnemyPosition.z);

            if (PlayerPosition)
            {
                EnemyPosition.z = EnemyPosition.z + 1;
            }
            else
            {
                EnemyPosition.z = EnemyPosition.z - 1;
            }
        }

        nextStep = EnemyPosition;
        //nextStep = new Vector3Int(EnemyPosition.x, EnemyPosition.y, EnemyPosition.z);
        Debug.Log("Next Postion = " + nextStep);

        return nextStep;
    }
}


