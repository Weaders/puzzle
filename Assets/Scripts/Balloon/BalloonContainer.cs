using Assets.Scripts.Balloon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BalloonContainer : MonoBehaviour, IPointerClickHandler
{
    public float speed = 1000f;

    public Balloon balloon;

    [SerializeField]
    private bool isGoUp;

    private void Start() {
        balloon.onDestroyEvent.AddListener(() => Destroy(gameObject));
    }

    public void OnPointerClick(PointerEventData eventData) => balloon.Boom(Random.Range(1, 6));

    public void GoUp() => isGoUp = true;

    private void Update() {

        if (isGoUp) {
            transform.Translate(0, speed * Time.deltaTime, 0);
        }

    }
}
