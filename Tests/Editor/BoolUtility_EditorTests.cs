using NUnit.Framework;
using UnityEngine;

namespace Ransom.Tests
{
    [TestFixture(true)]
    public class BoolUtility_EditorTests
    {
        private readonly bool _testTrue;
        private readonly bool _testFalse;

        public BoolUtility_EditorTests(bool testTrue, bool testFalse)
        {
            _testTrue = testTrue;
            _testFalse = testFalse;
        }

        public BoolUtility_EditorTests(bool testTrue) : this(testTrue, false) {}

        [Test]
        public void Invert_ReturnsExpectedValue()
        {
            var test = _testFalse;

            Debug.Log($"Pre: <color=cyan>{test}</color>");

            var result = test.Invert();

            Debug.Log($"Post: <color=cyan>{test}</color>");
            Debug.Log($"Result: <color=cyan>{result}</color>");

            Assert.AreEqual(true, test);
            Assert.AreEqual(true, result);
        }
        
        [Test]
        public void Inverted_ReturnsExpectedValue()
        {
            Debug.Log($"Pre: <color=cyan>{_testTrue}</color>");

            var result = _testTrue.Inverted();

            Debug.Log($"Post: <color=cyan>{_testTrue}</color>");
            Debug.Log($"Result: <color=cyan>{result}</color>");

            Assert.AreEqual(false, result);
            Assert.AreEqual(true, _testTrue);
        }
        
        [Test]
        public void Ternary_ExecutesCorrectAction()
        {
            var actionTrueCalled  = false;
            var actionFalseCalled = false;

            _testTrue.Ternary(() => actionTrueCalled = true, () => actionFalseCalled = true).Invoke();
            // action();

            Debug.Log($"actionTrueCalled: <color=cyan>{actionTrueCalled}</color>");
            Debug.Log($"actionFalseCalled: <color=cyan>{actionFalseCalled}</color>");

            Assert.AreEqual(true, actionTrueCalled);
            Assert.AreEqual(false, actionFalseCalled);
        }

        [Test]
        public void ToInt_ReturnsExpectedValue()
        {
            var result = _testTrue.ToInt();

            Debug.Log($"Bool: <color=cyan>{_testTrue}</color> | Integer: <color=cyan>{result}</color>");

            Assert.AreEqual(1, result);

            result = _testFalse.ToInt();
            
            Debug.Log($"Bool: <color=cyan>{_testTrue}</color> | Integer: <color=cyan>{result}</color>");
            
            Assert.AreEqual(0, result);
        }
    }
}
