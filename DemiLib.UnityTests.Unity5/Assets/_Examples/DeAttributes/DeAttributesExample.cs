﻿using DG.DemiLib.Attributes;
using UnityEngine;

[DeScriptExecutionOrder(-456)] // Sets the script execution order of this MonoBehaviour to -456
public class DeAttributesExample : MonoBehaviour
{
    const string _MainHeaderTextColor = "ffe682";
    const string _MainHeaderBgColor = "1e78ea";
    const FontStyle _MainHeaderFontStyle = FontStyle.Bold;
    const int _MainHeaderFontSize = 15;

    // DeHeader examples
    [DeHeader("█ DeHeader", _MainHeaderTextColor, _MainHeaderBgColor, _MainHeaderFontStyle, _MainHeaderFontSize, mode = DeHeaderAttribute.Mode.TopDivider)]
    [DeComment("Header decorator with various options for colors etc.", _MainHeaderTextColor, _MainHeaderBgColor)]
    //
    [DeHeader("A default header")]
    public float aRandomVariable = -1;
    [DeHeader("A colored header", "ffd860", "a154df")]
    [DeHeader("A colored header with custom font style, size, and dividers", "ffffff", "ff5e31", FontStyle.Normal, 9, mode = DeHeaderAttribute.Mode.Dividers)]
    [DeHeader("A default header with a bottom divider", mode = DeHeaderAttribute.Mode.BottomDivider)]
    [DeHeader("More custom font style and size", "380b0b", "ffc331", FontStyle.Italic, 16)]
    [DeHeader("A right aligned colored header", TextAnchor.MiddleRight, "ffffff", "ff5458")]
    [DeHeader("Another colored header then an array", "ffffff", "000000")]
    public int[] anArray = new []{ 1, 2, 3 };

    // DeLabel examples
    [DeHeader("█ DeLabel", _MainHeaderTextColor, _MainHeaderBgColor, _MainHeaderFontStyle, _MainHeaderFontSize, mode = DeHeaderAttribute.Mode.TopDivider)]
    [DeComment("Writes custom text instead of the regular property label.", _MainHeaderTextColor, _MainHeaderBgColor)]
    //
    [DeLabel("1234")]
    public float aLabel0 = 27;
    [DeLabel("_%&()")][Tooltip("Can be combined with tooltips")]
    public float aLabel1 = 49;

    // DeColoredLabel examples
    [DeHeader("█ DeColoredLabel", _MainHeaderTextColor, _MainHeaderBgColor, _MainHeaderFontStyle, _MainHeaderFontSize, mode = DeHeaderAttribute.Mode.TopDivider)]
    [DeComment("Colors the label of a property in the Inspector.", _MainHeaderTextColor, _MainHeaderBgColor)]
    //
    [DeColoredLabel("ffd860", "a154df")]
    public string aString0 = "Hellow";
    [DeColoredLabel("ffffff", "ff5e31", "Custom Label")]
    public string aString1 = "Hellow again";
    [DeColoredLabel("222222", "ffc331")]
    public string aString2 = "Hellow enough";

    // DeImage examples
    [DeHeader("█ DeImage", _MainHeaderTextColor, _MainHeaderBgColor, _MainHeaderFontStyle, _MainHeaderFontSize, mode = DeHeaderAttribute.Mode.TopDivider)]
    [DeComment("Draws the given image with options for max width/height.", _MainHeaderTextColor, _MainHeaderBgColor)]
    //
    [DeImage("_Examples/_Images/demilib.png", 150)]
    public string imgString0 = "A kinda logo!";
    [DeImage("_Examples/_Images/ncus.png", -1, 200)]
    [DeImage("_Examples/_Images/goscurry.png", -1, 200)]
    public string imgString1 = "Images above me!";

    // DeConditional + DeBegin/EndDisabled examples
    [DeHeader("█ DeConditional + DeBegin/EndDisabled", _MainHeaderTextColor, _MainHeaderBgColor, _MainHeaderFontStyle, _MainHeaderFontSize, mode = DeHeaderAttribute.Mode.TopDivider)]
    [DeComment("You can choose to disable or completely hide a property based on given conditions. Also, you can disable a group of fields with <b>DeBegin/EndDisabled</b>.", _MainHeaderTextColor, _MainHeaderBgColor)]
    //
    [DeToggleButton("Group Toggle", DePosition.HExtended)]
    public bool groupBool = true;
    [DeBeginDisabled("groupBool")]
    [DeBeginGroup][DeColoredLabel("ffffff", "222222")]
    public float conditioningFloat = 10;
    [DeConditional("conditioningFloat", 10f, Condition.Is, ConditionalBehaviour.Hide)]
    public string conditionalS00 = "Visible if conditioningFloat == 10";
    [DeConditional("conditioningFloat", 10f, Condition.LessThan)]
    public string conditionalS01 = "Enabled if conditioningFloat < 10";
    [DeEndGroup][DeConditional("conditioningFloat", 10f, Condition.GreaterOrEqual)]
    public string conditionalS02 = "Enabled if conditioningFloat >= 10";
    [DeBeginGroup][DeColoredLabel("ffffff", "222222")]
    public int conditioningInt = 69;
    [DeEndGroup][DeConditional("conditioningInt", 45)]
    public string conditionalS10 = "Enabled if conditioningInt == 45";
    [DeBeginGroup][DeColoredLabel("ffffff", "222222")]
    public string conditioningString = "Gino";
    [DeConditional("conditioningString", "Gino")]
    public string conditionalS20 = "Enabled if conditioningString == \"Gino\"";
    [DeEndGroup][DeConditional("conditioningString", "", Condition.IsNot)]
    public string conditionalS21 = "Enabled if conditioningString != \"\"";
    [DeBeginGroup][DeColoredLabel("ffffff", "222222")]
    public bool conditioningBool = true;
    [DeConditional("conditioningBool", true)]
    public string conditionalS30 = "Enabled if conditioningBool is TRUE";
    [DeEndGroup][DeEndDisabled][DeConditional("conditioningBool", false)]
    public string conditionalS31 = "Enabled if conditioningBool is FALSE";

    // DeComment examples
    [DeHeader("█ DeComment", _MainHeaderTextColor, _MainHeaderBgColor, _MainHeaderFontStyle, _MainHeaderFontSize, mode = DeHeaderAttribute.Mode.TopDivider)]
    [DeComment("Shows a box with the desired text, with options for colors etc.", _MainHeaderTextColor, _MainHeaderBgColor)]
    //
    [DeComment("This is how a default DeComment looks like when optional parameters are not used. <b>You can also use <color=#ffd860>rich-text</color></b>.")]
    [DeComment("This one is colored, gosh!\nIt almost looks like a colored DeHeader, if not for the wordWrap.", "ffd860", "a154df")]
    [DeComment("This has some bigger text just because it's cool. <i>Or maybe not</i>.\n<size=18>Is it cool?</size> Is it? Uh? Uh? Ehhhh.", "ffffff", "ff4f5e", fontSize = 11)]

    // DeDivider examples
    [DeHeader("█ DeDivider", _MainHeaderTextColor, _MainHeaderBgColor, _MainHeaderFontStyle, _MainHeaderFontSize, mode = DeHeaderAttribute.Mode.TopDivider)]
    [DeComment("Dividers, with options for color, size and margins.", _MainHeaderTextColor, _MainHeaderBgColor)]
    //
    [DeDivider]
    [DeDivider(4, "ff5e31")]
    [DeDivider(1, "a154df")]

    // DeToggle examples
    [DeHeader("█ DeToggle", _MainHeaderTextColor, _MainHeaderBgColor, _MainHeaderFontStyle, _MainHeaderFontSize, mode = DeHeaderAttribute.Mode.TopDivider)]
    [DeComment("Shows a toggle button instead of the usual checkbox.", _MainHeaderTextColor, _MainHeaderBgColor)]
    //
    [DeToggleButton(DePosition.HExtended)]
    public bool aToggle0;
    [DeToggleButton(DePosition.HExtended)]
    public bool aToggle1;
    [DeToggleButton("0", DePosition.HThirdLeft)]
    public bool bToggle0;
    [DeToggleButton("1", DePosition.HThirdMiddle)]
    public bool bToggle1 = true;
    [DeToggleButton("2", DePosition.HThirdRight)]
    public bool bToggle2;
    [DeToggleButton("A", DePosition.HHalfLeft)]
    public bool cToggle0;
    [DeToggleButton("B", DePosition.HHalfRight)]
    public bool cToggle1;
    [DeToggleButton]
    public bool anotherToggle0;
    [DeToggleButton]
    public bool anotherToggle1;

    // DeBeginGroup examples
    [DeHeader("█ DeBegin/EndGroup", _MainHeaderTextColor, _MainHeaderBgColor, _MainHeaderFontStyle, _MainHeaderFontSize, mode = DeHeaderAttribute.Mode.TopDivider)]
    [DeComment("Wraps all the fields between <b>DeBeginGroup</b> and <b>DeEndGroup</b> inside a box-styled gui skin.", _MainHeaderTextColor, _MainHeaderBgColor)]
    //
    public bool ungroupedBool;
    [DeBeginGroup][DeHeader("Main Group", marginTop = 0)][Range(0, 50)]
    public float groupedSlider = 13;
    public bool groupedBool1;
    [DeBeginGroup][DeHeader("Sub Group", marginTop = 0)]
    public string subgroupedS0 = "This is inside a sub-group";
    [DeEndGroup]
    public string subgroupedS1 = "This too";
    [DeEndGroup]
    public string groupedS0 = "This is inside the main group";

    // DeButton examples
    [DeHeader("█ DeButton + DeMethodButton", _MainHeaderTextColor, _MainHeaderBgColor, _MainHeaderFontStyle, _MainHeaderFontSize, mode = DeHeaderAttribute.Mode.TopDivider)]
    [DeComment("You can place as many DeButton as you want (as long as they're above a field), and use them to call any method of any class. Use <b>DeMethodButton</b> instead to draw a button and directly call the method over which it resides.", _MainHeaderTextColor, _MainHeaderBgColor)]
    //
    [DeButton(typeof(DeAttributesExample), "SamplePublic")]
    [DeButton("ffcf40", "ff0000", typeof(DeAttributesExample), "SamplePrivate")]
    [DeButton("A Toggle - Method with params and custom label", null, "ffcf40", typeof(DeAttributesExample), "SamplePrivateWithParams", 45, "hellow")]
    [DeButton(DePosition.HThirdLeft, typeof(DeAttributesExample), "SamplePublic")]
    [DeButton(DePosition.HThirdMiddle, null, "00ff00", typeof(DeAttributesExample), "SamplePublic")]
    [DeButton(DePosition.HThirdRight, "d39fff", "ac6be3", typeof(DeAttributesExample), "SamplePublic")]
    [DeButton(DePosition.HHalfLeft, typeof(DeAttributesExample), "SamplePublic")]
    [DeButton(DePosition.HHalfRight, typeof(DeAttributesExample), "SamplePublic")]
    [DeButton(DePosition.HDefault, typeof(DeAttributesExample), "SamplePublic")]
    [TextArea]
    public string note = "Below me there's DeMethodButtons instead, which are attributes placed directly over a method instead of a field (like the ones above me).";

    public void SamplePublic()
    {
        Debug.Log("SamplePublic method was called, wohooo!");
    }
    void SamplePrivate()
    {
        Debug.Log("SamplePrivate method was called, wohooo!");
    }
    static void SampleStatic()
    {
        Debug.Log("SampleStatic method was called, ta-dah!");
    }
    void SamplePrivateWithParams(float f, string s)
    {
        Debug.Log(string.Format("SamplePrivateWithParams method was called with params: {0}, \"{1}\"", f, s));
    }

    [DeMethodButton("Custom text no params")]
    [DeMethodButton("Custom text and params", 1, "CUSTOM!")]
    void SampleMethod00(string s = null)
    {
        Debug.Log(string.Format("SampleMethod0 called, dum dee dum! Custom param: \"{0}\"", s));
    }

    [DeMethodButton]
    void SampleMethod_01(string s = null)
    {
        Debug.Log(string.Format("SampleMethod1 called, la dee da! Custom param: \"{0}\"", s));
    }
}