using NUnit.Framework;

namespace Ransom.Tests
{
    public class StringUtility_RuntimeTests
    {
        [Test]
        public void Bold_ReturnsExpectedValue()
        {
            var input = "Test";
            var expected = "<b>Test</b>";
            var result = input.Bold();
            
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Color_ReturnsExpectedRansomColor()
        {
            var input = "Test";
            var color = Color.Red;
            var expected = "<color=#FF0000FF>Test</color>";
            var result = input.Color(color);
            
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Color_ReturnsExpectedUnityColor()
        {
            var input = "Test";
            var color = UnityEngine.Color.red;
            var expected = "<color=#FF0000FF>Test</color>";
            var result = input.Color(color);
            
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Color_ReturnsExpectedHex()
        {
            var input = "Test";
            var hex = "FF0000";
            var expected = "<color=#FF0000>Test</color>";
            var result = input.Color(hex);
            
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Color_ReturnsExpectedHexWithAlpha()
        {
            var input = "Test";
            var hex = "FF0000FF";
            var expected = "<color=#FF0000FF>Test</color>";
            var result = input.Color(hex);
            
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ColorLog_ReturnsExpectedValue()
        {
            var input = "Test";
            var color = UnityEngine.Color.red;
            var expected = "<color=#FF0000FF>Test</color>";
            var result = StringUtility.ColorLog(input, color);
            
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Italic_ReturnsExpectedValue()
        {
            var input = "Test";
            var expected = "<i>Test</i>";
            var result = input.Italic();
            
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Size_ReturnsExpectedValue()
        {
            var input = "Test";
            var size = 24f;
            var expected = "<size=24>Test</size>";
            var result = input.Size(size);
            
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void CharacterLength_ReturnsExpectedValue()
        {
            var input1 = "Test";
            var input2 = "Example";
            var expected = input1.Length + input2.Length;
            var result = StringUtility.CharacterLength(input1, input2);
            
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void CharacterLengthArray_ReturnsExpectedValue()
        {
            var input = new[] { "Test", "Example", "Array" };
            var expected = "Test".Length + "Example".Length + "Array".Length;
            var result = StringUtility.CharacterLength(input);
            
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void CombineLength_ReturnsExpectedValue()
        {
            var input1 = "Test";
            var input2 = "Example";
            var expected = input1.Length + input2.Length;
            var result = input1.CombineLength(input2);
            
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void CombineLengthArray_ReturnsExpectedValue()
        {
            var input1 = "Test";
            var input2 = new[] { "Test", "Example", "Array" };
            var expected = input1.Length + "Test".Length + "Example".Length + "Array".Length;
            var result = input1.CombineLength(input2);
            
            Assert.AreEqual(expected, result);
        }
    }
}
