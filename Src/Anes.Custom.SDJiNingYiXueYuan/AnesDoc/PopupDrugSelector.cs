using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

using Wis.Anes.Framework.Controls;
using Wis.Anes.Framework.Utilities;
using Wis.Anes.Framework.Documents;
using Wis.Anes.Custom.Views;
using Wis.Anes.BusinessEntity;
using Wis.Anes.Framework.Doc;
using Wis.Anes.Framework;
using Wis.Anes.Framework.Configurations;

using DevExpress.XtraGrid.Views.Base;

namespace Wis.Anes.Custom.CustomProject
{
    public class PopupDrugSelector
    {
        protected static DateTime _currentTime = DateTime.MinValue;
        protected static Control _parent;
        protected static IUIElementHandler _handler;
        protected static string _title;
        protected static decimal _eventNo;

        public static void ShowSelector(DataTable sourceTable, Control parent, Point location, DateTime dt, IUIElementHandler handler, string title, decimal eveNo)
        {
            _currentTime = dt;
            _parent = parent;
            _handler = handler;
            _title = title;
            _eventNo = eveNo;




            if (title.Equals("事件"))
            {
                Dialog.ShowDataTableSelection(sourceTable, "ITEM_NAME", parent, location, new Size(150, 200),
                                 new EventHandler(PopDrugItem_Selected), false, false,null);
            }
            else
            {
                Dialog.ShowDataTableSelection(sourceTable, "ITEM_NAME", parent, location, new Size(175, 225),
                                  new EventHandler(PopDrugItem_Selected), false, false,null);
            }

        }


  

        protected static void PopDrugItem_Selected(object s1, EventArgs e1)
        {
            try
            {
                DataRow row = s1 as DataRow;

                if (row == null)
                    return;

                AnesInformations.AnesthesiaEventDataTable anesEvent = _handler.DataSource["AnesAllEvent"] as AnesInformations.AnesthesiaEventDataTable;
                AnesInformations.AnesthesiaEventRow eventRow = DataContext.GetCurrent().NewAnesthesiaEventRow(anesEvent, _eventNo);

                eventRow.ITEM_CLASS = row["ITEM_CLASS"].ToString();
                eventRow.ITEM_NAME = row["ITEM_NAME"].ToString();
                eventRow.ITEM_SPEC = row["ITEM_SPEC"].ToString();
                eventRow.ITEM_CODE = row["ITEM_CODE"].ToString();
                eventRow.START_DATE_TIME = _currentTime;

                if (!row.IsNull("ADMINISTRATOR"))
                    eventRow.ADMINISTRATOR = row["ADMINISTRATOR"].ToString();

                if (!row.IsNull("CONCENTRATION_UNITS"))
                    eventRow.CONCENTRATION_UNITS = row["CONCENTRATION_UNITS"].ToString();

                if (!row.IsNull("DOSAGE_UNITS"))
                    eventRow.DOSAGE_UNITS = row["DOSAGE_UNITS"].ToString();

                if (!row.IsNull("SPEED_UNITS"))
                    eventRow.SPEED_UNITS = row["SPEED_UNITS"].ToString();

                if (!row.IsNull("SUPPLIER_NAME"))
                    eventRow.SUPPLIER_NAME = row["SUPPLIER_NAME"].ToString();

                if (!row.IsNull("CONCENTRATION"))
                    eventRow.CONCENTRATION = Convert.ToDecimal(row["CONCENTRATION"]);

                if (!row.IsNull("DOSAGE"))
                    eventRow.DOSAGE = Convert.ToDecimal(row["DOSAGE"]);

                if (!row.IsNull("PERFORM_SPEED"))
                    eventRow.PERFORM_SPEED = Convert.ToDecimal(row["PERFORM_SPEED"]);

                if (!row.IsNull("DURATIVE_INDICATOR"))
                    eventRow.DURATIVE_INDICATOR = Convert.ToDecimal(row["DURATIVE_INDICATOR"]);

             
                //if (eventRow.ITEM_NAME == "头孢唑啉" || eventRow.ITEM_NAME == "头孢唑林" || eventRow.ITEM_NAME == "头孢呋辛" || eventRow.ITEM_NAME == "去甲万古霉素")
                //{
                //    eventRow.ADMINISTRATOR = "ivgtt";
                //    eventRow.DURATIVE_INDICATOR = 1;
                //}

                EditEventItem editItem = new EditEventItem();
                editItem.DataSource = eventRow;
                editItem.ItemType = _title == "事件" ? EditEventItem.ItemTypes.EventItem : EditEventItem.ItemTypes.MedicineItem;
                DialogHostForm dialogHostForm = new DialogHostForm(editItem.Caption, 320, 300);
                dialogHostForm.Child = editItem;
                dialogHostForm.Text = _title;
                DialogResult result = dialogHostForm.ShowDialog(_parent);
                if (result == DialogResult.OK)
                {
                    anesEvent.Rows.Add(eventRow);
                    DataContext.GetCurrent().UpdateAnesthesiaEvent(anesEvent);

                    //_handler.DataSource["AnesthesiaEvent"].ImportRow(eventRow);

                    //_handler.RefreshData();
                    if (_handler.AttatchDoc != null)
                        _handler.AttatchDoc.RefreshData();
                }
            }
            catch (Exception err)
            {
                Wis.Anes.Framework.ExceptionHandler.Handle(err);
            }
        }

    }
}
