using System.Collections;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] private GameObject attackHitbox;
    [SerializeField] private float attackSpeed=5;
    public bool isAttacking;

    private void Start()
    {
        attackHitbox.SetActive(false);
    }

    public void DoAttack()
    {
        isAttacking = true;
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        attackHitbox.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        attackHitbox.SetActive(false);
        isAttacking = false;
    }
}
