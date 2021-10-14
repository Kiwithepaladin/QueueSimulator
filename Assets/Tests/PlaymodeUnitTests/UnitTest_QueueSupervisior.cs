using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using NSubstitute;
using FillingGround.QueueGame;

namespace FillingGround.QueueGame.Tests
{
    public class UnitTest_QueueSupervisior
    {
        [Test]
        public void UnitTest_QueueSupervisiorSimplePasses()
        {
            GameObject go = new GameObject();
            QueueSupervisor queueSupervisior = go.AddComponent<QueueSupervisor>();
        }

        
        [UnityTest]
        public IEnumerator UnitTest_QueueSupervisiorWithEnumeratorPasses()
        {
            yield return null;
        }
    }
}


