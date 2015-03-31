using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExportLib
{
    public class XportExcel
    {
        Excel.Application xlApp = null;
        Excel.Workbook xlWorkBook = null;
        Excel.Worksheet xlWorkSheet = null;
        Excel.Range xlRange  = null;
        object misValue = System.Reflection.Missing.Value;
        public XportExcel() 
        { 
        }
        public void CreateReportSkeleton(string initialdate, string finaldate,List<String> empresas) 
        {
            //place of first schedule entry//header is two rows above, one column to the right
            int iniRow = 3;
            int iniCol = 3;
            int week_count = 0;
            int weeks = 3;
            List<String> header = new List<String>() 
            {
                "EMPRESA","LUNES","MARTES","MIÉRCOLES","JUEVES","VIERNES","SÁBADO","TAMBOS","   ","   "
            };
            //create Excel application
            xlApp = new Microsoft.Office.Interop.Excel.Application();
            //make sure application could be created
            if (xlApp == null) 
            {
                MessageBox.Show("EXCEL no esta instalado en esta computadora.");
                return;
            }

            //add a workbook to Excel application
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            xlWorkSheet.Cells[iniRow -2   , iniCol+1] = "REPORTE DIARIO DE DISPOSICIÓN ESCAMOCHA";
            setColumnsWidth(14);
            //add empresas to spreasheet
            int i = iniRow+1,j = iniCol;
            foreach (String empresa in empresas) 
            {
                xlWorkSheet.Cells[i, j] = empresa.ToString();
                i++;
            }

            while (week_count < weeks)
            {
                foreach (string headerelement in header)
                {
                    xlWorkSheet.Cells[iniRow, j] = headerelement.ToString();
                    j++;
                }
                week_count++;
            }

            xlRange = xlWorkSheet.get_Range("c5", "c6");
            xlRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
            //temporal save here
            SaveReport(@"C:\Reciclados\Reciclados.xls");
        }
        public void SaveReport(string path) 
        {
            xlWorkBook.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
        }
        private void setColumnsWidth(int width)
        {
            for (int i = 1; i < 100; i++) 
            {
                xlWorkSheet.Columns[i].ColumnWidth = width;
            }
        
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
