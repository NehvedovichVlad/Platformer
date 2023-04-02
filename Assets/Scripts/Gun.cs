using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _spawn;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _shotPeriod = 0.1f;
    [SerializeField] private AudioSource _shotSound;
    [SerializeField] private GameObject _flash;

    private float _timer;

    private void Start()
    {
        HideFlash();
    }
    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _shotPeriod && Input.GetMouseButton(0))
        {
            _timer = 0f;
            CreateBullet();
        }
    }

    private void CreateBullet()
    {
        Bullet newBullet = Instantiate(_bulletPrefab, _spawn.position, _spawn.rotation);
        newBullet.GetComponent<Rigidbody>().velocity = _spawn.forward * _bulletSpeed;
        _shotSound.Play();
        _flash.SetActive(true);

        Invoke(nameof(HideFlash), 0.12f);
    }

    private void HideFlash()
    {
        _flash.SetActive(false);
    }
}
