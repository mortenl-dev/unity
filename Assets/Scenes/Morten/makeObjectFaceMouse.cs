using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeObjectFaceMouse : MonoBehaviour
{

    [SerializeField] GameObject prefab_bullet;
    [SerializeField] GameObject objectToRotate;

    float cooldown = 0.5f;
    bool shootCooldown = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShootBullet());
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseScreen = Input.mousePosition;
		Vector3 mouse = Camera.main.ScreenToWorldPoint(mouseScreen);
        objectToRotate.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x) * Mathf.Rad2Deg - 90);
        if (Input.GetKeyDown(KeyCode.E) && shootCooldown) {
            shootCooldown = false;
            Debug.Log("E pressed");
            Instantiate(prefab_bullet, objectToRotate.transform.position, objectToRotate.transform.rotation);
            StartCoroutine(ShootBullet());
        }
    }
    IEnumerator ShootBullet() {
        yield return new WaitForSecondsRealtime(cooldown);
        shootCooldown = true;
    }
    
}
