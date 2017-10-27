namespace PlmonFuncTestNunit.TestsInputData.Style
{
    [PageDataRootElement("inputData")]
    public class InputData : TestData
    {
        [PageDataPropertyElement("txtSearchName")] public string TxtSearchName { get; set; }
    }
}
