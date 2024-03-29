using Unity.VisualScripting;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] private Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] private Color32 noPackageColor = new Color32(1, 1, 1, 1);

    private SpriteRenderer _sp;
    private bool hasPackage = false;

    [SerializeField] private GameObject packagePrefab;


    private void Start()
    {
        _sp = GetComponent<SpriteRenderer>();
    }



    private void OnTriggerEnter2D(Collider2D collidedObject)
    {
        if (collidedObject.CompareTag("Package") && !hasPackage)
        {
            Debug.Log("Package Pickup");
            Destroy(collidedObject.GameObject(), 1f);
            hasPackage = true;
            _sp.color = hasPackageColor;
        }
        else if (collidedObject.CompareTag("Customer") && hasPackage)
        {
            Debug.Log("Package Delivered");
            _sp.color = noPackageColor;
            hasPackage = false;

            // Destroy(collidedObject.GameObject(), 2f);
            //collidedObject.GetComponent<Transform>().position
        }
    }
}