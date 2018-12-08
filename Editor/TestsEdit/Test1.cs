using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;


public class Test1 {

    
    [SetUp]
    public void SetUp(){
        
        // WarManager accountManager = Substitute.For<WarManager> ();
        // Loot loot = new Loot(20,20,20,2);
        // City city = new City("Paris",20,ConstantsAndEnums.dificultyInGame.easy,5,loot);
        
        Assert.AreEqual("yo","yo");
    }

    [Test]
    public void Test1SimplePasses() {
        // Use the Assert class to test conditions.
        Assert.AreEqual("yo","yi");
    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator Test1WithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        yield return null;
    }
}
