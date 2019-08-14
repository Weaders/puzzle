using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.Task {

    [RequireComponent(typeof(CanvasGroup))]
    public class TaskCtrl : MonoBehaviour {

        public TaskBtn[] numbers;
        public TaskBtn clearNumber;

        public Text firstNumber;
        public Text secondNumber;

        public InputField result;

        public UnityEvent onSuccess = new UnityEvent();

        private void Start() {

            Generate();

            foreach (var taskBtn in numbers) {

                taskBtn.GetComponent<Button>().onClick.AddListener(() => {
                    BtnCalcClick(taskBtn.number);
                });

                taskBtn.EnableByHover();

            }

            clearNumber.GetComponent<Button>().onClick.AddListener(() => {
                BtnClearClick();
            });

            clearNumber.DisableByHover();

        }

        public void BtnCalcClick(int number) {

            result.text += number;

            if (result.text.Length == 2) {

                foreach (var numberBtn in numbers) {
                    numberBtn.DisableByHover();
                }

            }

            CheckTask();
            clearNumber.EnableByHover();

        }

        public void BtnClearClick() {

            result.text = "";

            foreach (var numberBtn in numbers) {
                numberBtn.EnableByHover();
            }

            clearNumber.DisableByHover();

        }

        public void CheckTask() {

            var firstVal = int.Parse(firstNumber.text);
            var secondVal = int.Parse(secondNumber.text);

            if (string.IsNullOrWhiteSpace(result.text)) {
                return;
            }

            var resultVal = int.Parse(result.text);

            if (resultVal == firstVal * secondVal) {

                onSuccess.Invoke();
                Cancel();

            }

        }

        public void Cancel() {

            var cg = GetComponent<CanvasGroup>();
            cg.alpha = 0;
            cg.blocksRaycasts = false;

        }

        public void Show() {

            Generate();

            var cg = GetComponent<CanvasGroup>();
            cg.alpha = 1;
            cg.blocksRaycasts = true;

        }

        public void Generate() {

            var firstVal = Random.Range(1, 10);
            var secondVal = Random.Range(1, 10);

            firstNumber.text = firstVal.ToString();
            secondNumber.text = secondVal.ToString();

            result.text = "";

        }

    }
}
