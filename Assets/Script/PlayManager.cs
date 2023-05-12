using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
    [SerializeField] BallController ballController;
    [SerializeField] CameraController camController;
    [SerializeField] GameObject finishWindow;
    [SerializeField] TMP_Text finishText;
    [SerializeField] TMP_Text shootCountText;

    [SerializeField] int level;


    bool isBallOutside;
    bool isBallTeleporting;
    bool isGoal;
    Vector3 lastBallPosition;

    //Seperto menggunakan unity event (di inspector) tetapi melalui script
    //
    private void OnEnable() {
        ballController.onBallShooted.AddListener(UpdateShootCount);
    }

    private void OnDisable() {
        ballController.onBallShooted.RemoveListener(UpdateShootCount);

    }
    //

    private void Update() {
        // if(ballController.IsMove() && isBallOutside == false){
        //     lasBallPosition = ballController.transform.position;
        // }
        if(ballController.ShootingMode){
            lastBallPosition = ballController.transform.position;
        }
        //0 = klik kiri pada mouse
        //1 = klik kanan pada mouse
        var inputActive = Input.GetMouseButton(0)
            && ballController.IsMove() == false
            && ballController.ShootingMode == false
            && isBallOutside == false;
        
        camController.SetInputActive(inputActive);
    }

    public void OnBallGoalEnter(){

        isGoal = true;
        ballController.enabled=false;

        finishWindow.gameObject.SetActive(true);
        finishText.text = "Finished\n" + "Shoot Count : " + ballController.ShootCount;
        var checkLevelPlayerprefs = PlayerPrefs.GetInt("LevelDone");
        if(checkLevelPlayerprefs<level){
            PlayerPrefs.SetInt("LevelDone",level);
        }

        
    }

    public void OnBallOutside(){
        if(isGoal){
            return;
        }
        if(isBallOutside==false){
        Invoke("TeleportBallLastPosition",2);
            ballController.enabled = false;
            isBallOutside=true;
            isBallTeleporting=true;
        }
    }

    public void TeleportBallLastPosition(){
        TeleportBall(lastBallPosition);
    }

    public void TeleportBall(Vector3 targetPosition){
        var rb = ballController.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        ballController.transform.position = targetPosition;
        rb.isKinematic = false;

        ballController.enabled=true;
        isBallOutside=false;
        isBallTeleporting=false;
    }

    public void UpdateShootCount (int shootCount){
        shootCountText.text = shootCount.ToString();
    }
}
