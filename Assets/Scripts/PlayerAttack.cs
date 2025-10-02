using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private Sprite idleSprite;
    [SerializeField]
    private Sprite attackSprite;
    [SerializeField]
    private GameObject yarnAttackPrefab;
    private SpriteRenderer spriteRenderer;
    public float attackDuration = 0.2f;
    private Vector3 originalScale;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnAttack()
    {
        StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        spriteRenderer.sprite = attackSprite;
        transform.localScale = new Vector3(1.75f, 1.75f, 1);
        GameObject newAttack = Instantiate(yarnAttackPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(attackDuration);
        spriteRenderer.sprite = idleSprite;
        transform.localScale = originalScale;
    }
}
