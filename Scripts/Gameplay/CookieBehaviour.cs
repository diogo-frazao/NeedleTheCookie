using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieBehaviour : MonoBehaviour
{
    [SerializeField] private int movementType;

    private float cookieDefaultRotationSpeed = 100f;
    private float SecondLevelRotationSpeedVariant = 50f;
    private float FourthLevelRotationSpeedVariant = 75f;
    private float FifthLevelRotationSpeedVariant = 0f;

    private float thirdLevelTurnSpeed = 0.75f;
    private float forthLevelTurnSpeed = 1f;
    private float fifthLevelTurnSpeed = 1f;

    private float targetAngle;
    private int angleHitCounter = 0;
    private bool isLookingForAngle = false;

    private void Start() 
    {
        if(movementType == 3) targetAngle = Random.Range(-180f, 180f);
        if(movementType == 4) isLookingForAngle = true;
        if(movementType == 5) isLookingForAngle = true;
    }
    
    private void Update() 
    {
        switch (movementType)
        {
            case 1:
                StartMovementTypeOne();
                break;
            case 2:
                StartMovementTypeTwo();
                break;
            case 3:
                StartMovementTypeThree();
                break;
            case 4:
                StartMovementTypeFour();
                break;
            case 5:
                StartMovementTypeFive();
                break;
        }
    }

    private void StartMovementTypeOne() 
    {
        transform.Rotate(new Vector3(0f, 0f, -cookieDefaultRotationSpeed) * Time.deltaTime);
    }

    private void StartMovementTypeTwo()
    {
        transform.Rotate(new Vector3(0f, 0f, +cookieDefaultRotationSpeed + SecondLevelRotationSpeedVariant) * Time.deltaTime);
    }
        
    private void StartMovementTypeThree()
    {      
        transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (0, 0, targetAngle), thirdLevelTurnSpeed * Time.deltaTime);

        if(Quaternion.Angle(transform.rotation, Quaternion.Euler (0, 0, targetAngle)) <= 1f) 
        {
            targetAngle = Random.Range(-180f, 180f);
        }
    }

    private void StartMovementTypeFour()
    {
        if(isLookingForAngle)
        {
            transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (0, 0, targetAngle), forthLevelTurnSpeed * Time.deltaTime);
        }

        if(!isLookingForAngle)
        {
             transform.Rotate(new Vector3(0f, 0f, -cookieDefaultRotationSpeed - FourthLevelRotationSpeedVariant) * Time.deltaTime);
             
        }

        if(Quaternion.Angle(transform.rotation, Quaternion.Euler (0, 0, targetAngle)) <= 2.5f && isLookingForAngle) 
        {
            
            if(angleHitCounter >= 10)
            {
                isLookingForAngle = false;
                Invoke("ResetFourthMovement", 5.0f);
            }
            else
            {
                targetAngle = Random.Range(-180f, 180f);
                angleHitCounter ++;
                Debug.Log(angleHitCounter);
            }
        }        
    }

    private void ResetFourthMovement()
    {
        isLookingForAngle = true;
        angleHitCounter = 0;
    }

    private void StartMovementTypeFive()
    {
         if(isLookingForAngle)
        {
            transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (0, 0, targetAngle), fifthLevelTurnSpeed * Time.deltaTime);
        }

        if(!isLookingForAngle)
        {
             transform.Rotate(new Vector3(0f, 0f, cookieDefaultRotationSpeed + FifthLevelRotationSpeedVariant) * Time.deltaTime);
             
        }

        if(Quaternion.Angle(transform.rotation, Quaternion.Euler (0, 0, targetAngle)) <= 5f && isLookingForAngle) 
        {
            
            if(angleHitCounter >= 10)
            {
                isLookingForAngle = false;
                Invoke("ResetFifthMovement", 10.0f);
            }
            else
            {
                targetAngle = Random.Range(-180f, 180f);
                angleHitCounter ++;
                Debug.Log(angleHitCounter);
            }
        }
    }

    private void ResetFifthMovement()
    {
        isLookingForAngle = true;
        angleHitCounter = 0;
        fifthLevelTurnSpeed += 0.10f;
        FifthLevelRotationSpeedVariant = Random.Range(0f, 100f);
        cookieDefaultRotationSpeed *= -1;
        FifthLevelRotationSpeedVariant *= -1;
    }

}
