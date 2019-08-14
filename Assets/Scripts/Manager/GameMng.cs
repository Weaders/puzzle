using Assets.Scripts.Balloon;
using Game.Common;
using Game.User;
using Imgs;
using System.Collections.Generic;
using System.Linq;
using Game.GameScripts;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Manager {

    public class GameMng : MonoBehaviour {

        private PlaceForImg[] placesForImgs;
        private ImgPart[] imgParts;

        public CanvasGroup gameCanvas;
        public CanvasGroup gjPanel;

        public Button btnBackFinal;

        public AudioSource audioSource;

        public BalloonGenerator balloonGenerator;

        private void Awake() {

            SceneData.Clear();

            placesForImgs = FindObjectsOfType<PlaceForImg>();
            imgParts = FindObjectsOfType<ImgPart>();

            btnBackFinal.gameObject.SetActive(false);

        }


        private void Start() {

            foreach (var place in placesForImgs) {
                place.onPlaced.AddListener(OnPlaced);
            }

            foreach (var imgPart in imgParts) {
                imgPart.onMiss.AddListener(OnMiss);
            }

            var musicObj = GameObject
                .FindGameObjectWithTag("Music");

            audioSource = musicObj?.GetComponent<AudioSource>() ?? gameObject.AddComponent<AudioSource>();

        }
        
        private void Update() {

            if (Input.GetKeyUp(KeyCode.Escape)) {
                
                var toMenu = GameObject.FindObjectOfType<ToMenu>();
                toMenu.ToMenuWithLevel();
                
            }

        }

        private void OnPlaced() {

            if (placesForImgs.All(pl => pl.isPlaced)) {

                btnBackFinal.gameObject.SetActive(true);

                audioSource.PlayOneShot(Resources.Load<AudioClip>("AudioClips/SuccessPuzzle"));

                balloonGenerator.Generate();

            } else {
                audioSource.PlayOneShot(Resources.Load<AudioClip>("AudioClips/SuccessPlace"));
            }

        }

        private void OnMiss() {
            audioSource.PlayOneShot(Resources.Load<AudioClip>("AudioClips/WrongInsert"));
        }

    }

}
