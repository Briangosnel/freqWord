using freqWord;

namespace TestFreqWord;

[TestClass]
public class wordsTest
{
    [TestMethod]
    public void TestMethod1()
    {
        Program.text = "test, test test test";
        Assert.AreEqual(4, Program.GetStringList().Length);
    }
}