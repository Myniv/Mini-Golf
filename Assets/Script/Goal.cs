using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Goal : MonoBehaviour
{
    public UnityEvent OnBallGoalEnter = new UnityEvent();

    //Jika Tempat Goal bersentuhan dengan bola, lebih bagus memakai OnColliderEnter dengan trigger diuncheklist pada tempat goal.
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Ball"))
        {
            OnBallGoalEnter.Invoke();
        }

    }
}
