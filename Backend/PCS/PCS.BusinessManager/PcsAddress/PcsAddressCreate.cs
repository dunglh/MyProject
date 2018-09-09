using PCS.BusinessManager.Base;
using PCS.DAO.Base;
using PCS.EFMODEL.DataModels;
using DungLH.Util.Backend.MANAGER;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;

namespace PCS.BusinessManager.PcsAddress
{
    partial class PcsAddressCreate : BusinessBase
    {
		private List<Address> recentPcsAddresss = new List<Address>();
		
        internal PcsAddressCreate()
            : base()
        {

        }

        internal PcsAddressCreate(CommonParam paramCreate)
            : base(paramCreate)
        {

        }

        internal bool Create(Address data)
        {
            bool result = false;
            try
            {
                bool valid = true;
                PcsAddressCheck checker = new PcsAddressCheck(param);
                valid = valid && checker.VerifyRequireField(data);
                if (valid)
                {
					if (!DAOWorker.PcsAddressDAO.Create(data))
                    {
                        BugUtil.SetBugCode(param, LibraryBug.Bug.Enum.PcsAddress_ThemMoiThatBai);
                        throw new Exception("Them moi thong tin PcsAddress that bai." + LogUtil.TraceData("data", data));
                    }
                    this.recentPcsAddresss.Add(data);
                    result = true;
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                result = false;
            }
            return result;
        }
		
		internal void RollbackData()
        {
            if (IsNotNullOrEmpty(this.recentPcsAddresss))
            {
                if (!new PcsAddressTruncate(param).TruncateList(this.recentPcsAddresss))
                {
                    LogSystem.Warn("Rollback du lieu PcsAddress that bai, can kiem tra lai." + LogUtil.TraceData("recentPcsAddresss", this.recentPcsAddresss));
                }
            }
        }
    }
}