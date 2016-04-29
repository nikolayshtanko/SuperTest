using UnityEngine;

public class Bullet : MonoBehaviour
{
    private bool mIsInit = false;
    private Vector3 mTargetPos;
    private Transform mTransform;

    public delegate void BulletHitEvent(Bullet bullet);
    public event BulletHitEvent OnBulletHit = delegate {};

    void Start()
    {
        mTransform = transform;
        mIsInit = true;

        Vector3 relativePos = mTargetPos - mTransform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        mTransform.rotation = rotation;
    }

	void Update()
    {
        if (mIsInit)
        {
            mTransform.position = Vector3.MoveTowards(mTransform.position, mTargetPos, Time.deltaTime * 10f);
            //Vector3 dir = Vector3.RotateTowards(mTransform.position, mTargetPos, 0f, 0f);
            //mTransform.rotation = Quaternion.LookRotation(dir);
            if (Vector3.Distance(mTransform.position, mTargetPos) < 0.1f) {
                Destroy(gameObject);
            }
        }
	}

    public void SetTarget(Vector3 targetPos)
    {
        mTargetPos = targetPos;
    }

    void OnDestroy()
    {
        OnBulletHit(this);
    }
}
