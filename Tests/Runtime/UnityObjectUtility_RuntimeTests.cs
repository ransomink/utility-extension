using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Ransom.Tests
{
    [TestFixture]
    public class UnityObjectUtility_RuntimeTests
    {
        GameObject testObject = default;
        Transform  testObjectTransform = default;
        Component  testComponent = default;

        [SetUp]
        public void SetUp()
        {
            testObject = new GameObject("Test Object");
            testObjectTransform = testObject.transform;
            testComponent = testObject.AddComponent<BoxCollider>();
        }

        [TearDown]
        public void TearDown()
        {
            Object.Destroy(testObject);
        }

        [Test]
        public void Add_AddComponentToGameObject()
        {
            var addedComponent = testObject.Add<Rigidbody>();

            Assert.IsNotNull(addedComponent);
            Assert.IsTrue(testObject.TryGetComponent<Rigidbody>(out var rigidbody));
            Assert.AreEqual(rigidbody, addedComponent);
        }

        [Test]
        public void Add_AddComponentToGameObject_UsingComponent()
        {
            var addedComponent = testComponent.Add<Rigidbody>();

            Assert.IsNotNull(addedComponent);
            Assert.IsTrue(testObject.TryGetComponent<Rigidbody>(out var rigidbody));
            Assert.AreEqual(rigidbody, addedComponent);
        }

        [Test]
        public void AsUnityNull_ReturnsNull_ForNullObject()
        {
            Object nullObject = null;
            Assert.IsNull(nullObject.AsUnityNull());
        }

        [Test]
        public void AsUnityNull_ReturnsObject_IfObjectExists()
        {
            var gameObject = testObject.AsUnityNull();
            Assert.AreSame(testObject, gameObject);
        }

        [Test]
        public void CompareLayer_ReturnsFalse_ForDifferentLayer()
        {
            var gameObject   = new GameObject("Layer Test GameObject");
            gameObject.layer = 5;
            testObject.layer = 0;

            var layerName = LayerMask.LayerToName(testObject.layer);
            var layerMask = (LayerMask)LayerMask.GetMask(layerName);

            Assert.IsFalse(layerMask.CompareLayer(gameObject.layer));
        }

        [Test]
        public void CompareLayer_ReturnsTrue_ForIntLayerMask()
        {
            var gameObject   = new GameObject("Layer Test GameObject");
            gameObject.layer = 5;
            testObject.layer = 5;

            var layerName   = LayerMask.LayerToName(testObject.layer);
            var layerMask   = (LayerMask)LayerMask.GetMask(layerName);
            var goLayerName = LayerMask.LayerToName(gameObject.layer);
            int goLayerMask = LayerMask.GetMask(goLayerName);

            Assert.IsTrue(layerMask.CompareLayer(goLayerMask, true));
        }

        [Test]
        public void CompareLayer_ReturnsTrue_ForLayerMask()
        {
            var gameObject   = new GameObject("Layer Test GameObject");
            gameObject.layer = 5;
            testObject.layer = 5;

            var layerName   = LayerMask.LayerToName(testObject.layer);
            var layerMask   = (LayerMask)LayerMask.GetMask(layerName);
            var goLayerName = LayerMask.LayerToName(gameObject.layer);
            var goLayerMask = (LayerMask)LayerMask.GetMask(goLayerName);

            Assert.IsTrue(layerMask.CompareLayer(goLayerMask));
        }

        [Test]
        public void CompareLayer_ReturnsTrue_ForLayerName()
        {
            var gameObject   = new GameObject("Layer Test GameObject");
            gameObject.layer = 5;
            testObject.layer = 5;

            var layerName   = LayerMask.LayerToName(testObject.layer);
            var layerMask   = (LayerMask)LayerMask.GetMask(layerName);
            var goLayerName = LayerMask.LayerToName(gameObject.layer);

            Assert.IsTrue(layerMask.CompareLayer(goLayerName));
        }

        [Test]
        public void CompareLayer_ReturnsTrue_ForSameLayer()
        {
            var gameObject   = new GameObject("Layer Test GameObject");
            gameObject.layer = 5;
            testObject.layer = 5;

            var layerName = LayerMask.LayerToName(testObject.layer);
            var layerMask = (LayerMask)LayerMask.GetMask(layerName);
            
            Assert.IsTrue(layerMask.CompareLayer(gameObject.layer));
        }

        [Test]
        public void ContainsLayer_ReturnsFalse_ForDifferentLayer()
        {
            var layerA = new GameObject("Layer A GameObject");
            var layerB = new GameObject("Layer B GameObject");
            layerA.layer = 1;
            layerB.layer = 2;
            testObject.layer = 3;

            var layerAName = LayerMask.LayerToName(layerA.layer);
            var layerBName = LayerMask.LayerToName(layerB.layer);
            var layersMask = (LayerMask)LayerMask.GetMask(layerAName, layerBName);

            Assert.IsFalse(layersMask.ContainsLayer(testObject.layer));
        }

        [Test]
        public void ContainsLayer_ReturnsTrue_ForIntLayerMask()
        {
            var layerA = new GameObject("Layer A GameObject");
            var layerB = new GameObject("Layer B GameObject");
            layerA.layer = 1;
            layerB.layer = 5;
            testObject.layer = 5;

            var layerAName = LayerMask.LayerToName(layerA.layer);
            var layerBName = LayerMask.LayerToName(layerB.layer);
            var layersMask = (LayerMask)LayerMask.GetMask(layerAName, layerBName);
            var testLayerName = LayerMask.LayerToName(testObject.layer);
            int testLayerMask = LayerMask.GetMask(testLayerName);

            Assert.IsTrue(layersMask.ContainsLayer(testLayerMask, true));
        }

        [Test]
        public void ContainsLayer_ReturnsTrue_ForLayerMask()
        {
            var layerA = new GameObject("Layer A GameObject");
            var layerB = new GameObject("Layer B GameObject");
            layerA.layer = 1;
            layerB.layer = 5;
            testObject.layer = 5;

            var layerAName = LayerMask.LayerToName(layerA.layer);
            var layerBName = LayerMask.LayerToName(layerB.layer);
            var layersMask = (LayerMask)LayerMask.GetMask(layerAName, layerBName);
            var testLayerName = LayerMask.LayerToName(testObject.layer);
            var testLayerMask = (LayerMask)LayerMask.GetMask(testLayerName);

            Assert.IsTrue(layersMask.ContainsLayer(testLayerMask));
        }

        [Test]
        public void ContainsLayer_ReturnsTrue_ForLayerName()
        {
            var layerA = new GameObject("Layer A GameObject");
            var layerB = new GameObject("Layer B GameObject");
            layerA.layer = 1;
            layerB.layer = 5;
            testObject.layer = 5;

            var layerAName = LayerMask.LayerToName(layerA.layer);
            var layerBName = LayerMask.LayerToName(layerB.layer);
            var layersMask = (LayerMask)LayerMask.GetMask(layerAName, layerBName);
            var testLayerName = LayerMask.LayerToName(testObject.layer);

            Assert.IsTrue(layersMask.ContainsLayer(testLayerName));
        }

        [Test]
        public void ContainsLayer_ReturnsTrue_ForSameLayer()
        {
            var layerA = new GameObject("Layer A GameObject");
            var layerB = new GameObject("Layer B GameObject");
            layerA.layer = 1;
            layerB.layer = 5;
            testObject.layer = 5;

            var layerAName = LayerMask.LayerToName(layerA.layer);
            var layerBName = LayerMask.LayerToName(layerB.layer);
            var layersMask = (LayerMask)LayerMask.GetMask(layerAName, layerBName);
            
            Assert.IsTrue(layersMask.ContainsLayer(testObject.layer));
        }

        [Test]
        public void Get_ReturnsComponent_FromComponent()
        {
            var addedComponent = testObject.AddComponent<Rigidbody>();
            var component = testComponent.Get<Rigidbody>();

            Assert.AreEqual(component, addedComponent);
        }

        [Test]
        public void Get_ReturnsComponent_FromGameObject()
        {
            var component = testObject.Get<BoxCollider>();
            Assert.AreEqual(testComponent, component);
        }

        [Test]
        public void Has_ReturnsFalse_IfComponentDoesNotExist()
        {
            Assert.IsFalse(testObject.Has<Rigidbody>(out _));
            Assert.IsFalse(testComponent.Has<Rigidbody>(out _));
        }

        [Test]
        public void Has_ReturnsTrue_IfComponentExists()
        {
            Assert.IsTrue(testObject.Has<BoxCollider>(out _));
            Assert.IsTrue(testComponent.Has<BoxCollider>(out _));
        }

        
        // [UnityTest]
        // public IEnumerator IsDestroyed_ReturnsTrue_ForDestroyedObject()
        // {
        //     Object.Destroy(testObject);
        //     yield return null;
            
        //     Debug.Log($"Is C# Null: <color=cyan>{(object)testObject is null}</color>");
        //     Debug.Log($"Is Unity Null: <color=cyan>{testObject == null}</color>");
        //     Assert.IsTrue(testObject.IsDestroyed());
        // }

        [Test]
        public void IsDestroyed_ReturnsFalse_ForNonDestroyedObject()
        {
            Assert.IsFalse(testObject.IsDestroyed());
        }

        [Test]
        public void IsUnityNull_ReturnsFalse_IfUnityObjectExists()
        {
            Assert.IsFalse(testObject.IsUnityNull());
        }

        [UnityTest]
        public IEnumerator IsUnityNull_ReturnsTrue_IfUnityObjectDoesNotExist()
        {
            Object.Destroy(testObject);
            yield return null;

            Assert.IsTrue(testObject.IsUnityNull());
        }

        [Test]
        public void OneTimeEvent_RemovesListenerAfterInvocation()
        {
            var unityEvent = new UnityEngine.Events.UnityEvent();
            var callbackInvoked = false;
            System.Action callback = () => callbackInvoked = true;

            unityEvent.OneTimeEvent(callback);
            unityEvent.Invoke();

            Assert.IsTrue(callbackInvoked);
            Assert.AreEqual(0, unityEvent.GetPersistentEventCount());

            var direction = Random.insideUnitCircle.normalized;
            var position = direction * 1 + direction * (3 - 1);
            Debug.Log($"<color=cyan>{position}</color>");
        }

        [UnityTest]
        public IEnumerator IsUnityNull_ReturnsTrue_IfUnityObjectIsNull()
        {
            testObject = null;
            yield return null;

            Assert.IsTrue(testObject.IsUnityNull());
        }

        [UnityTest]
        public IEnumerator RemoveComponent_RemovesComponentFromGameObject()
        {
            testComponent.RemoveComponent();
            yield return null;

            Assert.IsFalse(testObject.TryGetComponent<BoxCollider>(out _));
        }

        [Test]
        public void RemoveComponentImmediate_RemovesComponentImmediatelyFromGameObject()
        {
            testComponent.RemoveComponentImmediate();
            Assert.IsFalse(testObject.TryGetComponent<BoxCollider>(out _));
        }

        [Test]
        public void ToLayer_ReturnsDefaultLayerIfLayerMaskIsZero()
        {
            var layerMask = (LayerMask)(1 << 0);
            var layer = layerMask.ToLayer();

            Assert.AreEqual(0, layer);
        }

        [Test]
        public void ToLayer_ReturnsLayerFromLayerMask()
        {
            var layerMask = (LayerMask)LayerMask.GetMask("UI");
            var layer = layerMask.ToLayer();

            Assert.AreEqual(5, layer);
        }

        [Test]
        public void ToLayerMask_ReturnsLayerMaskFromLayer()
        {
            var layer = 5;
            var layerMask = layer.ToLayerMask();

            Assert.AreEqual(LayerMask.GetMask("UI"), layerMask.value);
        }

        [Test]
        public void ToLayerMask_ReturnsNegativeOneIfLayerIsOutOfRange()
        {
            var layer = 32;
            var layerMask = layer.ToLayerMask();

            Assert.AreEqual(-1, layerMask.value);
        }

        [Test]
        public void TryAddComponent_AddsComponentIfItDoesNotExist()
        {
            testObject.TryAddComponent<MeshRenderer>(out _);
            Assert.IsTrue(testObject.TryGetComponent<MeshRenderer>(out _));
        }

        [Test]
        public void TryAddComponent_DoesNotAddComponentIfItExists()
        {
            testObject.TryAddComponent<BoxCollider>(out _);
            Assert.AreEqual(1, testObject.GetComponents<BoxCollider>().Length);
        }

        [Test]
        public void TryAddComponentToRoot_AddsComponentToRootIfItDoesNotExist()
        {
            var rootObject = new GameObject("Root Object");
            testObject.transform.SetParent(rootObject.transform);
            testObject.transform.localScale = Vector3.one * 2f;

            testObject.TryAddComponentToRoot<MeshRenderer>();
            Assert.IsTrue(rootObject.TryGetComponent<MeshRenderer>(out _));

            Object.Destroy(rootObject);
        }

        [Test]
        public void TryAddComponentToRoot_DoesNotAddComponentToRootIfItExists()
        {
            var rootObject = new GameObject("Root Object");
            testObject.transform.SetParent(rootObject.transform);
            testObject.transform.localScale = Vector3.one * 2f;

            rootObject.AddComponent<MeshRenderer>();
            testObject.TryAddComponentToRoot<MeshRenderer>(rootObject.transform);
            Assert.AreEqual(1, rootObject.GetComponents<MeshRenderer>().Length);

            Object.Destroy(rootObject);
        }
    }
}
