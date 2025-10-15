using CashFlow.Domain.Enums;
using CashFlow.Domain.Enums.Extensions;
using CashFlow.Domain.Reports;
using CashFlow.Domain.Repository.Expenses;
using ClosedXML.Excel;

namespace CashFlow.Application.UseCases.Expenses.Reports.Excel
{
    public class GenerateExpensesReportExcelUseCase : IGenerateExpensesReportExcelUseCase
    {
        private const string CURRENCY_SYMBOL = "€";
        private readonly IExpensesReadonlyRepository _repository;

        public GenerateExpensesReportExcelUseCase(IExpensesReadonlyRepository repository)
        {
            _repository = repository;
        }

        public async Task<byte[]> Execute(DateOnly month)
        {
            var expenses = await _repository.FilterByMonth(month);
            if (expenses.Count == 0)
                return [];

            using var workBook = new XLWorkbook();

            //Informações do Arquivo
            workBook.Author = "Igor Monteiro";
            workBook.Style.Font.FontSize = 12;
            workBook.Style.Font.FontName = "Times New Roman";

            var workSheet = workBook.Worksheets.Add(month.ToString("Y"));

            InsertHeader(workSheet);

            var row = 2;
            foreach (var expense in expenses)
            {
                workSheet.Cell($"A{row}").Value = expense.Title;
                workSheet.Cell($"B{row}").Value = expense.Date;
                workSheet.Cell($"C{row}").Value = expense.PaymentType.PaymentTypeToString();
                workSheet.Cell($"C{row}").Style.NumberFormat.Format =
                    $"-{CURRENCY_SYMBOL}#, ##0.00";
                workSheet.Cell($"D{row}").Value = expense.Amount;
                workSheet.Cell($"E{row}").Value = expense.Description;

                row++;
            }

            workSheet.Columns().AdjustToContents();

            var file = new MemoryStream();

            workBook.SaveAs(file);

            return file.ToArray();
        }

        private void InsertHeader(IXLWorksheet worksheet)
        {
            worksheet.Cell("A1").Value = ResourceReportGenerationMessages.TITLE;
            worksheet.Cell("B1").Value = ResourceReportGenerationMessages.DATE;
            worksheet.Cell("C1").Value = ResourceReportGenerationMessages.PAYMENT_TYPE;
            worksheet.Cell("D1").Value = ResourceReportGenerationMessages.AMOUNT;
            worksheet.Cell("E1").Value = ResourceReportGenerationMessages.DESCRIPTION;

            // Abilitando costumização total
            worksheet.Cells("A1:E1").Style.Font.Bold = true;
            worksheet.Cells("A1:E1").Style.Fill.BackgroundColor = XLColor.FromHtml("#8CB4ED");

            worksheet.Cells("A1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            worksheet.Cells("B1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            worksheet.Cells("C1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            worksheet.Cells("E1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            worksheet.Cells("A1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
        }
    }
}
