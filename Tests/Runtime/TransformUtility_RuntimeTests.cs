using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Ransom.Tests
{
    public class TransformUtility_RuntimeTests
    {
        private const float Delta = .0055f;
        
        [UnityTest]
        public IEnumerator Back_ReturnInverseOfForward()
        {
            var t = new GameObject().transform;
            t.forward = new Vector3(0, 0, 1);

            yield return null;
            var result = t.Back();

            Assert.AreEqual(new Vector3(0, 0, -1), result);
        }

        [UnityTest]
        public IEnumerator Down_ReturnInverseOfUp()
        {
            var t = new GameObject().transform;
            t.up = new Vector3(0, 1, 0);

            yield return null;
            var result = t.Down();

            Assert.AreEqual(new Vector3(0, -1, 0), result);
        }

        [UnityTest]
        public IEnumerator Left_ReturnsInverseOfRight()
        {
            var t = new GameObject().transform;
            t.right = new Vector3(1, 0, 0);

            yield return null;
            var result = t.Left();

            Assert.AreEqual(new Vector3(-1, 0, 0), result);
        }

        [UnityTest]
        public IEnumerator Inverse_ReturnsInvertedVector()
        {
            var vec = new Vector3(1, 2, 3);

            yield return null;
            var result = vec.Inverse();

            Assert.AreEqual(new Vector3(-1, -2, -3), result);
        }

        [UnityTest]
        public IEnumerator AddPos_ReturnsExpectedValue()
        {
            var t = new GameObject().transform;
            t.position = Vector3.zero;
            t.AddPos(new Vector3(1, 0, 0 ));

            yield return null;

            Assert.AreEqual(new Vector3(1, 0, 0), t.position);
            Assert.AreEqual(new Vector3(1, 0, 0), t.localPosition);
        }

        [UnityTest]
        public IEnumerator AddPos_UseLocal_ReturnsExpectedValue()
        {
            Vector3 vector = new Vector3(1, 0, 0);
            var p = new GameObject().transform;
            var t = new GameObject().transform;
            p.position = Vector3.zero;
            t.position = Vector3.zero;
            t.SetParent(p);
            t.AddPos(vector, true);
            p.AddPos(vector);

            yield return null;

            Assert.AreEqual(new Vector3(2, 0, 0), t.position);
            Assert.AreEqual(new Vector3(1, 0, 0), t.localPosition);
        }

        [UnityTest]
        public IEnumerator LocalPos_ReturnsExpectedXValue()
        {
            Vector3 vector = new Vector3(1, 0, 0);
            var p = new GameObject().transform;
            var t = new GameObject().transform;
            p.position = Vector3.zero;
            t.position = Vector3.zero;
            t.SetParent(p);
            t.LocalPos(0, 5);
            p.AddPos(vector);

            yield return null;

            Assert.AreEqual(new Vector3(6, 0, 0), t.position);
            Assert.AreEqual(new Vector3(5, 0, 0), t.localPosition);
        }

        [UnityTest]
        public IEnumerator LocalPos_ReturnsExpectedYValue()
        {
            Vector3 vector = new Vector3(1, 0, 0);
            var p = new GameObject().transform;
            var t = new GameObject().transform;
            p.position = Vector3.zero;
            t.position = Vector3.zero;
            t.SetParent(p);
            t.LocalPos(1, 5);
            p.AddPos(vector);

            yield return null;

            Assert.AreEqual(new Vector3(1, 5, 0), t.position);
            Assert.AreEqual(new Vector3(0, 5, 0), t.localPosition);
        }

        [UnityTest]
        public IEnumerator LocalPos_ReturnsExpectedZValue()
        {
            Vector3 vector = new Vector3(1, 0, 0);
            var p = new GameObject().transform;
            var t = new GameObject().transform;
            p.position = Vector3.zero;
            t.position = Vector3.zero;
            t.SetParent(p);
            t.LocalPos(2, 5);
            p.AddPos(vector);

            yield return null;

            Assert.AreEqual(new Vector3(1, 0, 5), t.position);
            Assert.AreEqual(new Vector3(0, 0, 5), t.localPosition);
        }

        [UnityTest]
        public IEnumerator LocalPos_Add_ReturnsExpectedValue()
        {
            var t = new GameObject().transform;
            t.position = Vector3.zero;
            t.localPosition = Vector3.one;
            t.LocalPos(new Vector3(1, 2, 3), true);

            yield return null;

            Assert.AreEqual(new Vector3(2, 3, 4), t.localPosition);
        }

        [UnityTest]
        public IEnumerator LocalRot_ReturnsExpectedXValue()
        {
            var t = new GameObject().transform;
            t.localRotation = Quaternion.identity;
            t.LocalRot(0, 5);
            Debug.Log($"Local Rot: <color=cyan>{t.localEulerAngles}</cyan>");

            yield return null;

            Assert.That(new Vector3(5, 0, 0) == t.localEulerAngles);
            Assert.That(new Vector3(5, 0, 0) == t.localRotation.eulerAngles);
        }

        [UnityTest]
        public IEnumerator LocalRot_ReturnsExpectedEuler()
        {
            var v = new Vector3(0, 5, 0);
            var t = new GameObject().transform;
            t.localRotation = Quaternion.identity;
            t.LocalRot(v);

            yield return null;

            Assert.That(new Vector3(0, 5, 0) == t.localEulerAngles);
            Assert.That(new Vector3(0, 5, 0) == t.localRotation.eulerAngles);
        }

        [UnityTest]
        public IEnumerator LocalRot_ReturnsExpectedQuaternion()
        {
            var v = new Vector3(10, 20, 30);
            var q = Quaternion.Euler(v);
            var t = new GameObject().transform;
            t.localRotation = Quaternion.identity;
            t.LocalRot(q);

            yield return null;

            Assert.That(v == t.localEulerAngles);
            Assert.That(v == t.localRotation.eulerAngles);
            Assert.That(q == t.localRotation);
        }

        [UnityTest]
        public IEnumerator Pos_ReturnsExpectedXValue()
        {
            var t = new GameObject().transform;
            t.position = Vector3.zero;
            t.Pos(0, 5);

            yield return null;

            Assert.AreEqual(new Vector3(5, 0, 0), t.position);
            Assert.AreEqual(new Vector3(5, 0, 0), t.localPosition);
        }

        [UnityTest]
        public IEnumerator Pos_ReturnsExpectedYValue()
        {
            var t = new GameObject().transform;
            t.position = Vector3.zero;
            t.Pos(1, 5);

            yield return null;

            Assert.AreEqual(new Vector3(0, 5, 0), t.position);
            Assert.AreEqual(new Vector3(0, 5, 0), t.localPosition);
        }

        [UnityTest]
        public IEnumerator Pos_ReturnsExpectedZValue()
        {
            var t = new GameObject().transform;
            t.position = Vector3.zero;
            t.Pos(2, 5);

            yield return null;

            Assert.AreEqual(new Vector3(0, 0, 5), t.position);
            Assert.AreEqual(new Vector3(0, 0, 5), t.localPosition);
        }

        [UnityTest]
        public IEnumerator PosX_ReturnsExpectedValue()
        {
            var t = new GameObject().transform;
            t.position = Vector3.zero;
            t.PosX(5);

            yield return null;

            Assert.AreEqual(new Vector3(5, 0, 0), t.position);
            Assert.AreEqual(new Vector3(5, 0, 0), t.localPosition);
        }

        [UnityTest]
        public IEnumerator PosY_ReturnsExpectedValue()
        {
            var t = new GameObject().transform;
            t.position = Vector3.zero;
            t.PosY(5);

            yield return null;

            Assert.AreEqual(new Vector3(0, 5, 0), t.position);
            Assert.AreEqual(new Vector3(0, 5, 0), t.localPosition);
        }

        [UnityTest]
        public IEnumerator PosZ_ReturnsExpectedValue()
        {
            var t = new GameObject().transform;
            t.position = Vector3.zero;
            t.PosZ(5);

            yield return null;

            Assert.AreEqual(new Vector3(0, 0, 5), t.position);
            Assert.AreEqual(new Vector3(0, 0, 5), t.localPosition);
        }

        [UnityTest]
        public IEnumerator Rot_ReturnsExpectedXValue()
        {
            var t = new GameObject().transform;
            t.rotation = Quaternion.identity;
            t.Rot(0, 5);

            yield return null;

            Assert.That(new Vector3(5, 0, 0) == t.eulerAngles);
            Assert.That(new Vector3(5, 0, 0) == t.rotation.eulerAngles);
        }

        [UnityTest]
        public IEnumerator Rot_ReturnsExpectedYValue()
        {
            var t = new GameObject().transform;
            t.rotation = Quaternion.identity;
            t.Rot(1, 5);

            yield return null;

            Assert.That(new Vector3(0, 5, 0) == t.eulerAngles);
            Assert.That(new Vector3(0, 5, 0) == t.rotation.eulerAngles);
        }

        [UnityTest]
        public IEnumerator Rot_ReturnsExpectedZValue()
        {
            var t = new GameObject().transform;
            t.rotation = Quaternion.identity;
            t.Rot(2, 5);

            yield return null;

            Assert.That(new Vector3(0, 0, 5) == t.eulerAngles);
            Assert.That(new Vector3(0, 0, 5) == t.rotation.eulerAngles);
        }

        [UnityTest]
        public IEnumerator Rot_ReturnsExpectedEuler()
        {
            var v = new Vector3(0, 5, 0);
            var t = new GameObject().transform;
            t.rotation = Quaternion.identity;
            t.Rot(v);

            yield return null;

            Assert.That(new Vector3(0, 5, 0) == t.eulerAngles);
            Assert.That(new Vector3(0, 5, 0) == t.rotation.eulerAngles);
        }

        [UnityTest]
        public IEnumerator Rot_ReturnsExpectedQuaternion()
        {
            var v = new Vector3(10, 20, 30);
            var q = Quaternion.Euler(v);
            var t = new GameObject().transform;
            t.rotation = Quaternion.identity;
            t.Rot(q);

            yield return null;

            Assert.That(v == t.eulerAngles);
            Assert.That(v == t.rotation.eulerAngles);
            Assert.That(q == t.rotation);
        }

        [UnityTest]
        public IEnumerator RotX_ReturnsExpectedValue()
        {
            var t = new GameObject().transform;
            t.rotation = Quaternion.identity;
            t.RotX(5);

            yield return null;

            Assert.That(new Vector3(5, 0, 0) == t.eulerAngles);
            Assert.That(new Vector3(5, 0, 0) == t.rotation.eulerAngles);
        }

        [UnityTest]
        public IEnumerator RotY_ReturnsExpectedValue()
        {
            var t = new GameObject().transform;
            t.rotation = Quaternion.identity;
            t.RotY(5);

            yield return null;

            Assert.That(new Vector3(0, 5, 0) == t.eulerAngles);
            Assert.That(new Vector3(0, 5, 0) == t.rotation.eulerAngles);
        }

        [UnityTest]
        public IEnumerator RotZ_ReturnsExpectedValue()
        {
            var t = new GameObject().transform;
            t.rotation = Quaternion.identity;
            t.RotZ(5);

            yield return null;

            Assert.That(new Vector3(0, 0, 5) == t.eulerAngles);
            Assert.That(new Vector3(0, 0, 5) == t.rotation.eulerAngles);
        }
    }
}
