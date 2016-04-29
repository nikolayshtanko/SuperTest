using UnityEngine;

public class BotAI : MonoBehaviour
{
    public Transform target;
    public Bullet bullet;
    public float agrDistance;
    public BotAnimation botAnim;

    private Transform mTransform;
    private Transform mTargetTransform;
    private Bullet mCurrentBullet;

    void Start()
    {
        mTransform = transform;
        mTargetTransform = target.transform;
    }
	
	void Update()
    {
	    if (Vector3.Distance(mTransform.position, mTargetTransform.position) < agrDistance && mCurrentBullet == null)
        {
            Vector3 pos = mTransform.localPosition;
            pos.y += 1.3f;
            pos.x += 0.4f;
            GameObject go = Instantiate(bullet.gameObject, pos, mTransform.rotation) as GameObject;
            mCurrentBullet = go.GetComponent<Bullet>();
            mCurrentBullet.OnBulletHit += Instance_OnBulletHit;
            mCurrentBullet.SetTarget(target.position);
            botAnim.Attack();
        }
	}

    private void Instance_OnBulletHit(Bullet bullet)
    {
        if (mCurrentBullet == bullet) {
            mCurrentBullet.OnBulletHit -= Instance_OnBulletHit;
            mCurrentBullet = null;
        }
    }
}
