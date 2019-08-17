using Game.Common;
using System;
using UnityEngine;
using UnityEngine.Purchasing;

namespace Assets.Scripts.IAP {
    public class StoreMng : MonoBehaviour, IStoreListener {

        private static IStoreController _storeCtrl;
        private static IExtensionProvider _extensionPrvdr;

        public readonly static string productIdFullAccess = "full_access";
        public readonly static string productIdLevel1Access = "level1";

        private readonly static string productFullAccessGoogle = "full_access";
        private readonly static string productLevel1AccessGoogle = "level1";
        private readonly static string productIdLevel1AccessApple = "com.apple.level1";
        private readonly static string productFullAccessApple = "com.apple.full_access";

        private void Start() {

            if (_storeCtrl == null) {
                InitializePurchasing();
            }

        }

        public void InitializePurchasing() {

            if (IsInitialized()) {
                return;
            }

            // Create a builder, first passing in a suite of Unity provided stores.
            var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

            builder.AddProduct(productIdFullAccess, ProductType.NonConsumable, new IDs {
                { productFullAccessApple, AppleAppStore.Name },
                { productFullAccessGoogle, GooglePlay.Name }
            })
            .AddProduct(productIdLevel1Access, ProductType.NonConsumable, new IDs {
                { productIdLevel1AccessApple, AppleAppStore.Name },
                { productLevel1AccessGoogle, GooglePlay.Name }

            });

            UnityPurchasing.Initialize(this, builder);

        }

        private bool IsInitialized() {
            return _storeCtrl != null && _extensionPrvdr != null;
        }

        public void BuyUpgradeForFullVersion() {
            BuyProductID(productIdFullAccess);
        }

        void BuyProductID(string productId) {

            if (IsInitialized()) {

                var product = _storeCtrl.products.WithID(productId);

                if (product != null && product.availableToPurchase) {
                    _storeCtrl.InitiatePurchase(product);
                }

            }
        }

        // Restore purchases previously made by this customer. Some platforms automatically restore purchases, like Google. 
        // Apple currently requires explicit purchase restoration for IAP, conditionally displaying a password prompt.
        public void RestorePurchases() {
            // If Purchasing has not yet been set up ...
            if (!IsInitialized()) {
                // ... report the situation and stop restoring. Consider either waiting longer, or retrying initialization.
                Debug.Log("RestorePurchases FAIL. Not initialized.");
                return;
            }

            // If we are running on an Apple device ... 
            if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.OSXPlayer) {
                // ... begin restoring purchases
                Debug.Log("RestorePurchases started ...");

                // Fetch the Apple store-specific subsystem.
                var apple = _extensionPrvdr.GetExtension<IAppleExtensions>();
                // Begin the asynchronous process of restoring purchases. Expect a confirmation response in 
                // the Action<bool> below, and ProcessPurchase if there are previously purchased products to restore.
                apple.RestoreTransactions((result) => {
                    // The first phase of restoration. If no more responses are received on ProcessPurchase then 
                    // no purchases are available to be restored.
                    Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
                });
            }
            // Otherwise ...
            else {
                // We are not running on an Apple device. No work is necessary to restore purchases.
                Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
            }
        }

        public void OnInitialized(IStoreController controller, IExtensionProvider extensions) {

            _storeCtrl = controller;
            _extensionPrvdr = extensions;

            // Check is product already buyed.
            if (_storeCtrl.products.WithID(productIdFullAccess).hasReceipt) {

                var userData = SceneData.GetUserData();

                userData.isAccessEasyLevel = true;
                userData.isAccessHardLevel = true;

            }

            if (_storeCtrl.products.WithID(productIdLevel1Access).hasReceipt) {

                var userData = SceneData.GetUserData();
                userData.isAccessEasyLevel = true;

            }

        }

        public void OnInitializeFailed(InitializationFailureReason error) {
            Debug.LogError($"On init fail. {error}");
        }

        public void OnPurchaseFailed(Product i, PurchaseFailureReason p) {
            Debug.Log($"Failed: {i.definition.id}");
        }

        public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs e) {

            if (string.Equals(e.purchasedProduct.definition.id, productIdFullAccess, StringComparison.Ordinal)) {

                var userData = SceneData.GetUserData();

                userData.isAccessEasyLevel = true;
                userData.isAccessHardLevel = true;

                Debug.Log($"Purchase: {e.purchasedProduct.definition.id}");

            } else if (string.Equals(e.purchasedProduct.definition.id, productIdLevel1Access, StringComparison.Ordinal)) {

                var userData = SceneData.GetUserData();

                userData.isAccessEasyLevel = true;

                Debug.Log($"Purchase: {e.purchasedProduct.definition.id}");

            }

            return PurchaseProcessingResult.Complete;

        }

    }
}
