/*----------------------------------------------------------------
      // Copyright (C) 2010 北京拓扑工厂科技发展有限公司
      // 文件名：GridViewHelper.cs
      // 文件功能描述：
      //
      // 
      // 修改标识：XXX-2010-12-16
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
namespace Wis.Anes.Framework.Utilities
{
    public class GridViewHelper
    {
        public static void DataGridViewCellPainting(DataGridViewCellPaintingEventArgs e)
        {
            DataGridViewCellPainting(e, e.CellStyle.ForeColor); 
        }

        /// <summary>
        /// 画表头列头-换肤通知无，只能重启
        /// </summary>
        /// <param name="e"></param>
        /// <param name="textColor"></param>
        public static void DataGridViewCellPainting(DataGridViewCellPaintingEventArgs e, Color textColor)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
            {
                //Image image = Globals.GetSkinImage("GridHeader.png");
                //if (image != null)
                //{
                //    Rectangle rect = e.CellBounds;
                //    e.Handled = true;
                //    e.PaintBackground(e.CellBounds, true);
                //    using (Brush brush = new TextureBrush(image))
                //    {
                //        e.Graphics.FillRectangle(brush, rect);
                //    }
                //    rect.X -= 1;
                //    rect.Y -= 1;
                //    using (Pen pen = new Pen(Color.FromArgb(162, 186, 217)))
                //    {
                //        e.Graphics.DrawRectangle(pen, rect);
                //    }
                //    if (e.Value != null)
                //    {
                //        using (Brush brush1 = new SolidBrush(Color.FromArgb(21, 66, 139)))
                //        {
                //            e.Graphics.DrawString(e.Value.ToString(), e.CellStyle.Font, brush1, rect.X + 1
                //                , rect.Y + (rect.Height - e.Graphics.MeasureString("H", e.CellStyle.Font).Height) / 2);
                //        }
                //    }
                //}
            }
        }

        public static void ApplyGridViewStyle(DataGridView grid)
        {
            grid.GridColor = Color.FromArgb(218, 234, 253);
            grid.BorderStyle = BorderStyle.Fixed3D;
            grid.BackgroundColor = Color.White;
            grid.CellPainting += new DataGridViewCellPaintingEventHandler(grid_CellPainting);
        }

        static void grid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            DataGridViewCellPainting(e);
        }
    }
}
