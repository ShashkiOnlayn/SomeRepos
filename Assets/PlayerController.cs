using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private GameObject _slash;
    [SerializeField] private Transform _spawnSlash;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            _animator.SetTrigger("Attack");
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(0.9f);
        GameObject newSpawn = Instantiate(_slash, _spawnSlash.position, Quaternion.Euler(0, 0, 0));
        yield return new WaitForSeconds(1);
        Destroy(newSpawn);
    }
}
