using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{

    [SerializeField] GameObject prefab_bullet;
    [SerializeField] GameObject objectToRotate;

    [SerializeField] GameObject cursor;
    float cooldown = 0.5f;
    bool shootCooldown = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShootBullet());

        //HIDE MOUSE
        //Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //GET MOUSE POSITION
        Vector3 mouseScreen = Input.mousePosition;
		Vector3 mouse = Camera.main.ScreenToWorldPoint(mouseScreen);
        objectToRotate.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mouse.y - objectToRotate.transform.position.y, mouse.x - objectToRotate.transform.position.x) * Mathf.Rad2Deg - 90);

        //SHOOT
        if (Input.GetMouseButtonDown(0) && shootCooldown) {
            shootCooldown = false;
            Debug.Log("E pressed");
            Instantiate(prefab_bullet, objectToRotate.transform.position, objectToRotate.transform.rotation,transform);
            StartCoroutine(ShootBullet());
        }

        //CURSOR TO MOUSE POS
        cursor.transform.position = new Vector2(mouse.x,mouse.y);

    }
    IEnumerator ShootBullet() {
        yield return new WaitForSecondsRealtime(cooldown);
        shootCooldown = true;
    }
    
}
