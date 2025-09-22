using System.Security.Claims;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using MusicEShop.Service.Interface;

namespace MusicEShop.Web.Controllers
{
    public class ExportController : Controller
    {
        private readonly IOrderService _orderService;
        public ExportController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public FileContentResult ExportAllOrders()
        {
            string fileName = "Orders.xlsx";
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            using (var workbook = new XLWorkbook())
            {
                IXLWorksheet worksheet = workbook.Worksheets.Add("Orders");
                worksheet.Cell(1, 1).Value = "OrderID";
                worksheet.Cell(1, 2).Value = "Customer UserName";
                worksheet.Cell(1, 3).Value = "Total Price";
                var data = _orderService.GetAllOrders().Where(o => o.UserId == currentUserId).ToList();
                for (int i = 0; i < data.Count(); i++)
                {
                    var item = data[i];
                    worksheet.Cell(i + 2, 1).Value = item.Id.ToString();
                    worksheet.Cell(i + 2, 2).Value = User.FindFirstValue(ClaimTypes.Name);
                    var total = 0;
                    for (int j = 0; j < item.OrderItems.Count(); j++)
                    {
                        worksheet.Cell(1, 4 + j).Value = "Product - " + (j + 1);
                        var orderItem = item.OrderItems.ElementAt(j);
                        worksheet.Cell(i + 2, 4 + j).Value = orderItem.Album != null ? orderItem.Album.Title : orderItem.Track.Title;
                        total += (int)(orderItem.Quantity * (orderItem.Album != null ? orderItem.Album.Price : orderItem.Track.Price));

                    }

                    worksheet.Cell(i + 2, 3).Value = total;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, contentType, fileName);
                }
            }
        }
    }
}
