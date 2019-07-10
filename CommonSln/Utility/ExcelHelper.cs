using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CCLUtility
{
    public class ExcelHelper
    {
        ExcelPackage package;
        ExcelWorksheet worksheet;
        public ExcelHelper()
        {

        }
        public ExcelHelper(string fillPath, string sheetName = "sheet1", bool removeExistFile = false)
        {
            Init(fillPath, sheetName = "sheet1", removeExistFile = false);
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="fillPath">保存路径</param>
        /// <param name="sheetName">表单名称</param>
        /// <param name="removeExistFile">是否需要删除已存在文件</param>
        public void Init(string fillPath, string sheetName = "sheet1",bool removeExistFile=false)
        {
            FileInfo newFile = new FileInfo(fillPath);
            //存在此文件同时需要删除存在文件
            if (newFile.Exists&& removeExistFile)
            {
                newFile.Delete();
                newFile = new FileInfo(fillPath);
            }
            package = new ExcelPackage(newFile);
            worksheet = package.Workbook.Worksheets.Add(sheetName);
        }
        /// <summary>
        /// 添加新sheet,默认情况下不需要使用此方法,仅需要多个sheet且非第一张sheet时需要使用
        /// </summary>
        /// <param name="sheetName"></param>
        /// <returns></returns>
        public ExcelWorksheet AddSheet(string sheetName)
        {
            return package.Workbook.Worksheets.Add(sheetName);
        }
        //为默认sheet设置数据
        public void SetValue(int row,int col,string value)
        {
            worksheet.Cells[row, col].Value = value;
        }
        //为指定sheet设置数据
        public void SetValueBySheet(ExcelWorksheet sheet, int row, int col, string value)
        {
            sheet.Cells[row, col].Value = value;
        }
        /// <summary>
        /// 保存
        /// </summary>
        public void Save()
        {
            try
            {
                package.Save();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                package.Dispose();
            }
        }
    }
}