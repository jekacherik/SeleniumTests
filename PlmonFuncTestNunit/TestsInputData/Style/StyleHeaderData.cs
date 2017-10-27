using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlmonFuncTestNunit.TestsInputData.Style
{
    [PageDataRootElement("styleHeader")]
    public class StyleHeaderData : TestData
    {
        [PageDataPropertyElement("styleNo")] public string StyleNo { get; set; }
        [PageDataPropertyElement("status")] public string Status { get; set; }
        [PageDataPropertyElement("styleType")] public string StyleType { get; set; }
        [PageDataPropertyElement("workflowType")] public string WorkflowType { get; set; }
        [PageDataPropertyElement("description")] public string Description { get; set; }
        [PageDataPropertyElement("division")] public string Division { get; set; }
        [PageDataPropertyElement("introseasonyear")] public string IntroSeasonYear { get; set; }
        [PageDataPropertyElement("calendar")] public string Calendar { get; set; }
        [PageDataPropertyElement("countStyle")] public string CountStyle { get; set; }
        [PageDataPropertyElement("styleSet")] public string StyleSet { get; set; }
        [PageDataPropertyElement("subCategory")] public string SubCategory { get; set; }
        [PageDataPropertyElement("styleCategory")] public string StyleCategory { get; set; }
        [PageDataPropertyElement("sizeClass")] public string SizeClass { get; set; }
        [PageDataPropertyElement("sizeRange")] public string SizeRange { get; set; }
        [PageDataPropertyElement("theme")] public string Theme { get; set; }
        [PageDataPropertyElement("techPackDue")] public string TechPackDue { get; set; }
        [PageDataPropertyElement("designer")] public string Designer { get; set; }
        [PageDataPropertyElement("techDesigner")] public string TechDesigner { get; set; }
        [PageDataPropertyElement("souseContact")] public string SouseContact { get; set; }
        [PageDataPropertyElement("active")] public string Active { get; set; }
        //
        [PageDataPropertyElement("washType")] public string WashType { get; set; }
    }
}
