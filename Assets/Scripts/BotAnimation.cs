using UnityEngine;

public class BotAnimation : MonoBehaviour
{
    private Animation anim;

	void Start()
    {
        anim = GetComponent<Animation>();
    }

    public void Walk()
    {
        anim.Play("Walk");
    }

    public void Attack()
    {
        anim.Play("Attack");
    }

    public void OnAttackComplete()
    {
        Walk();
    }
}
