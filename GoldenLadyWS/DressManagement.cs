using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Web.Services;
using GoldenLady.Extension;
using GoldenLady.Global;
using GoldenLady.Standard.Dress;
using GoldenLady.Utility;
using GoldenLadyWS.PMS_Service;

namespace GoldenLadyWS
{
    /// <summary>
    /// 用于礼服管理的数据库操作方法集
    /// </summary>
    public class DressManagement : ErpService
    {
        private static DressManagement _theInstance;
        private DressManagement() { }

        /// <summary>
        /// 唯一实例
        /// </summary>
        internal static DressManagement Instance
        {
            get { return _theInstance ?? (_theInstance = new DressManagement()); }
        }

        /// <summary>
        /// 添加场馆
        /// </summary>
        /// <param name="venue">场馆</param>
        [WebMethod]
        public void NewVenue(Venue venue)
        {
            ExecuteNonQuery(string.Format(@"
            INSERT INTO D_Venue([Name], [DepartmentNo], [Disabled], [Description], [Create], [CreateDate])
            VALUES('{0}', '{1}', '{2}', '{3}', '{4}', GETDATE())", venue.Name, venue.DepartmentNo, venue.Disabled, venue.Description, Information.CurrentUser.EmployeeNO));
        }
        /// <summary>
        /// 添加场馆照片
        /// </summary>
        /// <param name="venueNo">场馆编号</param>
        /// <param name="files">场馆照片文件</param>
        [WebMethod]
        public void NewVenuePhoto(string venueNo, IEnumerable<FileSHA1> files)
        {
            if (files.Any())
            {
                StringBuilder sb = new StringBuilder(@"
                INSERT INTO D_VenuePhoto(VenueNo, PhotoPath, SHA1, [Create], CreateDate)
                VALUES");
                foreach (FileSHA1 file in files)
                {
                    sb.Append(string.Format(@"
                    ('{0}', '{1}', '{2}', '{3}', GETDATE()),", venueNo, file.FilePath, file.SHA1, Information.CurrentUser.EmployeeNO));
                }
                sb.Length -= 1; // 去掉末尾逗号

                ExecuteNonQuery(string.Format(@"
                BEGIN TRAN TranSave
                DECLARE @errCount INT = 0
                BEGIN TRY {0}
                END TRY
                BEGIN CATCH
                    SET @errCount = @errCount + 1
                END CATCH
                IF(@errCount > 0) BEGIN
	                ROLLBACK TRAN TranSave

                    DECLARE @ErrorMessage NVARCHAR(4000)= ERROR_MESSAGE()
                    DECLARE @ErrorState INT = ERROR_STATE()
                    RAISERROR (@ErrorMessage, 18, @ErrorState)
                END
                ELSE BEGIN
	                COMMIT TRAN TranSave
                END", sb));
            }
        }
        /// <summary>
        /// 获取场馆
        /// </summary>
        /// <returns>场馆列表</returns>
        [WebMethod]
        public IEnumerable<Venue> GetVenues()
        {
            using (DataSet ds = ExecuteQuery(@"SELECT * FROM D_Venue where [disabled] = 0 "))
            {
                try
                {
                    return from DataRow dr in ds.Tables[0].Rows select Venue.FromDataRow(dr);
                }
                catch
                {
                    MessageBoxEx.Error(string.Format(@"在数据库中查询场馆列表时遇到了问题导致失败！{0}方法名称：'DataAccess.GetVenues'", Environment.NewLine));
                }
                return new Venue[] { };
            }
        }
        /// <summary>
        /// 删除场馆
        /// </summary>
        /// <param name="venueNo">场馆编号</param>
        [WebMethod]
        public void DeleteVenue(string venueNo)
        {
            ExecuteNonQuery(string.Format(@"
DELETE FROM D_Venue WHERE VenueNo = '{0}'
Insert into Dress_Log(DressBarCode,DressStatus,LogNotes,OperatePeople,OperateTime) values('{0}','场馆删除','','{1} ',GETDATE())", venueNo,Information.CurrentUser.EmployeeNO2));
        }
        /// <summary>
        /// 检测场馆是否已存在
        /// </summary>
        /// <param name="newVenue">准备新建的场馆对象</param>
        /// <returns>存在返回true，不存在返回false</returns>
        [WebMethod]
        public bool IsVenueExists(Venue newVenue)
        {
            return ExecuteScalar(string.Format(@"SELECT 1 FROM D_Venue WHERE [DepartmentNo] = '{0}' OR [Name] = '{1}'", newVenue.DepartmentNo, newVenue.Name)).SafeDbBoolean();
        }

        /// <summary>
        /// 更新场馆信息
        /// </summary>
        /// <param name="venue">要更新的场馆对象</param>
        [WebMethod]
        public void UpdateVenue(Venue venue)
        {
            ExecuteNonQuery(string.Format(@"UPDATE D_Venue SET 
                                                                        [Name] = '{0}',
                                                                        [Disabled] = '{1}',
                                                                        [Description] = '{2}'
                                                                        WHERE [ID] = {3}", venue.Name, venue.Disabled, venue.Description, venue.ID));
        }
        /// <summary>
        /// 批量删除场馆照片
        /// </summary>
        /// <param name="photoPaths">照片路径</param>
        [WebMethod]
        public void DeleteVenuePhotos(IEnumerable<string> photoPaths)
        {
            IEnumerable<string> enumerable = photoPaths as string[] ?? photoPaths.ToArray();
            if (enumerable.Any())
            {
                ExecuteQuery(string.Format(@"DELETE FROM D_VenuePhoto WHERE PhotoPath IN ('{0}')", string.Join("','", enumerable)));
            }
        }
        /// <summary>
        /// 检测风格是否已存在
        /// </summary>
        /// <param name="theme">准备新建的风格对象</param>
        /// <returns>存在返回true，不存在返回false</returns>
        [WebMethod]
        public bool IsThemeExists(Theme theme)
        {
            return ExecuteScalar(string.Format(@"SELECT 1 FROM D_Theme WHERE Name = '{0}' AND VenueID = {1}", theme.Name, theme.VenueID)).SafeDbBoolean();
        }
        /// <summary>
        /// 获取下一个风格编号（用于添加风格）
        /// </summary>
        /// <returns>下一个风格编号</returns>
        [WebMethod]
        public string GetNextThemeNo()
        {
            return ExecuteScalar(@"SELECT 'Theme_' + RIGHT('000' + CAST(ISNULL(MAX(RIGHT(ThemeNO, 4)), '0000') + 1 AS VARCHAR),4) FROM D_Theme").SafeDbString();
        }
        /// <summary>
        /// 添加风格
        /// </summary>
        /// <param name="theme">风格</param>
        [WebMethod]
        public void NewTheme(Theme theme)
        {
            ExecuteNonQuery(string.Format(@"
            INSERT INTO D_Theme(Name, VenueID, [Disabled], [Description], [Create], CreateDate)
            VALUES('{0}', {1}, '{2}', '{3}', '{4}', GETDATE())", theme.Name, theme.VenueID, theme.Disabled, theme.Description, Information.CurrentUser.EmployeeNO));
        }
        /// <summary>
        /// 获取风格
        /// </summary>
        /// <returns>风格列表</returns>
        [WebMethod]
        public IEnumerable<Theme> GetThemes()
        {
            using (DataSet ds = ExecuteQuery(@"SELECT * FROM D_Theme"))
            {
                try
                {
                    return from DataRow dr in ds.Tables[0].Rows select Theme.FromDataRow(dr);
                }
                catch
                {
                    MessageBoxEx.Error(string.Format(@"在数据库中查询风格列表时遇到了问题导致失败！{0}方法名称：'DataAccess.GetThemes'", Environment.NewLine));
                }
                return new Theme[] { };
            }
        }
        /// <summary>
        /// 获取场馆信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Theme> GetThemes(int venue)
        {
            using (DataSet ds = ExecuteQuery(string.Format("select * from  D_Theme where VenueID = '{0}' and  Disabled = 0", venue)))
            {
                try
                {
                    return from DataRow dr in ds.Tables[0].Rows select Theme.FromDataRow(dr);
                }
                catch
                {
                    MessageBoxEx.Error(string.Format(@"在数据库中查询风格列表时遇到了问题导致失败！{0}方法名称：'DataAccess.GetThemes'", Environment.NewLine));
                }
                return new Theme[] { };
            }
        }
        /// <summary>
        /// 获取所属于指定场馆的风格
        /// </summary>
        /// <param name="venue"></param>
        /// <returns>风格列表</returns>
        [WebMethod]
        public IEnumerable<Theme> GetThemes(Venue venue)
        {
            using (DataSet ds = ExecuteQuery(string.Format(@"SELECT * FROM D_Theme WHERE VenueID = {0}", venue.ID)))
            {
                try
                {
                    return from DataRow dr in ds.Tables[0].Rows select Theme.FromDataRow(dr);
                }
                catch
                {
                    MessageBoxEx.Error(string.Format(@"在数据库中查询风格列表时遇到了问题导致失败！{0}方法名称：'DataAccess.GetThemes'", Environment.NewLine));
                }
                return new Theme[] { };
            }
        }
        /// <summary>
        /// 更新风格信息
        /// </summary>
        /// <param name="theme">要更新的风格对象</param>
        [WebMethod]
        public void UpdateTheme(Theme theme)
        {
            ExecuteNonQuery(string.Format(@"UPDATE D_Theme SET 
                                                                        [Name] = '{0}',
                                                                        [Disabled] = '{1}',
                                                                        [Description] = '{2}'
                                                                        WHERE [ID] = {3}", theme.Name, theme.Disabled, theme.Description, theme.ID));
        }
        /// <summary>
        /// 检测场景是否已存在
        /// </summary>
        /// <param name="scene">准备新建的场景对象</param>
        /// <returns>存在返回true，不存在返回false</returns>
        [WebMethod]
        public bool IsSceneExists(Scene scene)
        {
            return ExecuteScalar(string.Format(@"SELECT 1 FROM D_Scene WHERE Name = '{0}' AND ThemeID = {1}", scene.Name, scene.ThemeID)).SafeDbBoolean();
        }
        /// <summary>
        /// 添加场景
        /// </summary>
        /// <param name="scene">场景</param>
        [WebMethod]
        public void NewScene(Scene scene)
        {
            ExecuteNonQuery(string.Format(@"
            INSERT INTO D_Scene(Name, ThemeID, [Disabled], [Description], [Create], CreateDate)
            VALUES('{0}', {1}, '{2}', '{3}', '{4}', GETDATE())", scene.Name, scene.ThemeID, scene.Disabled, scene.Description, Information.CurrentUser.EmployeeNO));
        }

        /// <summary>
        /// 获取场景
        /// </summary>
        /// <param name="venueStirng"></param>
        /// <param name="filter">过滤参数</param>
        /// <returns>场景列表</returns>
        [WebMethod]
        public IEnumerable<Scene> GetScenes(string venueStirng, string filter = null)
        {
            using (DataSet ds = ExecuteQuery(string.Format(@"SELECT ds.ID,ds.Name,ds.Description,ds.Disabled,ds.ThemeID FROM D_Scene ds    
left join D_Theme dt on dt.ID = ds.ThemeID
left join D_Venue dv on dv.ID = dt.VenueID WHERE dv.Name = '" + venueStirng + "'  {0}", filter)))
            {
                try
                {
                    return from DataRow dr in ds.Tables[0].Rows select Scene.FromDataRow(dr);
                }
                catch
                {
                    MessageBoxEx.Error(string.Format(@"在数据库中查询场景列表时遇到了问题导致失败！{0}方法名称：'DataAccess.GetScenes'", Environment.NewLine));
                }
                return new Scene[] { };
            }
        }
        /// <summary>
        /// 获取所属于指定风格的场景
        /// </summary>
        /// <param name="theme">指定的风格</param>
        /// <returns>场景列表</returns>
        [WebMethod]
        public IEnumerable<Scene> GetScenes(Theme theme)
        {
            using (DataSet ds = ExecuteQuery(string.Format(@"SELECT * FROM D_Scene WHERE ThemeID = {0}", theme.ID)))
            {
                try
                {
                    return from DataRow dr in ds.Tables[0].Rows select Scene.FromDataRow(dr);
                }
                catch
                {
                    MessageBoxEx.Error(string.Format(@"在数据库中查询场景列表时遇到了问题导致失败！{0}方法名称：'DataAccess.GetScenes'", Environment.NewLine));
                }
                return new Scene[] { };
            }
        }
        /// <summary>
        /// 更新场景信息
        /// </summary>
        /// <param name="scene">要更新的场景对象</param>
        [WebMethod]
        public void UpdateScene(Scene scene)
        {
            ExecuteNonQuery(string.Format(@"UPDATE D_Scene SET 
                                                                        [Name] = '{1}',
                                                                        [Disabled] = '{2}',
                                                                        [Description] = '{3}'
                                                                        WHERE [ID] = {0}", scene.ID, scene.Name, scene.Disabled, scene.Description));
        }

        /// <summary>
        /// 获取场景照片文件列表
        /// </summary>
        /// <param name="scene">场景对象</param>
        /// <returns>照片文件列表</returns>
        [WebMethod]
        public IEnumerable<string> GetScenePhotoFiles(Scene scene)
        {
            string sql = string.Format(@"SELECT * FROM D_ScenePhoto dp left join D_Scene ds on ds.ID = SceneID 
   left join D_Theme dt on dt.ID = ds.ThemeID  WHERE SceneID = {0} ", scene.ID);
            using (DataSet ds = ExecuteQuery(sql))
            {
                try
                {
                    return from DataRow dr in ds.Tables[0].Rows select dr[@"PhotoPath"].SafeDbString();
                }
                catch (Exception ex)
                {
                    ReportError(@"查询照片文件列表", @"DataAccess.GetScenePhotoFiles", ex.Message);
                }
                return new string[] { };
            }
        }

        /// <summary>
        /// 获取场馆信息
        /// </summary>
        /// <param name="venueNo"></param>
        /// <returns></returns>
        public DataSet GetVenueInformation(string venueNo)
        {
            string sqlString = @"select * from  D_Scene  where SceneNo = '" + venueNo + "'";
            return ExecuteQuery(sqlString);
        }
        /// <summary>
        /// 获取风格详情
        /// </summary>
        /// <returns></returns>
        public DataSet GetThemeInformation(string venueNo, string themeNo)
        {
            string sqlString = @"select dt.ThemeNo, dt.ThemeName,ds.SceneNo, ds.SceneName,ds.VenueNO, dt.PhotoDirectory as ThemePhotoDirectory ,ds.PhotoDirectory as ScenePhotoDirectory  from  D_Theme dt 
left join D_Scene ds on ds.ThemeNo =dt.ThemeNo where 1=1 ";
            if (themeNo != null)
            {
                sqlString += " and dt.ThemeNO = '" + themeNo + "'";
            }
            sqlString += "  and ds.SceneNO = '" + venueNo + "'";
            return ExecuteQuery(sqlString);
        }
        /// <summary>
        ///通过关键字查询获取礼服详情
        /// </summary>
        /// <returns></returns>
        public DataSet GetDressSearchInformation(string dressBarCode)
        {
            string sqlString = string.Format(@"  select dp.DressNumbers, DressCustomCode, DressName, DressColor, DressCategories, DressBrand, DressOrnamental, DressUpperStyle, DressUpperMaterial, DressLowerStyle, DressLowerMaterial, DressUse, SuppliersNumbers, LevelOfNum, DressBuyer, area ,DressNumberOfUsedToday, NOtime, DressCostPrice, DressRentPrice, DressSalePrice, ChannelsToBuy, DressDescribe, DressNotes, DressImagePath, guanmin
  from Dress_newInformation dp left join Dress_Style ds on ds.DressNumbers = dp.DressNumbers  
  left join D_DressPhotos  dn on dn.DressBarCode = dp.DressBarCode where  (dp.DressBarCode = '{0}' or dp.DressCustomCode = '{0}') ", dressBarCode);
            return ExecuteQuery(sqlString);
        }

        /// <summary>
        /// 添加场景照片
        /// </summary>
        /// <param name="files">场景照片文件</param>
        /// <param name="scene">要添加照片的场景对象</param>
        [WebMethod]
        public void NewScenePhoto(IEnumerable<string> files, Scene scene)
        {
            if (!files.Any())
            {
                return;
            }

            StringBuilder sb = new StringBuilder(@"
                INSERT INTO D_ScenePhoto(SceneID, PhotoPath, [Create], CreateDate)
                VALUES");
            foreach (string file in files)
            {
                sb.Append(string.Format(@"
                    ('{0}', '{1}', '{2}', GETDATE()),", scene.ID, file, Information.CurrentUser.EmployeeNO));
            }
            sb.Length -= 1; // 去掉末尾逗号

            ExecuteNonQuery(string.Format(@"
                BEGIN TRAN TranSave
                DECLARE @errCount INT = 0
                BEGIN TRY {0}
                END TRY
                BEGIN CATCH
                    SET @errCount = @errCount + 1
                END CATCH
                IF(@errCount > 0) BEGIN
	                ROLLBACK TRAN TranSave

                    DECLARE @ErrorMessage NVARCHAR(4000)= ERROR_MESSAGE()
                    DECLARE @ErrorState INT = ERROR_STATE()
                    RAISERROR (@ErrorMessage, 18, @ErrorState)
                END
                ELSE BEGIN
	                COMMIT TRAN TranSave
                END", sb));
        }

        /// <summary>
        /// 删除场景照片
        /// </summary>
        /// <param name="files">文件路径</param>
        /// <param name="scene">要删除照片的场景对象</param>
        [WebMethod]
        public void DeleteScenePhoto(IEnumerable<string> files, Scene scene)
        {
            ExecuteNonQuery(string.Format(@" 
DELETE FROM D_ScenePhoto WHERE PhotoPath IN('{0}')
Insert into Dress_Log(DressBarCode,DressStatus,LogNotes,OperatePeople,OperateTime) values('','场景照片删除','{1}  所在风格ID {2}','{3} ',GETDATE())", string.Join(@"','", files), scene.Name, scene.ThemeID, Information.CurrentUser.EmployeeNO2));
        }

        /// <summary>
        /// 删除场景对象（照片会级联删除）
        /// </summary>
        /// <param name="scene">要删除的管理对象</param>
        [WebMethod]
        public void DeleteScene(Scene scene)
        {
            ExecuteNonQuery(string.Format(@" 
DELETE FROM D_Scene WHERE ID = {0}
Insert into Dress_Log(DressBarCode,DressStatus,LogNotes,OperatePeople,OperateTime) values('{0}','场景删除','场景名称：{1}  风格ID:{2}','{3}',GETDATE()) ", scene.ID, scene.Name,scene.ThemeID,Information.CurrentUser.EmployeeNO2));
        }
        /// <summary>
        /// 删除风格对象
        /// </summary>
        /// <param name="theme"></param>
        public void DeleteTheme(Theme theme)
        {
            ExecuteNonQuery(string.Format(@" 
DELETE FROM D_Theme WHERE ID = {0}
Insert into Dress_Log(DressBarCode,DressStatus,LogNotes,OperatePeople,OperateTime) values('{0}','风格删除','风格名称：{1}','{2}',GETDATE())", theme.ID,theme.Name,Information.CurrentUser.EmployeeNO2));
        }

        /// <summary>
        /// 获取场馆管理对象
        /// </summary>
        /// <param name="venueNo">场馆编号</param>
        /// <returns>场馆管理，若未找到返回null</returns>
        [WebMethod]
        public Venue GetVenue(string venueNo)
        {
            using (DataSet ds = ExecuteQuery(string.Format(@"SELECT * FROM D_Venue WHERE VenueNo = '{0}'", venueNo)))
            {
                try
                {
                    return Venue.FromDataRow(ds.Tables[0].Rows[0]);
                }
                catch (Exception ex)
                {
                    ReportError(@"查询场馆信息", @"DataAccess.GetVenue", ex.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// 获取规则集
        /// </summary>
        /// <returns>规则集</returns>
        [WebMethod]
        public IEnumerable<RuleObject> GetRules()
        {
            using (DataSet ds = ExecuteQuery(@"SELECT * FROM Dress_Rule WHERE WhetherDelete = 0"))
            {
                try
                {
                    return from DataRow dr in ds.Tables[0].Rows select RuleObject.FromDataRow(dr);
                }
                catch (Exception ex)
                {
                    ReportError(@"查询规则集", @"DressManeger.GetRules", ex.Message);
                    return new RuleObject[] { };
                }
            }
        }

        /// <summary>
        /// 获取供应商
        /// </summary>
        /// <returns>供应商</returns>
        [WebMethod]
        public IEnumerable<Supplier> GetSuppliers()
        {
            using (DataSet ds = ExecuteQuery(@"SELECT * FROM Dress_Suppliers"))
            {
                try
                {
                    return from DataRow dr in ds.Tables[0].Rows select Supplier.FromDataRow(dr);
                }
                catch (Exception ex)
                {
                    ReportError(@"查询供应商", @"DressManeger.GetSuppliers", ex.Message);
                    return new Supplier[] { };
                }
            }
        }

        /// <summary>
        /// 获取档次规格
        /// </summary>
        /// <returns>档次规格</returns>
        [WebMethod]
        public IEnumerable<Level> GetLevels()
        {
            using (DataSet ds = ExecuteQuery(@"SELECT * FROM Dress_SmallOfLevel"))
            {
                try
                {
                    return from DataRow dr in ds.Tables[0].Rows select Level.FromDataRow(dr);
                }
                catch (Exception ex)
                {
                    ReportError(@"查询档次规格", @"DressManeger.GetLevels", ex.Message);
                    return new Level[] { };
                }
            }
        }

        /// <summary>
        /// 获取照片服务器路径
        /// </summary>
        /// <returns>照片服务器路径</returns>
        [WebMethod]
        public IEnumerable<string> GetServerPaths()
        {
            using (DataSet ds = ExecuteQuery(@"SELECT * FROM Dress_ImagePath"))
            {
                try
                {
                    return from DataRow dr in ds.Tables[0].Rows select dr["Path"].SafeDbString();
                }
                catch (Exception ex)
                {
                    ReportError(@"查询照片服务器路径", @"DressManeger.GetServerPaths", ex.Message);
                    return new string[] { };
                }
            }
        }

        /// <summary>
        /// 新建礼服
        /// </summary>
        /// <param name="dress">要新建的礼服对象</param>
        /// <param name="serverPhotoPath">礼服对应的服务器照片文件路径</param>
        [WebMethod]
        public void NewDress(Dress dress, string serverPhotoPath)
        {
            string content = string.Format(@"
            DECLARE @dressNo VARCHAR(50), @maxDressNo VARCHAR(50)
            SELECT @maxDressNo = MAX(DressNumbers) FROM Dress_Style
            IF(@maxDressNo IS NULL)
            BEGIN
	            SET @maxDressNo = '1000000000'
            END
            SET @dressNo = CONVERT(VARCHAR, CAST(@maxDressNo AS INT) + 1)

            INSERT INTO Dress_Style(DressNumbers, DressName, DressBrand, DressCategories, DressColor, DressUpperStyle, DressLowerStyle, DressUpperMaterial, DressLowerMaterial, DressOrnamental, DressDescribe)
            VALUES(@dressNo, '{0}', '{1}', '{2}', '{3}', '{4}','{5}','{6}','{7}','{8}','{9}')

            IF exists(select * from D_DressPhotos where DressBarCode = '{11}') 
            BEGIN
            UPDATE  D_DressPhotos  set  DressImagePath = '{10}'  where  DressBarCode = '{11}'
            END
            ELSE
            BEGIN
            INSERT INTO D_DressPhotos(DressBarCode,DressNumbers,DressImagePath) values('{11}',@dressNo,'{10}')
            END   
  
            INSERT INTO Dress_newInformation(DressBarCode, DressNumbers, SuppliersNumbers, area, DressUse, DressCostPrice, DressRentPrice, DressSalePrice, dressStatus, DressCurrentPosition, DressNumofUse, DressNumberOfUsedToday, DressNotes, CreationTime, Creator, DressCustomCode, DressBuyer, ChannelsToBuy, NOtime, DressOfShow, LevelOfNum ,guanmin) 
            VALUES(	'{11}', @dressNo,	'{12}',	'{13}',  '{14}',  {15},  {16}, {17}, '{18}', '{19}',	 0, {20}, '{21}', GETDATE(), '{22}', '{23}', '{24}', '{25}', {26}, '{27}', '{28}','{19}')

            INSERT INTO Dress_Log (DressBarCode, dressStatus, LogNotes, OperatePeople, OperateTime, department) 
            VALUES('{11}', '', '礼服建档', '{22}', GETDATE(), '{29}')",
                                           dress.TypeNo, dress.BrandName, dress.CategoryNo, dress.ColorName,
                                           dress.UpperStyleName, dress.LowerStyleName, dress.UpperMaterialName,
                                           dress.LowerMaterialName, dress.OrnamentalName, dress.Description,
                                           serverPhotoPath, dress.BarCode, dress.SupplierName, dress.AreaNo,
                                           dress.UseName, dress.CostPrice, dress.RentPrice, dress.SalePrice,
                                           dress.StatusName, dress.CurrentPositionName, dress.NumOfUsedToday,
                                           dress.Notes, Information.CurrentUser.EmployeeNO, dress.CustomCode,
                                           dress.BuyerName, dress.Source, dress.NOTime, dress.DressOfShow, dress.LevelNo,
                                           Information.CurrentUser.EmployeeDepartmentNO);

            string sql = string.Format(@"
            BEGIN TRAN TranSaveProducts
            DECLARE @errCount INT = 0
            BEGIN TRY {0}
            END TRY
            BEGIN CATCH
                SET @errCount = @errCount + 1
            END CATCH
            IF(@errCount > 0) BEGIN
	            ROLLBACK TRAN TranSaveProducts

                DECLARE @ErrorMessage NVARCHAR(4000)= ERROR_MESSAGE()
                DECLARE @ErrorState INT = ERROR_STATE()
                RAISERROR (@ErrorMessage, 18, @ErrorState)
            END
            ELSE BEGIN
	            COMMIT TRAN TranSaveProducts
            END", content);
            ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 修改礼服
        /// </summary>
        /// <param name="dress">要修改的礼服对象</param>
        /// <param name="serverPhotoPath">礼服对应的服务器照片文件路径</param>
        [WebMethod]
        public void OldDressModify(Dress dress, string serverPhotoPath)
        {
            string sql = string.Format(@"
               declare @DressNumbers  varchar(50)
               select @DressNumbers = DressNumbers  from  Dress_newInformation  where   DressBarCode = '{11}'
               UPDATE  Dress_newInformation  set  SuppliersNumbers = '{12}', area = '{13}', DressUse = '{14}', DressCostPrice = '{15}', DressRentPrice = '{16}', DressSalePrice ='{17}' , dressStatus = '{18}', DressCurrentPosition = '{19}',  DressNumberOfUsedToday = '{20}', DressNotes = '{21}', OperateTime = GETDATE() , OperatePeople = '{22}', DressCustomCode = '{23}', DressBuyer = '{24}', ChannelsToBuy = '{25}', NOtime ='{26}' , DressOfShow = '{27}', LevelOfNum = '{28}' ,guanmin = '{19}'  where  DressBarCode = '{11}'
               UPDATE  Dress_Style  set  DressName = '{0}', DressBrand = '{1}', DressCategories = '{2}', DressColor = '{3}', DressUpperStyle = '{4}', DressLowerStyle = '{5}', DressUpperMaterial = '{6}', DressLowerMaterial = '{7}', DressOrnamental = '{8}', DressDescribe = '{9}'  where  DressNumbers = @DressNumbers
               INSERT INTO Dress_Log (DressBarCode, dressStatus, LogNotes, OperatePeople, OperateTime, department)  VALUES('{11}', '礼服修改', '{23}', '{22}', GETDATE(), '{29}')
               IF exists(select * from D_DressPhotos where DressBarCode = '{11}') 
                   BEGIN
                   UPDATE  D_DressPhotos  set  DressImagePath = '{10}'  where  DressBarCode = '{11}'
                   END
               ELSE
                   BEGIN
                   INSERT INTO D_DressPhotos(DressBarCode,DressNumbers,DressImagePath) values('{11}',@DressNumbers,'{10}')
                   END      

                ", dress.TypeNo, dress.BrandName, dress.CategoryNo, dress.ColorName,
                dress.UpperStyleName, dress.LowerStyleName, dress.UpperMaterialName,
                dress.LowerMaterialName, dress.OrnamentalName, dress.Description,
                serverPhotoPath, dress.BarCode, dress.SupplierName, dress.AreaNo,
                dress.UseName, dress.CostPrice, dress.RentPrice, dress.SalePrice,
                dress.StatusName, dress.CurrentPositionName, dress.NumOfUsedToday,
                dress.Notes, Information.CurrentUser.EmployeeNO, dress.CustomCode,
                dress.BuyerName, dress.Source, dress.NOTime, dress.DressOfShow, dress.LevelNo,
                Information.CurrentUser.EmployeeDepartmentNO);
            ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 获取指定场景绑定的礼服条码
        /// </summary>
        /// <param name="scene">指定场景对象</param>
        /// <returns>绑定的礼服条码</returns>
        [WebMethod]
        public IEnumerable<string> GetDressBarCodes(Scene scene)
        {
            using (DataSet ds = ExecuteQuery(string.Format(@"SELECT * FROM D_SceneDress WHERE SceneID = {0}", scene.ID)))
            {
                try
                {
                    return from DataRow dr in ds.Tables[0].Rows select dr["DressBarCode"].SafeDbString();
                }
                catch (Exception ex)
                {
                    ReportError(@"查询礼服条码", @"DressManeger.GetDressBarCode", ex.Message);
                    return new string[] { };
                }
            }
        }
        /// <summary>
        /// 获取指定风格绑定的对象礼服条码
        /// </summary>
        /// <param name="theme">指定风格对象</param>
        /// <param name="typeId">对象类型规则编号</param>
        /// <returns>绑定的对象礼服条码</returns>
        [WebMethod]
        public IEnumerable<string> GetDressBarCodes(Theme theme, int typeId)
        {
            using (DataSet ds = ExecuteQuery(string.Format(@"SELECT * FROM D_ThemeDress WHERE ThemeID = {0} AND DressTypeID = {1}", theme.ID, typeId)))
            {
                try
                {
                    return from DataRow dr in ds.Tables[0].Rows select dr["DressBarCode"].SafeDbString();
                }
                catch (Exception ex)
                {
                    ReportError(@"查询礼服条码", @"DressManeger.GetDressBarCode", ex.Message);
                    return new string[] { };
                }
            }
        }
        /// <summary>
        /// 新建场景礼服匹配
        /// </summary>
        /// <param name="scene">场景对象</param>
        /// <param name="dressBarCode">礼服条码</param>
        [WebMethod]
        public void NewSceneDress(Scene scene, string dressBarCode)
        {
            ExecuteNonQuery(string.Format(@"
            IF NOT EXISTS(SELECT 1 FROM Dress_newInformation WHERE DressBarCode = '{1}')
                BEGIN
	                RAISERROR(13001, 18, 1)
                END
            ELSE
                BEGIN
                    IF NOT EXISTS(SELECT 1 FROM D_SceneDress WHERE DressBarCode = '{1}')
                      BEGIN
                      INSERT INTO D_SceneDress([SceneID], [DressBarCode], [Create], [CreateDate]) 
                      VALUES({0}, '{1}', '{2}', GETDATE())
                      END
                    ELSE
                      BEGIN
	                  RAISERROR('该条码已绑定', 18, 1)
                      END
                END", scene.ID, dressBarCode, Information.CurrentUser.EmployeeNO));
        }

        /// <summary>
        /// 移除场景礼服匹配
        /// </summary>
        /// <param name="scene">场景对象</param>
        /// <param name="dressBarCode">礼服条码</param>
        [WebMethod]
        public void DeleteSceneDress(Scene scene, string dressBarCode)
        {
            ExecuteNonQuery(string.Format(@"
DELETE FROM D_SceneDress WHERE SceneID = {0} AND DressBarCode = '{1}'
Insert into Dress_Log(DressBarCode,DressStatus,LogNotes,OperatePeople,OperateTime) values('{1}','场景匹配移除','场景名称：{2}','{3}',GETDATE())", scene.ID, dressBarCode,scene.Name,Information.CurrentUser.EmployeeNO2));
        }

        private static void ReportError(string work, string methodName, string errMessage)
        {
            MessageBoxEx.Error(string.Format(@"在数据库中{1}时遇到了问题导致失败！{0}方法名称：'{2}'{0}{3}", Environment.NewLine, work, methodName, errMessage));
        }

        /// <summary>
        /// 获取场景照片上传路径
        /// </summary>
        /// <returns>场景照片上传路径</returns>
        public IEnumerable<string> GetScenePhotoUploadPaths()
        {
            using (DataSet ds = ExecuteQuery(@"SELECT * FROM D_ScenePhotoPath"))
            {
                try
                {
                    return from DataRow dr in ds.Tables[0].Rows select dr["Path"].SafeDbString();
                }
                catch (Exception ex)
                {
                    ReportError(@"查询场景照片上传路径", @"DressManeger.GetScenePhotoUploadPaths", ex.Message);
                    return new string[] { };
                }
            }
        }
        /// <summary>
        /// 获取主题匹配所需要的类型（男士礼服，妆面）
        /// </summary>
        /// <returns>主题匹配所需要的类型</returns>
        public IEnumerable<RuleObject> GetThemeMatchTypes()
        {
            using (DataSet ds = ExecuteQuery(@"SELECT * FROM Dress_Rule WHERE RuleName IN ('妆面', '男士礼服') AND WhetherDelete = 0"))
            {
                try
                {
                    return from DataRow dr in ds.Tables[0].Rows select RuleObject.FromDataRow(dr);
                }
                catch (Exception ex)
                {
                    ReportError(@"查询主题匹配所需要的类型", @"DressManeger.GetThemeMatchTypes", ex.Message);
                    return new RuleObject[] { };
                }
            }
        }
        /// <summary>
        /// 新建风格匹配
        /// </summary>
        /// <param name="theme">风格对象</param>
        /// <param name="dressBarCode">礼服条码</param>
        /// <param name="typeId">性质规则编号</param>
        public void NewThemeDress(Theme theme, string dressBarCode, int typeId)
        {
            ExecuteNonQuery(string.Format(@"
            IF NOT EXISTS(SELECT 1 FROM Dress_newInformation WHERE DressBarCode = '{1}')
                BEGIN
	                RAISERROR(13001, 18, 1)
                END
            ELSE
                BEGIN
                    INSERT INTO D_ThemeDress([ThemeID], [DressBarCode], [DressTypeID], [Create], [CreateDate]) 
                    VALUES({0}, '{1}', {2}, '{3}', GETDATE())
                END", theme.ID, dressBarCode, typeId, Information.CurrentUser.EmployeeNO));
        }
        /// <summary>
        /// 删除风格匹配
        /// </summary>
        /// <param name="theme">风格对象</param>
        /// <param name="dressBarCode">礼服编号</param>
        /// <param name="typeId">性质规则编号</param>
        public void DeleteThemeDress(Theme theme, string dressBarCode, int typeId)
        {
            ExecuteNonQuery(string.Format(@"
DELETE FROM D_ThemeDress WHERE ThemeID = {0} AND DressBarCode = '{1}' AND DressTypeID = {2}
Insert into Dress_Log(DressBarCode,DressStatus,LogNotes,OperatePeople,OperateTime) values('{1}','风格匹配删除','风格名称：{3} 所在场馆ID {4}','{2}',GETDATE())", theme.ID, dressBarCode, typeId, theme.Name, theme.VenueID));
        }
        /// <summary>
        /// 获取跨馆预选
        /// </summary>
        /// <param name="venueID">场馆ID</param>
        /// <returns>跨馆预选设置记录</returns>
        public IEnumerable<CrossReservation> GetCrossReservations(int venueID)
        {
            using (DataSet ds = ExecuteQuery(string.Format(@"SELECT * FROM D_CrossReservation WHERE VenueID = {0}", venueID)))
            {
                try
                {
                    return from DataRow dr in ds.Tables[0].Rows select CrossReservation.FromDataRow(dr);
                }
                catch (Exception ex)
                {
                    ReportError(@"查询跨馆预选", @"DressManeger.GetCrossReservations", ex.Message);
                    return new CrossReservation[] { };
                }
            }
        }
        /// <summary>
        /// 新建跨馆选衣
        /// </summary>
        /// <param name="crossReservation">跨馆选衣设置</param>
        public void NewCrossReservation(CrossReservation crossReservation)
        {
            ExecuteNonQuery(string.Format(@"
            INSERT INTO D_CrossReservation(VenueID, CrossVenueID, CrossVenue)
            VALUES({0}, {1}, '{2}')", crossReservation.VenueID, crossReservation.CrossVenueID, crossReservation.CrossVenue));
        }
        /// <summary>
        /// 删除跨馆选衣
        /// </summary>
        /// <param name="crossReservation">跨馆选衣设置</param>
        public void DeleteCrossReservation(CrossReservation crossReservation)
        {
            ExecuteNonQuery(string.Format(@"
DELETE FROM D_CrossReservation WHERE ID = {0}
Insert into Dress_Log(DressBarCode,DressStatus,LogNotes,OperatePeople,OperateTime) values('','删除跨馆选衣','跨馆场馆名称：{1}','{2}',GETDATE())", crossReservation.ID, crossReservation.CrossVenueID,Information.CurrentUser.EmployeeNO2));
        }
        /// <summary>
        /// 礼服淘汰
        /// </summary>
        /// <param name="barcode">礼服条码</param>
        /// <param name="state"></param>
        /// <param name="notes"></param>
        public void EliminateDress(string barcode, string state, string notes)
        {
            ExecuteNonQuery(string.Format(@"UPDATE Dress_newInformation SET dressStatus = '{1}',OperatePeople = '{2}',OperateTime =GETDATE()  WHERE DressBarCode = '{0}'  
insert into Dress_Log (DressBarCode,dressStatus,OperatePeople,OperateTime,LogNotes) values ('{0}','{1}','{2}',GETDATE(),'{3}')
", barcode, state, Information.CurrentUser.EmployeeNO2, notes));
        }

        /// <summary>
        /// 礼服次数修改
        /// </summary>
        /// <param name="barcode"></param>
        /// <param name="dressCnt"></param>
        /// <param name="empId"></param>
        /// <param name="oldCnt"></param>
        public bool EliminateDressUseCout(string barcode, decimal dressCnt, string empId, string oldCnt)
        {
            return ExecuteNonQuery(
                string.Format(@"
UPDATE Dress_newInformation SET DressNumberOfUsedToday = '{1}' WHERE  DressBarCode = '{0}' 
insert into Dress_Log (DressBarCode,dressStatus,OperatePeople,OperateTime,LogNotes) values ('{0}','礼服修改','{2}',GETDATE(),'礼服次数修改由 {3} 改为 {1}')
", barcode, dressCnt, empId, oldCnt)) > 0;
        }

        /// <summary>
        /// 礼服用途修改
        /// </summary>
        /// <param name="barcode"></param>
        /// <param name="dressUse"></param>
        /// <param name="empId"></param>
        /// <param name="useage"></param>
        public bool EliminateDressUse(string barcode, string dressUse, string empId, string useage)
        {
            return ExecuteNonQuery(
                string.Format(@"
UPDATE Dress_newInformation SET DressUse = '{1}' WHERE  DressBarCode = '{0}' 
insert into Dress_Log (DressBarCode,dressStatus,OperatePeople,OperateTime,LogNotes) values ('{0}','礼服修改','{2}',GETDATE(),'礼服次数修改由 {3} 改为 {1}')
", barcode, dressUse, empId, useage)) > 0;
        }

        /// <summary>
        /// 更换礼服所在场馆
        /// </summary>
        /// <param name="barcode">礼服条码</param>
        /// <param name="area">场馆对象</param>
        /// <param name="areaName">场馆名称</param>
        /// <param name="oldVenueName"></param>
        /// <param name="empId"></param>
        /// <param name="departmentId"></param>
        public void ChangeArea(string barcode, RuleObject area, string areaName, string oldVenueName, string empId, string departmentId)
        {
            string guanmin = @"星光之城";
            if (areaName.StartsWith(@"湖畔公主馆") || areaName.StartsWith(@"纽约22"))
            {
                guanmin = areaName;
            }
            ExecuteNonQuery(string.Format(@"
UPDATE Dress_newInformation SET area='{1}', DressCurrentPosition = '{2}', guanmin = '{3}' WHERE DressBarCode = '{0}'
Insert into Dress_Log(DressBarCode,DressStatus,LogNotes,OperatePeople,OperateTime,department) values('{0}','礼服修改','将馆名由 {4} 改为 {3}','{5}',Getdate(),'{6}')
", barcode, area.RuleNo, areaName, guanmin, oldVenueName, empId, departmentId));
        }

        /// <summary>
        ///获取场景信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetSceneInfo(string themeId, string sceneId)
        {
            string sqlString = string.Format("select * ,ROW_NUMBER() OVER(PARTITION BY name ORDER BY themeId) as rowNum from D_Scene ds left join D_ScenePhoto dd on dd.SceneID = ds.ID   where  Disabled = 0  and photoPath is not null and  ThemeId  in('{0}') ", themeId);
            if (!string.IsNullOrEmpty(sceneId))
            {
                sqlString += string.Format(@" and SceneID = '{0}'", sceneId);
            }
            return ExecuteQuery(sqlString);
        }

        /// <summary>
        /// 获取礼服特征 上半身:50 大类:2
        /// </summary>
        /// <returns></returns>
        public DataSet GetDressStyle(string number)
        {
            string sSql = string.Format(@"select * from Dress_Rule where ParentRuleNumbers in('{0}') and WhetherDelete = 0 ", number);
            return ExecuteQuery(sSql);
        }

        /// <summary>
        ///礼服统计查询
        /// </summary>
        /// <param name="sqlString"></param>
        /// <returns></returns>
        public DataSet GetDressLogInfo(string sqlString)
        {
            string sSql = string.Format(@" select dl.DressBarCode,c.DressNumbers,dl.dressStatus,dl.OperateTime,dl.OperatePeople,guanmin,dr.RuleName,dr.RuleNumbers, dp.DressImagePath
from  Dress_Log dl left join Dress_newInformation c on c.DressBarCode = dl.DressBarCode 
left join Dress_Style d on c.DressNumbers=d.DressNumbers
left join Dress_Rule dr on dr.RuleNumbers = d.DressCategories
left join D_DressPhotos  dp on dp.DressBarCode = c.DressBarCode
where  c.dressStatus!='出售' and c.dressStatus!='淘汰' {0} Order by OperateTime desc", sqlString);
            return ExecuteQuery(sSql);
        }

        /// <summary>
        ///获取礼服详情
        /// </summary>
        /// <returns></returns>
        public DataSet GetDressInformation(string venueName, string themeName, string usetime, string dressId, List<string> styleDress)
        {
            string sqlString = string.Format(@"select distinct DressBarCode,DressCustomCode,DressNumbers,dressStatus,DressRentPrice,DressSalePrice,DressNumberOfUsedToday,DressOfShow,DressName,DressBrand,DressColor, DressUpperStyle, DressLowerStyle, DressOrnamental, DressImagePath, SceneID, DressBarUsedCnt, DressCurrentPosition, guanmin, ThemeName

from ( select  a.DressBarCode,a.DressNumbers,a.DressCustomCode, a.dressStatus,a.DressNumberOfUsedToday,a.DressOfShow,a.DressRentPrice,a.DressSalePrice, c.DressName, c.DressBrand,c.DressColor,c.DressUpperStyle,c.DressLowerStyle,

c.DressOrnamental,g.DressImagePath, ds.SceneID, dt.Name as ThemeName, ISNULL(ad.DressBarUsedCnt,0) as DressBarUsedCnt, a.DressCurrentPosition, a.guanmin

from Dress_newInformation a 

left join Dress_Style c on c.DressNumbers=a.DressNumbers

left join Dress_Rule h on h.RuleNumbers=c.DressCategories  

left join D_DressPhotos g on g.DressBarCode = a.DressBarCode  

left join D_SceneDress  ds on ds.DressBarCode = a.DressBarCode

left join D_Scene dd on dd.ID  = ds.SceneID

left join D_Theme dt on dt.ID = dd.ThemeID

left join ( select DressBarCode, isnull(COUNT(1),0) as DressBarUsedCnt from  Dress_ChoosedInfo  where datediff(dd, DressUseDate, '{0}') = 0 group by DressBarCode )  as  ad  on  ad.DressBarCode = a.DressBarCode
)  as  b  where (dressStatus like '%在库' or dressStatus like '%入库' or dressStatus = '拍照中')  and  DressName = '", usetime) + dressId + "' and  ThemeName = '" + themeName + "'  and  DressBarUsedCnt < DressNumberOfUsedToday  and  DressImagePath is not null  and  guanmin = '" + venueName + "' ";

            if (styleDress.ToArray().Length != 0)
            {
                sqlString += string.Format(" and  (DressUpperStyle in('{0}')  or DressLowerStyle in('{0}'))", string.Join("','", styleDress.ToArray()));
            }
            return ExecuteQuery(sqlString);
        }
        /// <summary>
        /// 判断礼服是否可用
        /// </summary>
        /// <param name="barcode"></param>
        /// <param name="useDate"></param>
        /// <returns></returns>
        public DataSet DressEnableUse(string barcode, string useDate)
        {
            string sSql = string.Format(@" select a.DressNumbers,a.DressBarCode,a.DressCustomCode,a.DressNumberOfUsedToday ,a.DressNumberOfUsedToday-ISNULL(b.DresssUsedCnt,0) as DressRemainCnt, ISNULL(b.DresssUsedCnt,0) as DresssUsedCnt, a.dressStatus from Dress_newInformation a 

left join (select DressBarCode,COUNT(1) as DresssUsedCnt from  Dress_ChoosedInfo  where  DressBarCode='{0}' and  DATEDIFF(DD,DressUseDate,'{1}')=0  group by DressBarCode) b on a.DressBarCode=b.DressBarCode  
        
where  a.DressBarCode = '{0}'  and  (dressStatus like '%在库%' or dressStatus like '%入库%' or dressStatus like '%拍照中%' or  dressStatus like '%外景出库%') ", barcode, useDate);

            return ExecuteQuery(sSql);
        }
        /// <summary>
        /// 礼服同穿
        /// </summary>
        /// <param name="barcode"></param>
        /// <param name="useDate"></param>
        /// <returns></returns>
        public DataSet GetSameChoosedDress(string barcode, string useDate)
        {
            string sSql = string.Format(@"select DressBarCode,DressEmployeeName,orderNo,CustomerName1,MobilePhone1,CustomerName2,MobilePhone2,DressUseDate from Dress_ChoosedInfo ds left join Customers ct on ct.customerNO = ds.CustomercsNO  where  DressBarCode='{0}' and  DATEDIFF(DD,DressUseDate,'{1}')=0  ", barcode, useDate);
            return ExecuteQuery(sSql);
        }

        /// <summary>
        /// 获取已选场景
        /// </summary>
        /// <returns></returns>
        public DataSet GetSceneChoosed(string orderNo, string content)
        {
            string sqlString = @" select  dp.SceneID ,dv.Name as VenueName ,orderNo, ShootDate,DressEmpName,CreateTime, dp.PhotoPath, d.Name as SceneName ,DepartmentNo, DressEmpNO  from  D_SceneChooseHistory  ds  
left join D_Scene  d on d.ID = ds.SceneID  
left join ( select * from (select ROW_NUMBER() over(PARTITION  BY SceneID  order by  SceneID) as RowNt,PhotoPath,SceneID from D_ScenePhoto) as aa where RowNt = 1) dp on ds.SceneID = dp.SceneID
left join D_Theme dt on dt.ID = d.ThemeID
left join D_Venue dv on dv.ID = dt.VenueID where 1=1 ";
            if (!string.IsNullOrEmpty(orderNo))
            {
                sqlString += string.Format(@" and  orderNo = '{0}'", orderNo);
            }
            if (!string.IsNullOrEmpty(content))
            {
                sqlString += string.Format(@" {0}", content);
            }
            return ExecuteQuery(sqlString);
        }
        /// <summary>
        /// 礼服师
        /// </summary>
        /// <returns></returns>
        public DataSet GetDressEmp(string departmentNo)
        {
            string sqlString = @"select EmployeeNO2,EmployeeName from Employee where EmployeeDuty in('Duty_20','Duty_21','Duty_21.1','Duty_22','Duty_25','Duty_26','Duty_26.5','Duty_27') and IsDelete = 0";
            if (!string.IsNullOrEmpty(departmentNo))
            {
                sqlString += string.Format(@" and DepartmentNO = '{0}' ", departmentNo);
            }
            return ExecuteQuery(sqlString);
        }

        /// <summary>
        /// 已选礼服查询
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public DataSet SearchDressChoosed(string str)
        {
            string sqlString = string.Format(@"select dc.DressBarCode, dc.orderNo,d.DepartmentName,d.DepartmentNo,dr.RuleName,ct.CustomerName1,ct.MobilePhone1,ct.CustomerName2,ct.MobilePhone2,dc.DressEmployeeName,dc.DressEmployeeNO,dc.DressUseDate,dc.CreateDate from Dress_ChoosedInfo dc 
left join Dress_newInformation dn on dn.DressBarCode = dc.DressBarCode
left join Dress_Style ds on ds.DressNumbers = dn.DressNumbers
left join Dress_Rule dr on dr.RuleNumbers = ds.DressCategories
left join Department d on d.DepartmentNO = dc.OperateDepartmentNO
left join Customers ct on ct.CustomerNO = dc.CustomercsNO
where 1=1  {0}  group by dc.DressBarCode, dc.orderNo,d.DepartmentName,d.DepartmentNo,dr.RuleName,ct.CustomerName1,ct.MobilePhone1,ct.CustomerName2,ct.MobilePhone2,dc.DressEmployeeName,dc.DressEmployeeNO,dc.DressUseDate,dc.CreateDate", str);
            return ExecuteQuery(sqlString);
        }
        /// <summary>
        /// 礼服师业绩
        /// </summary>
        /// <param name="sSql"></param>
        /// <returns></returns>
        public DataSet GetEmpDressAchieve(string sSql)
        {
            string sqlString = string.Format(@"select DressEmployeeNO,DressEmployeeName,COUNT(DressEmployeeNO) as DressBarSum from Dress_ChoosedInfo where 1=1  {0}  group by DressEmployeeNO,DressEmployeeName", sSql);
            return ExecuteQuery(sqlString);
        }
        /// <summary>
        /// 妆面信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetFaceInformation(string dressName, string[] themeId)
        {
            string sqlString = @" 
  select dp.DressImagePath,ds.DressName,dn.DressNumbers,dn.DressBarCode,dt.ThemeID from  D_DressPhotos dp  
left join  Dress_newInformation dn  on dn.DressBarCode = dp.DressBarCode 
left join  Dress_Style ds on ds.DressNumbers = dp.DressNumbers
left join  D_ThemeDress  dt on dt.DressBarCode = dn.DressBarCode  where DressName = '" + dressName + "' and  ThemeID in ('" + string.Join(",", themeId) + "')";
            return ExecuteQuery(sqlString);
        }
        /// <summary>
        /// 选中礼服、面妆、男装保存数据
        /// </summary>
        public bool ChoosedInsert(string dressBarCode, string orderNo, string employeeNo, string employeeName, string orderDepartmentNo, string customerNo, string useDate, string type)
        {
            string sqlString = string.Format(
@"
IF NOT EXISTS(select * from Dress_ChoosedInfo where  orderNo = '{1}' and  DressBarCode = '{0}')
BEGIN
INSERT INTO Dress_ChoosedInfo(DressBarCode,orderNo,DressEmployeeNO,DressEmployeeName,OperateDepartmentNO,CustomercsNO,DressUseDate,DressTypeID,CreateDate)  values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',GETDATE())                                               
END
ELSE
BEGIN
UPDATE Dress_ChoosedInfo set DressUseDate = '{6}',CreateDate = GETDATE() where  orderNo = '{1}' and DressBarCode = '{0}'
END
Insert into Dress_Log(DressBarCode,DressStatus,LogNotes,OperatePeople,OperateTime)  values('{0}','礼服出库','加入购物车 {2}','{3}',GETDATE())
", dressBarCode, orderNo, employeeNo, employeeName, orderDepartmentNo, customerNo, useDate, type);
            return ExecuteNonQuery(sqlString).SafeDbBoolean();
        }

        /// <summary>
        /// 删除已选礼服
        /// </summary>
        /// <param name="barcode"></param>
        /// <param name="sql"></param>
        /// <param name="orderNo"></param>
        /// <param name="empName"></param>
        /// <returns></returns>
        public bool DeleteChoosedDress(string barcode, string sql, string orderNo,string empName)
        {
            string sSql = string.Format(@"Delete Dress_ChoosedInfo  where  DressBarCode='{0}' and  orderNo = '{1}'  {2}
Insert into Dress_Log(DressBarCode,DressStatus,LogNotes,OperatePeople,OperateTime)  values('{0}','礼服入库','购物车礼服删除 {1}','{3}',GETDATE())", barcode, orderNo, sql, empName);
            return ExecuteNonQuery(sSql) > 1;
        }

        /// <summary>
        /// 礼服预选完成Orders表的更新
        /// </summary>
        /// <param name="orderNo"></param>
        /// <param name="dressAddress"></param>
        /// <param name="employeeNo"></param>
        /// <param name="useTime"></param>
        /// <param name="memery"></param>
        /// <param name="sceneStrings"></param>
        /// <param name="empName"></param>
        /// <returns></returns>
        public bool AddOrderDressInfo(string orderNo, string dressAddress, string employeeNo, string empName, string useTime, string memery, Dictionary<string, string> sceneStrings)
        {
            string sqlString = string.Format(@" Update orders set ClothesAddress = '{0}',ClothesEmployeeNO = '{1}',ClothesMemory = '{2}',ClothesDate = Getdate() where orderNo = '{3}'", dressAddress, employeeNo, memery, orderNo);

            foreach (var scene in sceneStrings)
            {
                int dex = scene.Key.LastIndexOf("_", StringComparison.Ordinal);
                string sceneName = scene.Key.Substring(dex + 1, scene.Key.Length - dex - 1);
                string sceneId = scene.Key.Substring(0, dex);
                sqlString += string.Format(@" IF NOT EXISTS(select * from  D_SceneChooseHistory  where orderNo = '{0}' and SceneID = '{3}' and ShootDate = '{5}')
BEGIN
insert into D_SceneChooseHistory(orderNo,DressEmpNO,DressEmpName,SceneID,SceneName,ShootDate)  values('{0}','{1}','{2}','{3}','{4}','{5}')
END  ", orderNo, employeeNo, empName, sceneId, sceneName, useTime);
            }
            return ExecuteNonQuery(sqlString).SafeDbBoolean();
        }

        /// <summary>
        /// 礼服库查询
        /// </summary>
        /// <returns></returns>
        public DataSet DressesManage(string dressBarCode)
        {
            string sSql = @"select c.DressBarCode,d.DressNumbers,c.guanmin, dr.RuleName, c.DressUse, c.dressStatus, dp.DressImagePath, dt.Name as Themename,c.DressNumberOfUsedToday,c.DressCustomCode
from Dress_newInformation c  
left join D_DressPhotos  dp on dp.DressBarCode = c.DressBarCode
left join Dress_Style d on c.DressNumbers=d.DressNumbers
left join Dress_Rule dr on dr.RuleNumbers = d.DressCategories
left join D_SceneDress ds on ds.DressBarCode = c.DressBarCode
left join D_Scene dd on dd.ID = ds.SceneID
left join D_Theme dt on dt.ID = dd.ThemeID
where  c.dressStatus != '淘汰' and  c.dressStatus != '出售' and (c.DressBarCode in('" + dressBarCode + "') or c.DressCustomCode in('" + dressBarCode + "'))";
            return ExecuteQuery(sSql);
        }

        /// <summary>
        /// 礼服状态变更
        /// </summary>
        /// <param name="dressBarCodesStateList"></param>
        /// <param name="state"></param>
        /// <param name="position"></param>
        /// <param name="operater"></param>
        /// <returns></returns>
        public bool UpdateDressState(Dictionary<string, string> dressBarCodesStateList, string state, string position, string operater)
        {
            string sSql = String.Format(@"Update Dress_newInformation set dressStatus = '{0}',DressCurrentPosition = '{1}',OperateTime = GETDATE(), OperatePeople = '{2}' where DressBarCode in('{3}')
                                        ", state, position, operater, string.Join("','", dressBarCodesStateList.Keys.ToArray()));
            sSql = dressBarCodesStateList.Aggregate(sSql, (current, dressBarcode) => current + string.Format(@"insert into Dress_Log (DressBarCode,dressStatus,LogNotes,OperatePeople,OperateTime) values ('{0}','{1}','{2}','{3}',GETDATE())     ", dressBarcode.Key.ToString(), state, "将礼服" + dressBarcode + "  由" + dressBarcode.Value.ToString() + "状态更改为" + state, operater));
            return ExecuteNonQuery(sSql).SafeDbBoolean();
        }

        /// <summary>
        /// 补拍礼服拍照时间同步
        /// </summary>
        /// <param name="orderNo"></param>
        /// <param name="dressBarcode"></param>
        /// <param name="empNo"></param>
        /// <param name="empName"></param>
        /// <param name="updatetime"></param>
        /// <returns></returns>
        public bool UpdateDressDate(string orderNo, string dressBarcode,string empNo, string empName,string updatetime)
        {
            string sSql = String.Format(@"  
  declare @OldDressEmpName varchar(30)
  select @OldDressEmpName = DressEmployeeName from Dress_ChoosedInfo where OrderNO = '{0}' and  DressBarCode = '{1}'
  Update Dress_ChoosedInfo set DressUseDate = '{3}',DressEmployeeNO = '{4}',DressEmployeeName = '{2}'  where OrderNO = '{0}' and  DressBarCode = '{1}'
  insert into Dress_Log(DressBarCode,DressStatus,LogNotes,OperatePeople,OperateTime) values('{1}','补拍同步','订单号：{0} 原礼服师：'+ @OldDressEmpName,'{2}',GETDATE())", orderNo, dressBarcode, empName, updatetime, empNo);
            return ExecuteNonQuery(sSql) > 1;
        }

        /// <summary>
        /// 礼服设置类别详情
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public DataSet GetSmallGoods(string type)
        {
            string sSql = @"select * from Dress_Config where ConfigType in('" + type + "')";
            return ExecuteQuery(sSql);
        }
        /// <summary>
        /// 礼服设置类别
        /// </summary>
        /// <returns></returns>
        public DataSet GetDressConfigType()
        {
            string sSql = @"select * from(select ROW_NUMBER() OVER(partition by ConfigType order by id) as CntNum, * from Dress_Config) a where CntNum = 1";
            return ExecuteQuery(sSql);
        }
        /// <summary>
        /// 删除基本信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="configValue"></param>
        /// <returns></returns>
        public bool DeleteDressConfig(string id,string configValue)
        {
            string sSql = string.Format(@"
Delete from Dress_Config where ID = '{0}' and  ConfigValue = '{1}'
Insert into Dress_Log(DressBarCode,DressStatus,LogNotes,OperatePeople,OperateTime)  values('{0}','删除基本信息','{0} {1}','{2}',GETDATE())", id, configValue,Information.CurrentUser.EmployeeNO2);
            return ExecuteNonQuery(sSql)>0;
        }
        /// <summary>
        /// 添加基本信息
        /// </summary>
        /// <param name="configType"></param>
        /// <param name="configValue"></param>
        /// <returns></returns>
        public bool AddDressConfig(string configType, string configValue)
        {
            string sSql = string.Format(@"Insert Into Dress_Config(ConfigType,ConfigValue) values('{0}','{1}')", configType, configValue);
            return ExecuteNonQuery(sSql) > 0;
        }
        /// <summary>
        /// 洗衣房获取清洗礼服
        /// </summary>
        /// <param name="venueNo"></param>
        /// <param name="state"></param>
        /// <param name="dateSql"></param>
        /// <returns></returns>
        public DataSet GetCleaningDress(string venueNo, string state, string dateSql)
        {
            string sSql = string.Format(@"select a.DressBarCode ,dressStatus ,e.EmployeeName ,OperateTime,a.DressCurrentPosition,a.guanmin, a.area, DressImagePath
from Dress_newInformation a 
left join Employee e on e.EmployeeNO=a.OperatePeople
left join D_DressPhotos dp on dp.DressBarCode = a.DressBarCode
where  a.dressStatus in('{0}') ", state);
            if (venueNo != string.Empty)
            {
                sSql += @" and a.area = '" + venueNo + "'";
            }
            if (!string.IsNullOrEmpty(dateSql))
            {
                sSql += dateSql;
            }
            return ExecuteQuery(sSql);
        }

        /// <summary>
        /// 删除误选礼服
        /// </summary>
        /// <param name="orderNo"></param>
        /// <param name="dressBarcode"></param>
        /// <param name="employeeName"></param>
        /// <returns></returns>
        public bool DeleteDressChoosed(string orderNo, string dressBarcode, string employeeName)
        {
            string sSql = string.Format(@" 
Delete from Dress_ChoosedInfo where  orderNo = '{0}' and   DressBarCode = '{1}'  and  DressEmployeeName = '{2}'
Insert into Dress_Log(DressBarCode,DressStatus,LogNotes,OperatePeople,OperateTime)  values('{1}','删除误选礼服','{0} {1}','{3}',GETDATE())", orderNo, dressBarcode, employeeName,Information.CurrentUser.EmployeeNO2);
            return ExecuteNonQuery(sSql) > 0;
        }

        /// <summary>
        /// 礼服盘点
        /// </summary>
        /// <param name="sqlString"></param>
        /// <param name="dateString"></param>
        /// <returns></returns>
        public DataSet GetAllDressInfo(string sqlString, string dateString)
        {
            string sSql = string.Format(@"   select dn.DressBarCode,dn.DressCustomCode, dn.DressNumbers,dn.CreationTime,ISNULL(UseCnt,0) as UseCnt, guanmin, area,ds.DressName, RuleNumbers, RuleName, DressUse , dressStatus,dt.Name as ThemeName, DressNumberOfUsedToday, DressRentPrice, DressSalePrice , ep.EmployeeName,el.EmployeeName as Creator, dn.OperateTime, dn.Area from Dress_newInformation  dn  
 left join Dress_Style ds on ds.DressNumbers = dn.DressNumbers
 left join Dress_Rule  dr on dr.RuleNumbers = ds.DressCategories
 left join D_SceneDress dsd on dsd.DressBarCode = dn.DressBarCode
 left join D_Scene dd on dd.ID = dsd.SceneID
 left join D_Theme dt on dt.ID = dd.ThemeID
 left join Employee ep on ep.EmployeeNO2 = dn.OperatePeople
 left join Employee el on el.EmployeeNO = dn.Creator
 left join (select COUNT(DressBarCode) as UseCnt, DressBarCode from Dress_ChoosedInfo where 1=1 {1} group by DressBarCode) as dc on dc.DressBarCode = dn.DressBarCode
where 1=1 {0}", sqlString, dateString);
            return ExecuteQuery(sSql);
        }

        /// <summary>
        /// 礼服取出
        /// </summary>
        /// <param name="dressBarcode"></param>
        /// <param name="empNo"></param>
        /// <param name="empName"></param>
        /// <param name="sState"></param>
        /// <param name="venueId"></param>
        /// <param name="notes"></param>
        /// <returns></returns>
        public bool DressOutOperate(string dressBarcode, string empNo, string empName, string sState, string venueId, string notes)
        {
            string sSql = string.Format(@"
IF NOT EXISTS (select *from D_DressInOut where DressBarCode = '{0}' and DressEmpNO = '{2}')
BEGIN 
INSERT INTO D_DressInOut(DressBarCode,DressState,DressEmpNO,DressEmpName,OperateTime) values('{0}','{1}','{2}','{3}',GETDATE())
Insert into Dress_Log(DressBarCode,DressStatus,LogNotes,OperatePeople,OperateTime,department) values('{0}','{1}','{5}','{2}',Getdate(),'{4}')
END
ELSE
BEGIN
UPDATE D_DressInOut set DressState = '{1}',DressEmpNO = '{2}',DressEmpName = '{3}',OperateTime = GETDATE() where DressBarCode = '{0}'
END", dressBarcode, sState, empNo, empName, venueId, notes);
            return ExecuteNonQuery(sSql).SafeDbBoolean();
        }
        /// <summary>
        /// 礼服送进
        /// </summary>
        /// <param name="dressBarcode"></param>
        /// <param name="empNo"></param>
        /// <param name="state"></param>
        /// <param name="departmentNo"></param>
        /// <param name="notes"></param>
        /// <returns></returns>
        public bool DressInOperate(string dressBarcode, string empNo, string state, string departmentNo, string notes)
        {
            string sSql = string.Empty;
            string[] dressBarCodelst = dressBarcode.Split(',');
            foreach (string dressBar in dressBarCodelst)
            {
                sSql += string.Format(@"
Insert into Dress_Log(DressBarCode,DressStatus,LogNotes,OperatePeople,OperateTime,department) values('{0}','{2}','{4}','{1}',Getdate(),'{3}')", dressBar, empNo, state, departmentNo, notes);
            }
            sSql += string.Format(@"
Delete from D_DressInOut where DressBarCode in('{0}') and  DressEmpNO = '{1}'", dressBarcode.Replace(",", "','"), empNo);
            return ExecuteNonQuery(sSql).SafeDbBoolean();
        }
        /// <summary>
        /// 查询礼服取出详情
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataSet GetDressInOut(string sql)
        {
            string sSql = string.Format(@"
  SELECT dd.DressBarCode,dd.DressState,dd.DressEmpNO,dd.DressEmpName,OperateTime,cs.CustomerName1,cs.MobilePhone1,cs.CustomerName2,cs.MobilePhone2,dc.DressUseDate,dp.DressImagePath
  FROM D_DressInOut  dd 
  left join Dress_ChoosedInfo dc on dc.DressBarCode = dd.DressBarCode and dc.DressEmployeeNO = dd.DressEmpNO and DATEDIFF(dd,dc.CreateDate,dd.OperateTime)=0
  left join D_DressPhotos dp on dp.DressBarCode = dd.DressBarCode
  left join Customers cs on cs.CustomerNO = dc.CustomercsNO
  where  1=1  {0}", sql);
            return ExecuteQuery(sSql);
        }

        /// <summary>
        /// 查询礼服取出记录
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="area">所在场馆</param>
        /// <returns></returns>
        public DataSet GetDressInOutLog(string sql, string area)
        {
            string sSql = string.Format(@"
with DressLog as
(select * from Dress_Log where 1=1 {0})
select dl.DressBarCode,dl.DressStatus as DressState,dl.OperatePeople as DressEmpNO,el.EmployeeName as DressEmpName, dl.OperateTime, dn.area, dl.LogNotes from  DressLog dl 
  left join Dress_newInformation dn on dn.DressBarCode = dl.DressBarCode
  left join Employee el on el.EmployeeNO = dl.OperatePeople where 1=1 {1}
  Order by  dl.OperateTime desc", sql, area);
            return ExecuteQuery(sSql);
        }
        /// <summary>
        /// 预选出租查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataSet GetDressRentInfo(string sql)
        {
            string sSql = string.Format(@"
select o.orderNo,cs.CustomerNO,cs.CustomerName1,cs.CustomerName2,cs.MobilePhone1,cs.MobilePhone2,CONVERT(varchar(20),cs.MarryDate,23) as MarryDate ,CONVERT(varchar(20),cs.MarryDate2,23) as MarryDate2,st.SuiteTypeNO,st.SuiteTypeName,o.SuitePrice,CONVERT(varchar(20),o.OrderDate,23) as OrderDate, CONVERT(varchar(12), o.PreChooseDate, 111 ) as PreChooseDate,
em.EmployeeName as EmpOrderName,emp.EmployeeName as EmpOperteName,dp.DepartmentName,dr.Dress_OperatorTime,
dr.dress_ChooseDate,dr.Dress_ChooseRemak,dr.Dress_WhetherGiveUp,dr.reventionsCount,cash.CashNumber from  orders o 
left join Dress_Reventions dr on dr.OrderNO = o.OrderNO
left join Customers cs on cs.CustomerNO = o.CustomerNO
left join Employee em on em.EmployeeNO = o.OrderEmployeeNO
left join Department dp on dp.DepartmentNO = o.OrderDepartmentNO
left join Employee emp on emp.EmployeeNO = dr.dress_Operator
left join SuiteType st on st.SuiteTypeNO = o.SuiteTypeNO
left join Department dep on dep.DepartmentNO = dr.dress_ChoosePlace
left join (select orderNo,SUM(CashNumber) as CashNumber from CashSub join CashDetail on CashSub.CashNO=CashDetail.CashNO group by orderNo) cash on cash.orderNo = o.orderNo
where o.IsDelete = 0  {0}
", sql);
            return ExecuteQuery(sSql);
        }
        /// <summary>
        /// 出租追踪
        /// </summary>
        /// <param name="strOrder"></param>
        /// <returns></returns>
        public DataSet GetDressRentMemary(string strOrder)
        {
            string sSql = string.Format(@"select orderNo ,e.EmployeeName ,Dress_OperatorTime ,Dress_TraceRemark  from Dress_TraceTable t join Employee e on t.Dress_Operator=e.EmployeeNO2 where 1=1 {0}", strOrder);
            return ExecuteQuery(sSql);
        }
        /// <summary>
        /// 获得收银信息
        /// </summary>
        /// <param name="strOrder"></param>
        /// <returns></returns>
        public DataSet GetDressCashMemary(string strOrder)
        {
            string sSql = string.Format(@"select distinct d.CashPretextTypeName ,c.CashPretextName ,a.Size ,a.CashWay ,a.CashNumber ,e.EmployeeName as EmployeeName1 ,f.EmployeeName as EmployeeName2,b.CashDate 
from CashDetail a
left join CashSub b on a.CashNO=b.CashNO
left join CashPretext c on a.CashPretext=c.CashPretextNO
left join CashPretextType d on c.CashPretextTypeNO=d.CashPretextTypeNO
left join Employee e on e.EmployeeNO=b.BusinessEmployeeNO
left join Employee f on f.EmployeeNO=b.CashEmployeeNO
where 1=1 {0}
", strOrder);
            return ExecuteQuery(sSql);
        }

        /// <summary>
        /// 出租电子选衣查询礼服
        /// </summary>
        /// <param name="takeDressTime"></param>
        /// <param name="returnDressTime"></param>
        /// <param name="parentType"></param>
        /// <param name="type"></param>
        /// <param name="area"></param>
        /// <param name="keyes"></param>
        /// <param name="allDress">包含已经出租的礼服</param>
        /// <returns></returns>
        public DataSet GetDressesImage(DateTime? takeDressTime, DateTime? returnDressTime, string parentType, string type, string area, string keyes, bool allDress)
        {  //(datediff(dd,takeDressTime,'{0}')>=0 and datediff(dd,returnDressTime,'{0}')<=0) or (datediff(dd,takeDressTime,'{1}')>=0 and datediff(dd,returnDressTime,'{1}') <=0)
            string dateString = string.Empty;
            if (!allDress)
            {
                dateString += string.Format(@"
(
select * from Dress_newInformation a where not exists
(
select distinct DressBarCode from Dress_Hire b where
(
(datediff(dd,takeDressTime,'{0}')<=0 and datediff(dd,takeDressTime,'{1}')>=0) or (datediff(dd,returnDressTime,'{0}')<=0 and datediff(dd,returnDressTime,'{1}') >=0)
)
and  IsDelete =0  and  a.DressBarCode = b.DressBarCode
)
)", takeDressTime, returnDressTime);
            }
            else
            {
                dateString += @"Dress_newInformation";
            }
            string sSql = string.Format(@"
select info.DressBarCode ,DressImagePath,DressCustomCode,DressRentPrice,DressSalePrice,DressCustomCode from 
 {2}  as info 
left join Dress_Style ds on info.DressNumbers=ds.DressNumbers
left join D_DressPhotos dp on dp.DressBarCode = info.DressBarCode
left join Dress_Rule a on ds.DressCategories=a.RuleNumbers
left join Dress_Rule b on ds.DressName=b.RuleNumbers
where  dp.DressImagePath is not null  {0} {1} ", area, keyes, dateString);
            if (!string.IsNullOrEmpty(parentType))
            {
                sSql += parentType;
            }
            if (!string.IsNullOrEmpty(type))
            {
                sSql += type;
            }
            return ExecuteQuery(sSql);
        }

        /// <summary>
        /// 获取已预选出租的礼服
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        public DataSet GetRentedDressImage(string orderNo)
        {
            string sSql = string.Format(@"  
select OrderNO,do.batchNum,dh.DressBarCode,dp.DressImagePath,dn.DressCustomCode,DressRentPrice,DressSalePrice,Notes from Dress_OperateBatch do 
left join Dress_Hire dh on dh.batchNum = do.batchNum
left join Dress_newInformation dn on dn.DressBarCode = dh.DressBarCode
left join D_DressPhotos dp on dp.DressBarCode = dh.DressBarCode where dh.IsDelete = 0 and  OrderNO = '{0}'", orderNo);
            return ExecuteQuery(sSql);
        }

        /// <summary>
        /// 获取顾客信息
        /// </summary>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public DataSet GetOrderCustomer(string strKey)
        {
            string sSql =
                string.Format(@"select orderNo,c.CustomerNO,CustomerName1,CustomerName2,MobilePhone1,MobilePhone2 from Customers c
left join orders  o  on  o.CustomerNO = c.CustomerNO where c.IsDelete = 0 and o.IsDelete = 0 {0}", strKey);
            return ExecuteQuery(sSql);
        }
        /// <summary>
        /// 礼服出租信息保存
        /// </summary>
        public bool InsertDressRentInfo()
        {
            string sSql = string.Format(@"Insert into Dress_ControlTable(ControlTableType,Address,Date1,Date2,ColTitle,RowTime,Creater,CreateDate,AddressName,DressPeopleOfType) values('出租排单表','','','','','','','','','礼服师')");
            return ExecuteNonQuery(sSql) > 0;
        }
        /// <summary>
        /// 排单模板保存
        /// </summary>
        public bool InsertDressControlTable(string addressNo, DateTime date1, DateTime date2, string coltitle, string rowtime, string empNo, string addressName)
        {
            string sSql = string.Format(@"Insert into Dress_ControlTable(ControlTableType,Address,Date1,Date2,ColTitle,RowTime,Creater,CreateDate,AddressName,DressPeopleOfType) values('出租排单表','{0}','{1}','{2}','{3}','{4}','{5}',getdate(),'{6}','礼服师')", addressNo, date1, date2, coltitle, rowtime, empNo, addressName);
            return ExecuteNonQuery(sSql) > 0;
        }
        /// <summary>
        /// 获取出租排单模板
        /// </summary>
        /// <param name="address"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public DataSet GetRentColTable(string address, string date)
        {
            string sSql = string.Format(@"  select top 1 * from Dress_ControlTable where Address = '{0}' and DATEDIFF(dd,Date1,'{1}')>=0 and DATEDIFF(dd,Date2,'{1}')<=0 order by CreateDate desc", address, date);
            return ExecuteQuery(sSql);
        }
        /// <summary>
        /// 获取排单信息
        /// </summary>
        /// <param name="chooseTime"></param>
        /// <param name="departNo"></param>
        /// <returns></returns>
        public DataSet GetReventions(DateTime chooseTime, string departNo)
        {
            string sSql = string.Format(@" 
with cash as
(
select orderNo,SUM(CashNumber) as CashNumber from CashSub join CashDetail on CashSub.CashNO=CashDetail.CashNO
group by orderNo
)
select  b.CustomerNO,aa.orderNo,do.batchNum,cus.CustomerName1,cus.CustomerName2,Dress_ServicePeople,
Dress_ChoosePlace,Dress_ChooseDate,Dress_WhetherGiveUp ,Dress_GiveUpReason,Dress_ChooseRemak,
MobilePhone1,MobilePhone2,b.SuitePrice,chooseRow,chooseCol,Suite.SuiteName,CONVERT(varchar(20),b.OrderDate,111) OrderDate,
CONVERT(varchar(20),cus.MarryDate,111) MarryDate,CONVERT(varchar(20),cus.MarryDate2,111) MarryDate2,
aa.ChooseComplete,oe.EmployeeName OrderEmployee,od.DepartmentName OrderDepartment,e.EmployeeName OperatorName,
cash.CashNumber,aa.Dress_operator OperatorNO,de.EmployeeName DressEmployee,cus.MobilePhone1,cus.MobilePhone2,do.DressStylist,
IsArrive,ArriveTime,reventionsCount,b.OrderDate
from Dress_Reventions aa join Orders b on b.orderNo=aa.orderNo
join Customers cus on cus.CustomerNO=b.CustomerNO
left join cash on aa.orderNo=cash.orderNo 
left join Dress_OperateBatch do on do.OrderNO=aa.OrderNO
left join Employee e on aa.Dress_operator=e.EmployeeNO
left join Employee de on de.EmployeeNO=aa.DressEmployee
left join Employee oe on oe.EmployeeNO=b.OrderEmployeeNO
left join Department od on od.DepartmentNO=b.OrderDepartmentNO
left join Suite on Suite.SuiteNO=b.SuiteNO
where DATEDIFF(dd,dress_ChooseDate,'{0}') = 0 and  dress_ChoosePlace = '{1}'", chooseTime, departNo);
            return ExecuteQuery(sSql);
        }
        /// <summary>
        /// 出租排单表是否可排
        /// </summary>
        /// <param name="chooseTime"></param>
        /// <param name="departNo"></param>
        /// <returns></returns>
        public DataSet GetDressColEnable(DateTime chooseTime, string departNo)
        {
            string sSql = string.Format(@"select * from Dress_ControlTableDetail where DATEDIFF(dd,ChooseDate,'{0}')=0  and  ChooseAddress = '{1}'", chooseTime, departNo);
            return ExecuteQuery(sSql);
        }
        /// <summary>
        /// 出租排单表操作是否可排
        /// </summary>
        /// <param name="state"></param>
        /// <param name="addressNo"></param>
        /// <param name="rowIndex"></param>
        /// <param name="columnIndex"></param>
        /// <param name="choosedate"></param>
        /// <returns></returns>
        public bool UpdateModelUnEnable(int state, string addressNo, int rowIndex, int columnIndex, DateTime choosedate)
        {
            string sSql = string.Format(@" 
 IF exists (select * from  Dress_ControlTableDetail where DATEDIFF(dd,ChooseDate,'{4}') = 0 and ChooseAddress = '{1}' and RowIndex = '{2}' and ColumnIndex = '{3}') 
 Begin
 Update Dress_ControlTableDetail set isEnable = '{0}' where DATEDIFF(dd,ChooseDate,'{4}') = 0 and ChooseAddress = '{1}' and RowIndex = '{2}' and ColumnIndex = '{3}'
 End
 ELSE
 Begin
 Insert into Dress_ControlTableDetail(ChooseDate,ChooseAddress,RowIndex,ColumnIndex,IsEnable) values('{4}','{1}','{2}','{3}','{0}')
 End", state, addressNo, rowIndex, columnIndex, choosedate);
            return ExecuteNonQuery(sSql) > 0;
        }
        /// <summary>
        /// 出租排单表操作是否可排
        /// </summary>
        /// <param name="state"></param>
        /// <param name="addressNo"></param>
        /// <param name="rowIndex"></param>
        /// <param name="columnIndex"></param>
        /// <param name="choosedate"></param>
        /// <returns></returns>
        public bool UpdateReventions(int state, string addressNo, int rowIndex, int columnIndex, DateTime choosedate)
        {
            string sSql = string.Format(@" 
 IF exists (select * from  Dress_ControlTableDetail where DATEDIFF(dd,ChooseDate,'{4}') = 0 and ChooseAddress = '{1}' and RowIndex = '{2}' and ColumnIndex = '{3}') 
 Begin
 Update Dress_ControlTableDetail set isEnable = '{0}' where DATEDIFF(dd,ChooseDate,'{4}') = 0 and ChooseAddress = '{1}' and RowIndex = '{2}' and ColumnIndex = '{3}'
 End
 ELSE
 Begin
 Insert into Dress_ControlTableDetail(ChooseDate,ChooseAddress,RowIndex,ColumnIndex,IsEnable) values('{4}','{1}','{2}','{3}','{0}')
 End", state, addressNo, rowIndex, columnIndex, choosedate);
            return ExecuteNonQuery(sSql) > 0;
        }
        /// <summary>
        /// 获取订单排单信息
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        public DataSet GetOrderRent(string orderNo)
        {
            string sSql = string.Format(@"select dress_ServicePeople,d.DepartmentName as dress_ChoosePlace,dress_ChooseDate,Dress_ChooseRemak from Dress_Reventions a
left  join Department d on a.dress_ChoosePlace=d.DepartmentNO
where orderNo='{0}' ", orderNo);
            return ExecuteQuery(sSql);
        }

        /// <summary>
        /// 出租排单
        /// </summary>
        /// <param name="orderNo"></param>
        /// <param name="dressChoosePlace"></param>
        /// <param name="dressChooseDate"></param>
        /// <param name="chooseRow"></param>
        /// <param name="chooseCol"></param>
        /// <param name="dressServicePeople"></param>
        /// <param name="dressOperator"></param>
        /// <returns></returns>
        public bool SaveOrderTable(string orderNo, string dressChoosePlace, DateTime dressChooseDate, int chooseRow, int chooseCol, string dressServicePeople, string dressOperator)
        {
                string sSql = string.Format(@"
declare @batchNum varchar(20)
select @batchNum = REPLACE(MAX(batchNUm),'B','0')+1 FROM  Dress_OperateBatch
IF NOT EXISTS(select * from Dress_Reventions where OrderNO = '{0}')
BEGIN
INSERT INTO Dress_Reventions(OrderNO,Dress_ServicePeople,Dress_ChoosePlace,Dress_ChooseDate,ChooseRow,chooseCol,Dress_operator,Dress_OperatorTime,Dress_WhetherRevention,reventionsCount) VALUES('{0}','{5}','{1}','{2}','{3}','{4}','6',GETDATE(),'是','1')
END
ELSE
BEGIN
Update Dress_Reventions set Dress_ChoosePlace='{1}',Dress_ChooseDate='{2}',chooseRow='{3}',chooseCol='{4}',Dress_ServicePeople='{5}', Dress_operator='{6}',Dress_OperatorTime=GETDATE(),Dress_WhetherRevention='是',reventionsCount='1' where orderNo='{0}'
END

IF NOT EXISTS(select * from Dress_OperateBatch where  OrderNO = '{0}')
BEGIN
INSERT INTO Dress_OperateBatch(OrderNO,batchNum,DressStylist,OperatePeople,OperateTime) values('{0}','B'+@batchNum ,'{5}','{6}',GETDATE())
END
BEGIN
UPDATE Dress_OperateBatch set DressStylist = '{5}',OperatePeople = '{6}',OperateTime = GETDATE()  where  OrderNO = '{0}'
END
Insert into Logo(orderNo,DepartmentNO,EmployeeNO,[Create],CreateDate,State,LogoType,LogoContext) values('{0}','{1}','','{6}',GETDATE(),'0','出租排单','出租排单 {3}  {4}  {5}  {2}')
", orderNo, dressChoosePlace, dressChooseDate, chooseRow, chooseCol, dressServicePeople, dressOperator);
            return ExecuteNonQuery(sSql) > 0;
        }
        /// <summary>
        /// 取消出租排单
        /// </summary>
        /// <param name="orderNo"></param>
        /// <param name="dressChoosePlace"></param>
        /// <param name="dressServicePeople"></param>
        /// <param name="dressOperator"></param>
        /// <returns></returns>
        public bool CancelOrderTable(string orderNo, string dressChoosePlace, string dressServicePeople, string dressOperator)
        {
            string sSql = string.Format(
  @"update Dress_Reventions set Dress_ServicePeople='{0}',Dress_ChoosePlace='{1}',Dress_ChooseDate='',ChooseRow='',ChooseCol='',Dress_operator='{2}',Dress_OperatorTime=getdate(),Dress_WhetherRevention='' where orderNo='{3}'
   Insert into Logo(orderNo,DepartmentNO,[Create],CreateDate,State,LogoType,LogoContext) values('{3}','{1}','{2}',GETDATE(),'0','出租排单','出租排单取消： {0}')"
                                        , dressServicePeople, dressChoosePlace, dressOperator, orderNo);
            return ExecuteNonQuery(sSql) > 0;
        }
        /// <summary>
        /// 出租新增消费
        /// </summary>
        /// <param name="orderNo"></param>
        /// <param name="addMoney"></param>
        /// <param name="empId"></param>
        /// <returns></returns>
        public bool AddDressCost(string orderNo, decimal addMoney, string empId)
        {
            string sSql = string.Format(@"  
  IF not exists(select * from OrdersPayState where orderNo='{0}'
  BEGIN
  insert into OrdersPayState (orderNo,PayableSuite,ActualSuite,PayableShoot,ActualShoot,PayableClothes,ActualClothes,PayableChoose,ActualChoose,PayableGetGoods,ActuaGetGoods,PayableOther,ActuaOther) values ('{0}',0,0,0,0,'{1}','{1}',0,0,0,0,0,0)
  END
  ELSE  
  BEGIN 
  update OrdersPayState set PayableClothes=PayableClothes+{1},ActualClothes = ActualClothes+{1}  where orderNo='{0}'
  END
  Insert into Logo(orderNo,DepartmentNO,[Create],CreateDate,State,LogoType,LogoContext) values('{0}','金纱嫁衣馆','{2}',GETDATE(),'0','出租新增消费收款','消费金额：{1}')
", orderNo, addMoney, empId);
            return ExecuteNonQuery(sSql) > 0;
        }
        /// <summary>
        /// 获取订单礼服消费详情
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        public DataSet GetOrderCost(string orderNo)
        {
            string sSql = string.Format(@"
  if  not exists(select * from OrdersPayState where orderNo='{0}')
  BEGIN
  insert into OrdersPayState (orderNo,PayableSuite,ActualSuite,PayableShoot,ActualShoot,PayableClothes,ActualClothes,PayableChoose,ActualChoose,PayableGetGoods,ActuaGetGoods,PayableOther,ActuaOther) values ('{0}',0,0,0,0,'0',0,0,0,0,0,0,0)
  END
  select  orderNo,PayableClothes,ActualClothes from OrdersPayState where orderNo = '{0}'", orderNo);
            return ExecuteQuery(sSql);
        }
        /// <summary>
        /// 添加备注
        /// </summary>
        /// <param name="orderNo"></param>
        /// <param name="remarkContent"></param>
        /// <returns></returns>
        public bool AddOrderRemark(string orderNo, string remarkContent)
        {
//            declare @batchNum varchar(20)
//select @batchNum = REPLACE(MAX(batchNUm),'B','1') FROM  Dress_OperateBatch
//if exists(select * from Dress_OperateBatch where orderNo='{1}')
//Begin
//update Dress_OperateBatch set Notes='{0}'from Dress_OperateBatch where orderNo='{1}'
//End
//else
//Begin
//INSERT INTO Dress_OperateBatch(OrderNO,batchNum,Notes,OperateTime) values('{1}',@batchNum+1,'{0}',GETDATE())
//End
            string strSql = string.Format(@"
update Dress_Reventions set Dress_ChooseRemak='{0}' where orderNo='{1}'", remarkContent, orderNo);
            return ExecuteNonQuery(strSql) > 0;
        }

        /// <summary>
        /// 客人到店
        /// </summary>
        /// <param name="orderNo"></param>
        /// <param name="arriveTime"></param>
        /// <returns></returns>
        public bool CustomerArrive(string orderNo, DateTime arriveTime)
        {
            string strSql = string.Format("update Dress_Reventions set IsArrive=1,ArriveTime='{1}' where orderNo='{0}'", orderNo, arriveTime);
            return ExecuteNonQuery(strSql) > 0;
        }

        /// <summary>
        /// 出租预选加入购物车
        /// </summary>
        /// <param name="orderNo"></param>
        /// <param name="dressbarcode"></param>
        /// <param name="takedate"></param>
        /// <param name="marrydate"></param>
        /// <param name="returndate"></param>
        /// <param name="remarks"></param>
        /// <param name="rentPrice"></param>
        /// <param name="salePrice"></param>
        /// <param name="operteEmp"></param>
        /// <returns></returns>
        public bool InsertPreChoosed(string orderNo, string dressbarcode, DateTime takedate, DateTime marrydate, DateTime returndate, string remarks, decimal rentPrice, decimal salePrice, string operteEmp)
        {
            string sSql = string.Format(@"
  declare  @batchNum  varchar(20)
  if not exists (select * from Dress_OperateBatch where OrderNO = '{0}')
  Begin
  select @batchNum = REPLACE(MAX(batchNUm),'B','0')+1 FROM  Dress_OperateBatch
  INSERT INTO Dress_OperateBatch(OrderNO,batchNum) values('{0}','B'+@batchNum)
  End
  else
  Begin
  select @batchNum = batchNum from Dress_OperateBatch where OrderNO = '{0}'
  End
  Insert into Dress_Hire(batchNum,DressBarCode,takeDressTime,marryDtaTime,returnDressTime,remarks,SallType,RentOfPrice,SaleOfPrice,ReventionsCount) values(@batchNum ,'{1}','{2}','{3}','{4}','{5}','出租','{6}','{7}','1')
  insert into Dress_Log(DressBarCode,DressStatus,LogNotes,OperatePeople,OperateTime,department) values('{1}','出租预选','{0} {5}','{8}',GETDATE(),'金纱嫁衣馆')
", orderNo, dressbarcode, takedate, marrydate, returndate, remarks, rentPrice, salePrice, operteEmp);
            return ExecuteNonQuery(sSql) > 0;
        }
        /// <summary>
        /// 添加更新出租备注
        /// </summary>
        /// <param name="batchNum"></param>
        /// <param name="remarks"></param>
        /// <param name="dressBarcode"></param>
        /// <returns></returns>
        public bool AddDressRemarks(string batchNum, string remarks, string dressBarcode)
        {
            // Update Dress_Hire set remarks = '{2}' where batchNum = '{0}' and DressBarCode = '{1}' 单件备注
            // update Dress_OperateBatch set Notes='{2}' where batchNum='{0}' 总备注
            string sSql;
            if (string.IsNullOrEmpty(dressBarcode))
            {
                 sSql = string.Format(@" update  Dress_OperateBatch set  Notes='{1}'  where  batchNum='{0}' ", batchNum, remarks);
            }
            else
            {
                 sSql = string.Format(@" Update  Dress_Hire  set remarks = '{2}' where batchNum = '{0}' and DressBarCode = '{1}' ", batchNum, dressBarcode, remarks);   
            }
            return ExecuteNonQuery(sSql) > 0;
        }

        /// <summary>
        /// 删除购物车礼服
        /// </summary>
        /// <param name="orderNo"></param>
        /// <param name="dressBarcode"></param>
        /// <param name="operateEmp"></param>
        /// <returns></returns>
        public bool DeleteChoosed(string orderNo, string dressBarcode, string operateEmp)
        {
            string sSql = string.Format(@"  
declare @batchNum  varchar(20)
select @batchNum = batchNum from Dress_OperateBatch where OrderNO = '{0}'
update Dress_Hire set IsDelete = 1  where  batchNum = @batchNum and DressBarCode = '{1}'
insert into Dress_Log(DressBarCode,DressStatus,LogNotes,OperatePeople,OperateTime,department) values('{1}','出租预选删除','{0}','{2}',GETDATE(),'金纱嫁衣馆')", orderNo, dressBarcode, operateEmp);
            return ExecuteNonQuery(sSql) > 0;
        }

        /// <summary>
        /// 出租预选流程更新
        /// </summary>
        /// <param name="orderNo"></param>
        /// <param name="useFor"></param>
        /// <param name="txtRemark"></param>
        /// <param name="operateEmp"></param>
        /// <param name="dressStylist"></param>
        /// <returns></returns>
        public bool UpdateDressRentFinish(string orderNo, string useFor, string txtRemark, string operateEmp, string dressStylist)
        {
            string sSql =
                string.Format(@"  
UPDATE Dress_Reventions set IsArrive = 1,ArriveTime = GETDATE(),DressEmployee = '{1}',ChooseComplete = 1  where OrderNO = '{0}'
Update Dress_OperateBatch set UseFor = '{2}',Notes = '{3}',DressStylist = '{4}',OperateDepartment = '106',OperatePeople = '{1}',OperateTime = GETDATE()   where  OrderNO = '{0}'
insert into Dress_Log(DressBarCode,DressStatus,LogNotes,OperatePeople,OperateTime,department) values('{0}','出租预选完成','{0}  {4}  {3}  {2}','{1}',GETDATE(),'金纱嫁衣馆')", orderNo, operateEmp, useFor, txtRemark, dressStylist);
            return ExecuteNonQuery(sSql) > 0;
        }
        /// <summary>
        /// 查询出租顾客信息
        /// </summary>
        /// <param name="strContent"></param>
        /// <returns></returns>
        public DataSet GetRentCutomers(string strContent)
        {
            string sSql = string.Format(@"
select * from (select  a.batchNum,ROW_NUMBER() OVER (PARTITION BY a.batchNum ORDER By a.batchNum) as rowNum, b.Notes, b.OrderNO,isnull(b.BachNumStates,'未出件') as OrderState,c.CustomerName1 ,c.CustomerName2,c.MobilePhone1,c.MobilePhone2,CONVERT(varchar(12), a.marryDtaTime, 111 ) as marryDtaTime ,CONVERT(varchar(12), a.takeDressTime, 111 ) as takeDressTime,CONVERT(varchar(12), a.returnDressTime, 111 ) as returnDressTime, DressStylist, h.ArriveTime, h.Dress_ChooseRemak  from 
Dress_Hire a  
left join Dress_OperateBatch  b on a.batchNum=b.batchNum
left join  Dress_Reventions h on h.OrderNO=b.OrderNO 
left join  Orders e on e.OrderNO=b.OrderNO
left join  Customers c on c.CustomerNO=e.CustomerNO where a.IsDelete=0  {0}) as newTable where rowNum = 1", strContent);
            return ExecuteQuery(sSql);
        }
        /// <summary>
        /// 查询出租顾客已选礼服
        /// </summary>
        /// <param name="batchNum"></param>
        /// <returns></returns>
        public DataSet GetCustoRentDresses(string batchNum)
        {
            string sSql = string.Format(@"
select a.batchNum, a.dressBarCode,a.remarks, gg.RuleName, e.DressCustomCode, emp.EmployeeName,remarks,Notes, d.flowerNo,case when IsFriend=1 then '是' else '否' end as DressCompany, e.DressStatus, i.EmployeeName as OutOperate, a.OutOperatoerTime, j.EmployeeName as inOperate, a.BackOperatorTime, a.SallType, a.RentOfPrice, a.SaleOfPrice, a.ReventionsCount, b.OperateTime from 
Dress_Hire a 
left join  Dress_OperateBatch b on  a.batchNum=b.batchNum 
left join  Dress_FlowerOrder d on b.OrderNO=d.OrderNO 
left join  Dress_newInformation e on a.DressBarCode=e.DressBarCode 
left join  Dress_Style f on e.DressNumbers=f.DressNumbers 
left join  Dress_Rule g on  e.Area=g.RuleNumbers 
left join  Employee emp on emp.EmployeeNO=b.DressStylist 
left join  Dress_Reventions h on h.OrderNO=b.OrderNO 
left join Dress_Rule gg on gg.RuleNumbers=f.DressCategories
left join  Employee i on a.OutOperator=i.EmployeeNO2
left join Employee j on a.BackOperator=j.EmployeeNO2
where  a.IsDelete=0 and a.batchNum = '{0}' ", batchNum);
            return ExecuteQuery(sSql);
        }

        /// <summary>
        /// 查询出租顾客已选礼服
        /// </summary>
        /// <param name="strContent"></param>
        /// <returns></returns>
        public DataSet GetRenDresses(string strContent)
        {
            string sSql = string.Format(@"
select distinct a.batchNum,a.dressBarCode,b.OrderNO,c.CustomerName1,c.MobilePhone1,c.CustomerName2,c.MobilePhone2,CONVERT(varchar(20),takeDressTime,111) takeDressTime,CONVERT(varchar(20),marryDtaTime,111) marryDtaTime,CONVERT(varchar(20),returnDressTime,111) returnDressTime,gg.RuleName,
e.DressCustomCode,DressStylist,remarks,Notes, d.flowerNo ,case when IsFriend=1 then '是' else '否' end as DressCompany ,e.DressStatus,i.EmployeeName as OutOperate,a.OutOperatoerTime ,j.EmployeeName as InOperate,a.BackOperatorTime ,a.SallType ,a.RentOfPrice,a.SaleOfPrice ,a.ReventionsCount,b.OperateTime ,b.DressStylist ,e.DressNumbers 
from 
Dress_Hire a left join  Dress_OperateBatch b on  a.batchNum=b.batchNum 
LEFT join  V_OrderAndCustomers c on b.OrderNO=c.OrderNO 
left join  Dress_FlowerOrder d on b.OrderNO=d.OrderNO 
left join  Dress_newInformation e on a.DressBarCode=e.DressBarCode 
left join  Dress_Style f on e.DressNumbers=f.DressNumbers 
left join  Dress_Rule g on  e.Area=g.RuleNumbers 
left join Dress_Rule gg on gg.RuleNumbers=f.DressCategories
left join  Employee i on a.OutOperator=i.EmployeeNO2
left join Employee j on a.BackOperator=j.EmployeeNO2
where  a.IsDelete=0  {0}  order by a.batchNum ", strContent);
            return ExecuteQuery(sSql);
        }

        /// <summary>
        /// 出租出件
        /// </summary>
        /// <param name="orderNo"></param>
        /// <param name="batchNum"></param>
        /// <param name="dressbarcodes"></param>
        /// <param name="empId"></param>
        /// <param name="operateEmp"></param>
        /// <returns></returns>
        public bool UpdateRentOut(string orderNo, string batchNum, string dressbarcodes, string empId,string operateEmp)
        {
            string sSql = string.Format(@"
 update Dress_Hire set OutOperator='{3}',OutOperatoerTime=GETDATE() where batchNum='{1}' and  DressBarCode in({2})
 update Dress_OperateBatch set BachNumStates='出件' where OrderNO='{0}' and batchNum='{1}'
 update Dress_newInformation set OperatePeople='{5}',OperateTime=GETDATE(),DressStatus='出租' where  DressBarCode In({2})
 insert into Dress_Log(DressBarCode,DressStatus,LogNotes,OperatePeople,OperateTime,department) values('{0}','出租出件',{4},'{5}',GETDATE(),'金纱嫁衣馆')", orderNo, batchNum, dressbarcodes, empId, dressbarcodes.Replace("','", ","), operateEmp);
            return ExecuteNonQuery(sSql) > 0;
        }

        /// <summary>
        /// 出租回件
        /// </summary>
        /// <param name="orderNo"></param>
        /// <param name="batchNum"></param>
        /// <param name="dressbarcodes"></param>
        /// <param name="empId"></param>
        /// <param name="operateEmp"></param>
        /// <returns></returns>
        public bool UpdateRentBack(string orderNo, string batchNum, string dressbarcodes, string empId, string operateEmp)
        {
            string sSql = string.Format(@"
 update Dress_Hire set BackOperator='{3}',BackOperatorTime=GETDATE() where batchNum='{1}' and  DressBarCode in({2})
 update Dress_OperateBatch set BachNumStates='回件' where OrderNO='{0}' and batchNum='{1}'
 update Dress_newInformation set OperatePeople='{5}',OperateTime=GETDATE(), DressStatus='出租入库' where  DressBarCode In({2})
 insert into Dress_Log(DressBarCode,DressStatus,LogNotes,OperatePeople,OperateTime,department) values('{0}','出租回件',{4},'{5}',GETDATE(),'金纱嫁衣馆') ", orderNo, batchNum, dressbarcodes, empId, dressbarcodes.Replace("','", ","), operateEmp);
            return ExecuteNonQuery(sSql) > 0;
        }

        /// <summary>
        /// 出租顾客婚期确定
        /// </summary>
        /// <param name="marrydate"></param>
        /// <param name="customerNo"></param>
        /// <returns></returns>
        public bool UpdateMarrydate(DateTime marrydate,string customerNo)
        {
            string sSql = string.Format(@" Update Customers set MarryDate='{0}',RemarkOfMarryDate='{0}',MarryDate2=null where CustomerNO='{1}'", marrydate, customerNo);
            return ExecuteNonQuery(sSql) > 0;
        }

        /// <summary>
        /// 嫁衣馆出租最受欢迎礼服
        /// </summary>
        /// <param name="keys"></param>
        /// <param name="dateString"></param>
        /// <returns></returns>
        public DataSet FavouriteDresses(string keys, string dateString)
        {
            string sSql = string.Format(@"
select dn.DressBarCode,dn.DressNumbers,dn.DressCustomCode,dn.DressSalePrice,dn.CreationTime,dn.DressRentPrice,dn.DressStatus,Area, ISNULL(DressCnt,0) as DressCnt,dr.RuleNumbers,dr.RuleName,dr2.RuleName as RuleName2,dr2.RuleNumbers as RuleNumbers2, dn.Area  from Dress_newInformation dn
left join (select COUNT(DressBarCode) as DressCnt, DressBarCode  from  Dress_Hire where IsDelete = 0  {1} group by DressBarCode) dh on dh.DressBarCode = dn.DressBarCode
left join Dress_Style ds on ds.DressNumbers = dn.DressNumbers
left join Dress_Rule dr on dr.RuleNumbers = ds.DressCategories
left join Dress_Rule dr2 on dr2.RuleNumbers = ds.DressName
where dn.DressStatus !='淘汰' and  dn.DressStatus !='出售' and  dn.DressStatus !='丢失' {0}", keys, dateString);
            return ExecuteQuery(sSql);
        }
        /// <summary>
        /// 预选最受欢迎礼服
        /// </summary>
        /// <param name="keys"></param>
        /// <param name="dateString"></param>
        /// <returns></returns>
        public DataSet FavouriteShootDresses(string keys, string dateString)
        {
            string sSql = string.Format(@"
select dn.DressBarCode,dn.DressNumbers,dn.CreationTime,dn.DressStatus,Area,ISNULL(DressCnt,0) as DressCnt,dr.RuleNumbers,dr.RuleName,dr2.RuleName as RuleName2,dr2.RuleNumbers as RuleNumbers2  from Dress_newInformation dn
left join (select COUNT(DressBarCode) as DressCnt, DressBarCode  from  Dress_ChoosedInfo where 1=1 {1} group by DressBarCode) dh on dh.DressBarCode = dn.DressBarCode
left join Dress_Style ds on ds.DressNumbers = dn.DressNumbers
left join Dress_Rule dr on dr.RuleNumbers = ds.DressCategories
left join Dress_Rule dr2 on dr2.RuleNumbers = ds.DressName
where dn.DressStatus !='淘汰' and  dn.DressStatus !='出售' and  dn.DressStatus !='丢失' {0}", keys, dateString);
            return ExecuteQuery(sSql);
        }
        /// <summary>
        /// 最受欢迎场景
        /// </summary>
        /// <param name="keys"></param>
        /// <param name="dateString"></param>
        /// <returns></returns>
        public DataSet FavouriteScene(string keys, string dateString)
        {
            string sSql = string.Format(@"
 
 select count(SceneID) as SceneCnt,SceneName,VenueName from ( select ds.SceneID ,dv.Name as VenueName ,orderNo, ShootDate,DressEmpName,CreateTime, d.Name as SceneName ,DepartmentNo, DressEmpNO  from  D_SceneChooseHistory  ds  
left join D_Scene  d on d.ID = ds.SceneID  
left join D_Theme dt on dt.ID = d.ThemeID
left join D_Venue dv on dv.ID = dt.VenueID  where 1=1 {1}) as a where 1=1 {0} group by SceneID,SceneName,VenueName ", keys, dateString);
            return ExecuteQuery(sSql);
        }

        /// <summary>
        /// 获取电话追踪模板
        /// </summary>
        /// <returns></returns>
        public DataSet GetDressRemarkTemplete()
        {
            string sSql = @" select * from Dress_RemarkTemplete";
            return ExecuteQuery(sSql);
        }

        public bool SaveCallBack(string orderNo, string keys, string empId)
        {
            string sSql = string.Format(@" insert into Dress_TraceTable(OrderNO,Dress_TraceRemark,Dress_Operator,Dress_OperatorTime) values ('{0}','{1}','{2}',GETDATE())", orderNo, keys, empId);
            return ExecuteNonQuery(sSql) > 0;
        }
        /// <summary>
        /// 出租礼服删除
        /// </summary>
        /// <param name="batchNum"></param>
        /// <param name="dressBarCode"></param>
        /// <param name="empNo"></param>
        /// <returns></returns>
        public bool DressRentDelete(string batchNum, string dressBarCode,string empNo)
        {
            string sSql = string.Format(@" update Dress_Hire set IsDelete=1 where batchNum = '{0}' and DressBarCode = '{1}'
 insert into Dress_Log(DressBarCode,DressStatus,LogNotes,OperatePeople,OperateTime,department) values('{1}','删除礼服','删除礼服','{2}',GETDATE(),'金纱嫁衣馆') ", batchNum, dressBarCode, empNo);
            return ExecuteNonQuery(sSql) > 1;
        }

        public bool DressRentAdd(List<string> orderInfoList, string dressBarCode, string remark, int isfriend, string empId, string dressStylist)
        {
            string sSql = string.Format(@"
declare @RentOfPrice varchar(50) 
declare @SaleOfPrice varchar(50)
select @RentOfPrice =DressRentPrice,@SaleOfPrice = DressSalePrice from Dress_newInformation where DressBarCode = '{4}'
Update Dress_OperateBatch set  DressStylist = '{8}', OperateDepartment = '106',OperatePeople = '{7}',OperateTime = GETDATE() where  batchNum = '{0}'
insert into Dress_Hire(batchNum,takeDressTime,marryDtaTime,returnDressTime,DressBarCode,remarks,IsFriend,RentOfPrice,SaleOfPrice,ReventionsCount) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',@RentOfPrice,@SaleOfPrice,'1')
insert into Dress_Log(DressBarCode,DressStatus,LogNotes,OperatePeople,OperateTime,department) values('{4}','新增出租','编号：{0}','{7}',GETDATE(),'金纱嫁衣馆')  ", orderInfoList[0], orderInfoList[1], orderInfoList[2], orderInfoList[3], dressBarCode, remark, isfriend, empId, dressStylist);
            return ExecuteNonQuery(sSql) > 2;
        }
    }
}