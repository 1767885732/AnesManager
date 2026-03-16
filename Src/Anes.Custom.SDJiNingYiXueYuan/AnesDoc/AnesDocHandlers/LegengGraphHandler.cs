using System;
using System.Collections.Generic;
using System.Text;
using Wis.Anes.Framework.Controls;
using Wis.Anes.Framework.Documents;
using System.Windows.Forms;
using System.Drawing;
using Wis.Anes.Framework.Doc;
using Wis.Anes.Framework;

namespace Wis.Anes.Custom.CustomProject
{

    public class LegengGraphHandler : UIElementHandler<MedLegengGraph>
    {

        /// <summary>
        /// 绑定数据源数据到控件
        /// </summary>
        public override void BindDataToUI(MedLegengGraph control, Dictionary<string, System.Data.DataTable> dataSources)
        {
            MedVitalSignGraph vitalGraph = null;
            foreach (IUIElementHandler handler in MedicalPaperUIElementHandlers)
            {
                if (handler.GetControlType == typeof(MedVitalSignGraph) && handler.GetCurrentControl != null)
                    vitalGraph = handler.GetCurrentControl as MedVitalSignGraph;
            }
            control.VitalSign = vitalGraph;
        }

        ///// <summary>
        ///// 绑定数据源数据到控件
        ///// </summary>
        //public override void BindDataToUI(MedLegengGraph control, Dictionary<string, System.Data.DataTable> dataSources)
        //{
        //    MedVitalSignGraph _vitalGraph = null;
        //    foreach (IUIElementHandler handler in MedicalPaperUIElementHandlers)
        //    {
        //        if (handler.GetControlType == typeof(MedVitalSignGraph) && handler.GetCurrentControl != null)
        //            _vitalGraph = handler.GetCurrentControl as MedVitalSignGraph;
        //    }
        //    Dictionary<string, MedLegeng> symbolDict = new Dictionary<string, MedLegeng>();
        //    if (_vitalGraph != null)
        //    {
        //        List<MedVitalSignCurveDetail> vitalSignSets = GetUserVitalShowSet(_vitalGraph.EventNo);

        //        foreach (MedSymbolCurveDetail symbolCurveDetail in _vitalGraph.EventMarkSettings)
        //        {

        //            string legengCode = symbolCurveDetail.Text;
        //            if (legengCode.Contains("麻醉开始") || legengCode.Contains("麻醉结束"))
        //            {
        //                legengCode = "麻醉";
        //            }
        //            else if (legengCode.Contains("手术开始") || legengCode.Contains("手术结束"))
        //            {
        //                legengCode = "手术";
        //            }

        //            if (!symbolDict.ContainsKey(legengCode))
        //            {
        //                MedLegeng medlegeng = new MedLegeng();
        //                MedSymbol symbol = new MedSymbol(symbolCurveDetail.SymbolType);
        //                symbol.Size = 9f;
        //                symbol.Pen = new Pen(symbolCurveDetail.Color);
        //                medlegeng.LegengCode = legengCode;
        //                medlegeng.LegengName = legengCode;
        //                medlegeng.LegengSymbol = symbol;
        //                symbolDict.Add(medlegeng.LegengCode, medlegeng);
        //            }
        //        }
        //        foreach (MedVitalSignCurveDetail vitalSet in vitalSignSets)
        //        {
        //            if (!string.IsNullOrEmpty(vitalSet.CurveCode) && !symbolDict.ContainsKey(vitalSet.CurveCode) && vitalSet.ShowType.Equals(MedCurveShowType.Line))
        //            {
        //                MedLegeng medlegeng = new MedLegeng();
        //                MedSymbol symbol = new MedSymbol(vitalSet.SymbolType);
        //                symbol.Size = 9f;
        //                symbol.Pen = new Pen(vitalSet.Color);
        //                medlegeng.LegengCode = vitalSet.CurveCode;
        //                medlegeng.LegengName = vitalSet.CurveName;
        //                medlegeng.LegengSymbol = symbol;
        //                symbolDict.Add(medlegeng.LegengCode, medlegeng);
        //            }
        //        }
        //        foreach (MedVitalSignCurve curve in _vitalGraph.Curves)
        //        {
        //            if (!string.IsNullOrEmpty(curve.Code) && !symbolDict.ContainsKey(curve.Code) && curve.Symbol != null && !curve.IsDigit)
        //            {
        //                MedLegeng medlegeng = new MedLegeng();
        //                MedSymbol symbol = new MedSymbol(curve.Symbol.SymbolType);
        //                symbol.Size = 9f;
        //                symbol.Pen = curve.Symbol.Pen;
        //                medlegeng.LegengCode = curve.Code;
        //                medlegeng.LegengName = curve.Text;
        //                medlegeng.LegengSymbol = symbol;
        //                symbolDict.Add(medlegeng.LegengCode, medlegeng);
        //            }
        //        }
        //        int lastIndex = 0;
        //        List<MedLegengGraph> list = base.GetCurrentControls;
        //        foreach (MedLegengGraph legengGraph in list)
        //        {
        //            if (legengGraph.Name != "AddedLegengGraph")
        //            {
        //                legengGraph.ReCalLastIndex(symbolDict);
        //                lastIndex = legengGraph.EndLegendIndex > lastIndex ? legengGraph.EndLegendIndex : lastIndex;
        //            }
        //        }
        //        foreach (MedLegengGraph legengGraph in list)
        //        {
        //            if (legengGraph.Name == "AddedLegengGraph")
        //            {
        //                if (symbolDict.Count - 1 > lastIndex && lastIndex != 0)
        //                {
        //                    legengGraph.StartLegendIndex = lastIndex;
        //                    if (legengGraph.Parent.Name == "AddedSymbolPanel")
        //                    {
        //                        legengGraph.Parent.Visible = true;
        //                    }
        //                }
        //                else
        //                {
        //                    if (legengGraph.Parent.Name == "AddedSymbolPanel")
        //                    {
        //                        legengGraph.Parent.Visible = false;
        //                    }
        //                }
        //            }
        //        }
        //        control.SymbolDict = symbolDict;
        //    }


        //}
        private MedSymbolCurveDetail GetVitalSignEventMark(MedVitalSignGraph vitalSignGraph, string curveText)
       {
           foreach (MedSymbolCurveDetail curveDetail in vitalSignGraph.EventMarkSettings)
           {
               string text1 = curveText.Trim();
               string text2 = curveDetail.Text.Trim();
               if (text1.ToLower().Equals(text2.ToLower()) || text1.ToLower().StartsWith(text2.ToLower() + "("))
               {
                   return curveDetail;
               }
               else if ((text2.EndsWith("%") && text1.StartsWith(text2.Substring(0, text2.Length - 2))) ||
                   (text2.StartsWith("%") && text1.EndsWith(text2.Substring(1))) ||
                   (text2.StartsWith("%") && text2.EndsWith("%") && text1.Contains(text2.Substring(1, text2.Length - 2))))
               {
                   return curveDetail;
               }
           }
           return null;
       }

       /// <summary>
       ///  绑定控件内容到数据源
       /// </summary>
       /// <param name="control"></param>
       /// <param name="dataSources"></param>
       public override void BindUIToData(MedLegengGraph control, Dictionary<string, System.Data.DataTable> dataSources)
       {
           
       }
       /// <summary>
       /// 控件属性事件设置
       /// </summary>
       /// <param name="control"></param>
       public override void ControlSetting(MedLegengGraph control)
       {
           //control.CustomDraw -= new PaintEventHandler(control_CustomDraw);
           //control.CustomDraw += new PaintEventHandler(control_CustomDraw);
       }

       void control_CustomDraw(object sender, PaintEventArgs e)
       {
           
           Graphics g = e.Graphics;
           Font font = new Font("宋体", 9);
           Brush brush = Brushes.Black;
           //g.DrawString("脉搏", font, brush, 6, 80);
           //int dw = 6 + (int)g.MeasureString("脉搏", font).Width;
           //g.DrawString("次/分", new Font("宋体", 7), brush, dw, 82);
           //dw += (int)g.MeasureString("次/分", new Font("宋体", 7)).Width;
           //g.DrawString("/血压mmHg", font, brush, dw, 80);
           //int dh = (int)g.MeasureString("脉搏", font).Height;
           //g.DrawString("呼吸", font, brush, 6, 80 + dh);
           //int dw2 = 6 + (int)g.MeasureString("呼吸", font).Width;
           //g.DrawString("次/分", new Font("宋体", 7), brush, dw2, 82 + dh);

           //g.DrawString("标    记", font, brush, 30, 460);

           float top = 2;
           float left = 6;
           float left1 = 64;
           float ySpan = 15;
           float symRaid = 5;
           g.DrawString("图例", font, brush, left, top);
           top += ySpan;
           g.DrawString("血    压", font, brush, left, top);
           MedSymbol symbol = new MedSymbol(MedSymbolType.VLetter);
           symbol.Size = 8;
           symbol.Draw(g, left1 + symRaid, top);
           symbol.Draw(g, left1 + symRaid * 3 + 10, top);
           g.DrawLine(Pens.Black, left1 + symRaid, top + symRaid, left1 + symRaid * 3 + 10, top + symRaid);
           symbol.SymbolType = MedSymbolType.VLetterDown;
           top += symRaid * 2 - 2;
           symbol.Draw(g, left1 + symRaid, top + symRaid);
           symbol.Draw(g, left1 + symRaid * 3 + 10, top + symRaid);
           g.DrawLine(Pens.Black, left1 + symRaid, top, left1 + symRaid * 3 + 10, top);

           symbol.Size = symRaid * 2;

           top += ySpan - symRaid * 2 + 4;
           g.DrawString("脉    搏", font, brush, left, top);
           symbol.SymbolType = MedSymbolType.FillCircle;
           symbol.Draw(g, left1 + symRaid, top + symRaid);
           symbol.Draw(g, left1 + symRaid * 3 + 10, top + symRaid);
           g.DrawLine(Pens.Black, left1 + symRaid, top + symRaid, left1 + symRaid * 3 + 10, top + symRaid);

           top += ySpan;
           g.DrawString("自主呼吸", font, brush, left, top);
           symbol.SymbolType = MedSymbolType.Circle;
           symbol.Draw(g, left1 + symRaid, top + symRaid);
           symbol.Draw(g, left1 + symRaid * 3 + 10, top + symRaid);
           g.DrawLine(Pens.Black, left1 + symRaid * 2, top + symRaid, left1 + symRaid * 2 + 10, top + symRaid);

           top += ySpan;
           g.DrawString("机械通气", font, brush, left, top);
           symbol.SymbolType = MedSymbolType.MachineAir;
           symbol.Draw(g, left1 + symRaid + 10, top + symRaid);

           if (ExtendApplicationContext.Current.EventNo == 0)
           {
               top += ySpan;
               g.DrawString("麻醉开始", font, brush, left, top);
               symbol.SymbolType = MedSymbolType.XCross;
               symbol.Draw(g, left1 + symRaid + 10, top + symRaid);
           }

           top += ySpan;
           g.DrawString("置    管", font, brush, left, top);
           symbol.SymbolType = MedSymbolType.CircleHArrow;
           symbol.Draw(g, left1 + symRaid + 10, top + symRaid);

           top += ySpan;
           g.DrawString("拔    管", font, brush, left, top);
           symbol.SymbolType = MedSymbolType.CircleVArrow;
           symbol.Draw(g, left1 + symRaid + 10, top + symRaid);

           if (ExtendApplicationContext.Current.EventNo == 0)
           {
               top += ySpan;
               g.DrawString("手术开始", font, brush, left, top);
               symbol.SymbolType = MedSymbolType.CircleDot;
               symbol.Draw(g, left1 + symRaid + 10, top + symRaid);

               top += ySpan;
               g.DrawString("手术结束", font, brush, left, top);
               symbol.SymbolType = MedSymbolType.CircleXCross;
               symbol.Draw(g, left1 + symRaid + 10, top + symRaid);
           }

           top += ySpan;
           g.DrawString("备注:", font, brush, left, top);
           font.Dispose();
       }
    }
}
