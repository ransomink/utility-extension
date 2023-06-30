using NUnit.Framework;
using UnityEngine;

namespace Ransom.Tests
{
    public class ColorUtility_RuntimeTests
    {
        [Test]
        public void ColorToUInt_ReturnsExpectedValue()
        {
            // TODO: Incorrect value.
            var color = new Color32(255, 128, 64, 32);
            var expected = 4294967295;
            var result = ColorUtility.ColorToUInt(color);
            
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Compare_UnityColorAndRansomColor_ReturnsTrue()
        {
            var color = new Color32(255, 0, 0, 255);
            var expected = Color.Red;
            var result = color.ToUInt();
            
            Assert.AreEqual(((uint)expected), result);
        }

        [Test]
        public void Compare_ColorAndColor32_ReturnsTrue()
        {
            var lhs = new UnityEngine.Color(1, 0.5f, 0.25f, 0.125f);
            var rhs = new Color32(255, 128, 64, 32);
            var expected = true;
            var result = lhs.Compare(rhs);
            
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ToUInt_ReturnsExpectedValue()
        {
            // TODO: Incorrect value.
            var color = new Color32(255, 128, 64, 32);
            var expected = 4294967295;
            var result = color.ToUInt();
            
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ToHex_ReturnsExpectedValue()
        {
            var color = new Color32(255, 128, 64, 255);
            var expected = "FF8040";
            var result = color.ToHex();
            
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ToHexWithAlpha_ReturnsExpectedValue()
        {
            var color = new Color32(255, 128, 64, 32);
            var expected = "FF804020";
            var result = color.ToHexWithAlpha();
            
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void UIntToColor_ReturnsExpectedColor32()
        {
            // TODO: Incorrect value.
            var color = 4294967295;
            var expected = new Color32(255, 128, 64, 32);
            var result = ColorUtility.UIntToColor(color);
            
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Set_ReturnsExpectedRValue()
        {
            var color = new UnityEngine.Color(1, 0.5f, 0.25f, 0.125f);
            var expected = new UnityEngine.Color(0, 0.5f, 0.25f, 0.125f);
            var result = color.Set(0, 0);
            
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Set_ReturnsExpectedGValue()
        {
            var color = new UnityEngine.Color(1, 0.5f, 0.25f, 0.125f);
            var expected = new UnityEngine.Color(1, 0, 0.25f, 0.125f);
            var result = color.Set(1, 0);
            
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Set_ReturnsExpectedBValue()
        {
            var color = new UnityEngine.Color(1, 0.5f, 0.25f, 0.125f);
            var expected = new UnityEngine.Color(1, 0.5f, 0, 0.125f);
            var result = color.Set(2, 0);
            
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Set_ReturnsExpectedAValue()
        {
            var color = new UnityEngine.Color(1, 0.5f, 0.25f, 0.125f);
            var expected = new UnityEngine.Color(1, 0.5f, 0.25f, 0);
            var result = color.Set(3, 0);
            
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SetR_ReturnsExpectedValue()
        {
            var color = new UnityEngine.Color(1, 0.5f, 0.25f, 0.125f);
            var expected = new UnityEngine.Color(0, 0.5f, 0.25f, 0.125f);
            var result = color.SetR(0);
            
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SetG_ReturnsExpectedValue()
        {
            var color = new UnityEngine.Color(1, 0.5f, 0.25f, 0.125f);
            var expected = new UnityEngine.Color(1, 0, 0.25f, 0.125f);
            var result = color.SetG(0);
            
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SetB_ReturnsExpectedValue()
        {
            var color = new UnityEngine.Color(1, 0.5f, 0.25f, 0.125f);
            var expected = new UnityEngine.Color(1, 0.5f, 0, 0.125f);
            var result = color.SetB(0);
            
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SetA_ReturnsExpectedValue()
        {
            var color = new UnityEngine.Color(1, 0.5f, 0.25f, 0.125f);
            var expected = new UnityEngine.Color(1, 0.5f, 0.25f, 0);
            var result = color.SetA(0);
            
            Assert.AreEqual(expected, result);
        }
    }
}
