using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int Score = 0;
    public PennyController pennyController;
    public QuarterController quarterController;
    public GameObject Quarter;
    public GameObject Finger;
    public TMP_Text ScoreTxt;
    public TMP_Text ForceTxt;

    public float ForceIncrement = 100f;
    public bool bAiming = true;

    Animator FingerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        FingerAnimator = Finger.GetComponent<Animator>();
        //Reset();
    }

    // Update is called once per frame
    void Update()
    {

        ForceTxt.text = "Force: " + quarterController.Force.ToString();
        ScoreTxt.text = "Score: " + Score.ToString();

        if (Finger.transform.position.x < -2)
            Finger.transform.position = Quarter.transform.position;

        if (!bAiming)
        {
            //if (Input.GetKeyDown(KeyCode.R)) Reset();
            if (Input.GetKeyDown(KeyCode.Space)) Reset();
            return;
        }

        Score = 0;
        if (Input.GetKeyDown(KeyCode.RightArrow)) quarterController.Force += ForceIncrement;
        if (Input.GetKeyDown(KeyCode.LeftArrow)) quarterController.Force -= ForceIncrement;
        quarterController.Force = Mathf.Clamp(quarterController.Force, 400, 2000);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bAiming = false;
            quarterController.Shoot();
            FingerAnimator.SetBool("reset", false);
            FingerAnimator.SetTrigger("push");
        }
        

    }

    public void Reset()
    {
        FingerAnimator.SetBool("reset", true);
        Finger.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        bAiming = true;
        pennyController.Reset();
        quarterController.Reset();
        Score = 0;
        Finger.transform.position = Quarter.transform.position;

    }
}
