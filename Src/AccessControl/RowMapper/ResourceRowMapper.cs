using System;
using System.Collections.Generic;
using System.Text;
using Wis.AccessControl.Entity;
using Wis.AccessControl.Configuration;
using System.Data;
using Newtonsoft.Json;
using iMedical.CommonLib.SimpleDataAccessObject;

namespace Wis.AccessControl.RowMapper
{
    public class ResourceRowMapper:IRowMapper<Resource>
    {
        #region IRowMapper<Resource> 成员

        public Resource MapRow(IDataReader dataReader)
        {
            Resource resource = new Resource(RowMapperHelper.GetString(dataReader, "RESOURCE_ID"));
            resource.Name = RowMapperHelper.GetString(dataReader, "RESOURCE_NAME");
            resource.AppFlag = RowMapperHelper.GetString(dataReader, "APP_FLAG");
            resource.ResourceIdentifier = RowMapperHelper.GetString(dataReader, "RESOURCE_IDENTIFIER");
            resource.ResourceType = (ResourceType)RowMapperHelper.GetInt32(dataReader, "RESOURCE_TYPE");
            resource.ParentID = RowMapperHelper.GetString(dataReader, "PARENT_ID");
            resource.SortIndex = RowMapperHelper.GetInt32(dataReader, "SORT_INDEX");
            RowMapperHelper.FillExtendInfo(dataReader, resource);
            return resource;
        }
        #endregion
    }
}
