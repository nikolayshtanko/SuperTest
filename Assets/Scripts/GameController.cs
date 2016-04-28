using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameController : MonoBehaviour
{
    public float coeff = 0.2f;
    private static readonly float timeScaleOrigin = 1f;
    private static readonly float fixetDeltaTimeScaleOrigin = 0.02f;
	
	void Update()
    {
        // Read input
        float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        float vertical = CrossPlatformInputManager.GetAxis("Vertical");

        if (horizontal != 0f || vertical != 0f) {
            Invoke("NormalGame", 0.02f);
        } else {
            CancelInvoke("NormalGame");
            SlowGame();
        }
    }

    private void SlowGame()
    {
        Time.timeScale = timeScaleOrigin * coeff;
        Time.fixedDeltaTime = fixetDeltaTimeScaleOrigin * coeff;
    }

    private void NormalGame()
    {
        Time.timeScale = timeScaleOrigin;
        Time.fixedDeltaTime = fixetDeltaTimeScaleOrigin;
    }
}
