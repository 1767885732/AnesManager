using System;
using System.Collections.Generic;
using System.Text;
using Wis.Anes.Framework.Permissions;
using Wis.Anes.BusinessEntity;
using Wis.Anes.Framework;
using Wis.Anes.Custom.CustomProject.CustomSetting;
using Wis.Anes.DataAccess;

namespace Wis.Anes.Custom.CustomProject.Permissions
{
    public class PermissionProviderCustom : PermissionProvider
    {
        /// <summary>
        /// 重写权限
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public override PermissionContext.RightType CheckRight(string text)
        {

           return base.CheckRight(text);
        }


        /// <summary>
        /// 重写权限
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public override bool CheckModifyRight(string text)
        {
            if ((CheckRight(PermissionContext.MODIFYDOCUMENTFOREVER) & PermissionContext.RightType.Modify) == PermissionContext.RightType.Modify)
            {
                return true;
            }
            return base.CheckModifyRight(text);
        }




        /// <summary
        /// 获取文书操作员权限，如果该文书的麻醉医生、手术医生、交班医生是自己的话，则有编辑权限，否则浏览
        /// </summary>
        /// <param name="rightKey"></param>
        /// <returns></returns>
        public override PermissionContext.RightType GetDocRightTypeForOperator(string rightKey)
        {

            bool checkPrint = false;
            if (rightKey.StartsWith("打印-"))
            {
                checkPrint = true;
                rightKey = rightKey.Replace("打印-", "");
            }
            if ((CheckRight(PermissionContext.MODIFYDOCUMENTFOREVER) & PermissionContext.RightType.Modify) == PermissionContext.RightType.Modify)
            {
                return PermissionContext.RightType.Modify;
            }

             PermissionContext.RightType rightType = CheckRight(rightKey);
             //判读是否超级用户
            if (ExtendApplicationContext.Current.LoginUserContext.IsManager)
            {
                return rightType;
            }


            //获取手术表
            AnesInformations.OperationMasterDataTable operationMasterDataTable = new AnesthesiaSheetDA().GetOperationMaster(ExtendApplicationContext.Current.PatientContext.PatientID, ExtendApplicationContext.Current.PatientContext.VisitID, ExtendApplicationContext.Current.PatientContext.OperID);
            AnesInformations.AnesOperHandoverDataTable anesOperHandoverDataTable = new AnesthesiaSheetDA().GetAnesOperHandoverDataTable(ExtendApplicationContext.Current.PatientContext.PatientID, ExtendApplicationContext.Current.PatientContext.VisitID, ExtendApplicationContext.Current.PatientContext.OperID);
            
            AnesInformations.OperationMasterRow operationMasterRow = null ;
            AnesInformations.AnesOperHandoverRow anesOperHandoverRow = null ;
            if (operationMasterDataTable != null && operationMasterDataTable.Count >= 1)
            {
                operationMasterRow = operationMasterDataTable[0];
            }
            if (anesOperHandoverDataTable != null && anesOperHandoverDataTable.Count >= 1)
            {
                anesOperHandoverRow = anesOperHandoverDataTable[0];
            }
            try
            {
                //检查是否为 麻醉医生、手术医生
                if (operationMasterRow != null)
                {

                    bool find = false;
                    if (!find && !operationMasterRow.IsANES_DOCTORNull() && (IsLoginUser(operationMasterRow.ANES_DOCTOR)))
                    {
                        find = true;
                    }
                    else if (!find && !operationMasterRow.IsSECOND_ANES_DOCTORNull() && (IsLoginUser(operationMasterRow.SECOND_ANES_DOCTOR)))
                    {
                        find = true;
                    }
                    else if (!find && !operationMasterRow.IsTHIRD_ANES_DOCTORNull() && (IsLoginUser(operationMasterRow.THIRD_ANES_DOCTOR)))
                    {
                        find = true;
                    }
                    else if (!find && !operationMasterRow.IsANES_ASSISTANTNull() && (IsLoginUser(operationMasterRow.ANES_ASSISTANT)))
                    {
                        find = true;
                    }
                    else if (!find && !operationMasterRow.IsSECOND_ANES_ASSISTANTNull() && (IsLoginUser(operationMasterRow.SECOND_ANES_ASSISTANT)))
                    {
                        find = true;
                    }
                    if (!find)
                    {
                        //检查是否为 交班医生
                        if (anesOperHandoverRow != null)
                        {
                            if (!find && !anesOperHandoverRow.IsFIRST_ANES_DOCTORNull() && (IsLoginUser(anesOperHandoverRow.FIRST_ANES_DOCTOR)))
                            {
                                find = true;
                            }
                            else if (!find && !anesOperHandoverRow.IsSECOND_ANES_DOCTORNull() && (IsLoginUser(anesOperHandoverRow.SECOND_ANES_DOCTOR)))
                            {
                                find = true;
                            }
                        }
                        if (!find)
                        {
                            rightType = PermissionContext.RightType.Browse;
                        }
                    }

                }
                else//麻醉主记录为空
                {
                    rightType = PermissionContext.RightType.Browse;
                }

                

                ////如果有修改权限，判断有没有文书打印后修改权限
                //if ( !checkPrint &&  ((rightType & PermissionContext.RightType.Modify) == PermissionContext.RightType.Modify))
                //{
                //    PermissionContext.RightType modifyPrintedDocRightType = CheckRight(PermissionContext.ModifyPrintedDoc);
                //    {
                //        if (!((modifyPrintedDocRightType & PermissionContext.RightType.Modify) == PermissionContext.RightType.Modify)) //如果没有 文书打印后修改权限
                //        {



                //            decimal count = DataContext.GetCurrent().GetAnesPrintRecordCount(false, rightKey);
                //            if (count > 0)
                //            {
                //                rightType = PermissionContext.RightType.Browse;
                //            }
                //        }
                    
                //    }
                //}
               

            
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rightType;
        }



        public override bool CheckModifyPrintedDoc()
        {
            return CheckModifyRight(PermissionContext.ModifyPrintedDoc);
        }
        #region "打印后权限控制"




        #endregion
      
    }
}
