using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using Holoville.HOTween;

public class GameController : MonoBehaviour
{
    public Camera effectCamera;
    public float coeff = 0.2f;

    private static readonly float timeScaleOrigin = 1f;
    private static readonly float fixetDeltaTimeScaleOrigin = 0.02f;

    private Tweener mTweener;
    private bool cameraAnimating = false;
	
    void Start()
    {
        SlowGame();
    }

	void Update()
    {
        float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        float vertical = CrossPlatformInputManager.GetAxis("Vertical");

        if ((horizontal != 0f || vertical != 0f)) {
            Invoke("NormalGame", 0.01f);
        } else {
            CancelInvoke("NormalGame");
            SlowGame();
        }
    }

    private void SlowGame()
    {
        Time.timeScale = timeScaleOrigin * coeff;
        Time.fixedDeltaTime = fixetDeltaTimeScaleOrigin * coeff;
        //FOV(60f);
    }

    private void NormalGame()
    {
        Time.timeScale = timeScaleOrigin;
        Time.fixedDeltaTime = fixetDeltaTimeScaleOrigin;
        //FOV(70f);
    }

    private void FOV(float to)
    {
        if (cameraAnimating == false)
        {
            cameraAnimating = true;
            mTweener = HOTween.To(effectCamera, 0.2f, new TweenParms().Prop("fieldOfView", to).Ease(EaseType.EaseInCubic).OnComplete(()=> {
                cameraAnimating = false;
            }));
        }
    }
}
