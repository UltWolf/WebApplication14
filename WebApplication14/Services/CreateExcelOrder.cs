using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using OfficeOpenXml;
using WebApplication14.Models;

namespace WebApplication14.Services
{
    public class CreateExcelOrder
    {
        public static string Create(List<Order> orders, string id, IHostingEnvironment environment)
        {   
            string sWebRootFolder = environment.WebRootPath;
            string sFileName = id + ".xlsx";

            FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
            if (file.Exists)
            {
                file.Delete();
                file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
            }
            using (ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet ws = package.Workbook.Worksheets.Add("Order");
                ws.Cells["A1"].Value = "Name";
                ws.Cells["B1"].Value = "Category";
                ws.Cells["C1"].Value = "Country";
                ws.Cells["D1"].Value = "Count";
                ws.Cells["E1"].Value = "Price";
                ws.Cells["F1"].Value = "TotalCost";
                int i = 2;
                decimal totalcost = 0;
                foreach (var order in orders)
                {
                    ws.Cells["A" + i].Value = order.Product.Name;
                    ws.Cells["B" + i].Value = order.Product.Category;
                    ws.Cells["C" + i].Value = order.Product.Country;
                    ws.Cells["D" + i].Value = order.Count;
                    ws.Cells["E" + i].Value = order.Product.Price;
                    ws.Cells["F" + i].Value = order.TotalCost;
                    totalcost += order.TotalCost;
                    i++;
                }
                ws.Cells["F" + i].Value = totalcost;
                package.Save();

            }
            return (id + ".xlsx");

        }
    }
}
