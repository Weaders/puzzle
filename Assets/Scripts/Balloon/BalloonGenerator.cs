using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Balloon {
    public class BalloonGenerator : MonoBehaviour {

        public int balloonCount = 5;

        public BalloonContainer[] balloonPrefabs;

        public void Generate() {

            var rectTransform = (transform as RectTransform);

            var usedSpaces = new List<Rect>();

            for (var i = 0; i < balloonCount; i++) {

                var ballonPrefabIndex = Random.Range(0, balloonPrefabs.Length);
                var ballonCopy = Instantiate(balloonPrefabs[ballonPrefabIndex], transform);

                ballonCopy.transform.localPosition = GenerateBalloonPosition(rectTransform.rect, usedSpaces);

                usedSpaces.Add((ballonCopy.transform as RectTransform).rect);

                ballonCopy.GoUp();

            }

        }

        private Vector3 GenerateBalloonPosition(Rect rect, List<Rect> usedRects) {

            var xPosition = Random.Range(rect.xMin + 10, rect.xMin + rect.width - 10);
            var yPosition = Random.Range(rect.y, rect.y + rect.height);

            if (usedRects.Any(x => x.xMin < xPosition && x.xMax > xPosition && x.yMin < yPosition && x.yMax > yPosition)) {
                return GenerateBalloonPosition(rect, usedRects);
            }

            return new Vector3(xPosition, yPosition, 0);

        }

    }
}
