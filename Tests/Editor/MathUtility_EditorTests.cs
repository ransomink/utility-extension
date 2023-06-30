using NUnit.Framework;
using UnityEngine;

namespace Ransom.Tests
{
    public class MathUtility_EditorTests
    {
        [Test]
        public void IsBetween_InRange_ReturnsTrue()
        {
            Assert.IsTrue(1.IsBetween(0, 2));
        }

        [Test]
        public void IsBetween_OutOfRange_ReturnsFalse()
        {
            Assert.IsFalse(3.IsBetween(0, 2));
        }

        [Test]
        public void IsEven_EvenNumber_ReturnsTrue()
        {
            Assert.IsTrue(0.IsEven());
        }

        [Test]
        public void IsEven_OddNumber_ReturnsFalse()
        {
            Assert.IsFalse(1.IsEven());
        }

        [Test]
        public void IsZero_Zero_ReturnsTrue()
        {
            Assert.IsTrue(0.IsZero());
        }

        [Test]
        public void IsZero_NonZero_ReturnsFalse()
        {
            Assert.IsFalse(1.IsZero());
        }

        [Test]
        public void IsZero_ZeroWithinTolerance_ReturnsTrue()
        {
            Assert.IsTrue(Mathf.Epsilon.IsZero());
        }

        [Test]
        public void IsZero_NonZeroWithinTolerance_ReturnsFalse()
        {
            Assert.IsFalse(0.001f.IsZero());
        }

        [Test]
        public void Remap_ReturnsExpectedValue()
        {
            var value = 0.5f;
            var min = 0f;
            var max = 1f;
            var percent = 0.5f;
            var expected = 0.5f;
            var result = value.Remap(min, max, percent);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Remap_ReturnsExpectedValueWithNewRange()
        {
            var value = 0.5f;
            var curMin = 0f;
            var curMax = 1f;
            var newMin = -1f;
            var newMax = 2f;
            var expected = 1f;
            var result = value.Remap(curMin, curMax, newMin, newMax);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Remap01_ReturnsExpectedValue()
        {
            var value = 0.5f;
            var min = -1f;
            var max = 1f;
            var expected = 0.75f;
            var result = value.Remap01(min, max);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Squared_Int_ReturnsExpectedValue()
        {
            var value = 2;
            var expected = 4;
            var result = value.Squared();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Squared_Float_ReturnsExpectedValue()
        {
            var value = 2.5f;
            var expected = 6.25f;
            var result = value.Squared();

            Assert.AreEqual(expected, result);
        }
    }
}
