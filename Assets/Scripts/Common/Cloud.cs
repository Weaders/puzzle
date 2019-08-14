using UnityEngine;
using UnityEngine.UI;

public class Cloud : MonoBehaviour {

    public float speed;

    public bool isDebug = false;

    private Vector2 diff;

    private void Awake() {
        var rectTransform = (transform as RectTransform);
        diff = rectTransform.offsetMax - rectTransform.offsetMin;
    }

    private void Start() {

        var mainCanvas = GameObject
            .FindGameObjectWithTag("MainCanvas");

        diff.x *= mainCanvas.transform.lossyScale.x / 2f;

    }

    void Update() {

        var rectTransform = (transform as RectTransform);

        transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));

        if (rectTransform.position.x - diff.x > Screen.width) {
            rectTransform.position = new Vector3(-diff.x - 10, transform.position.y, transform.position.z);
        }

    }
}
