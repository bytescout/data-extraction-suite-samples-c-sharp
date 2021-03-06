//*******************************************************************************************//
//                                                                                           //
// Download Free Evaluation Version From: https://bytescout.com/download/web-installer       //
//                                                                                           //
// Also available as Web API! Get Your Free API Key: https://app.pdf.co/signup               //
//                                                                                           //
// Copyright © 2017-2020 ByteScout, Inc. All rights reserved.                                //
// https://www.bytescout.com                                                                 //
// https://pdf.co                                                                            //
//                                                                                           //
//*******************************************************************************************//


using System;
using System.Diagnostics;
using System.IO;
using Bytescout.Spreadsheet;
using Bytescout.Spreadsheet.Charts;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create new Spreadsheet object
            Spreadsheet spreadsheet = new Spreadsheet();
            spreadsheet.RegistrationName = "demo";
            spreadsheet.RegistrationKey = "demo";

            // Add new worksheet
            Worksheet sheet = spreadsheet.Workbook.Worksheets.Add("Sample");

            // Add few random numbers
            int length = 10;
            Random rnd = new Random();
            for (int i = 0; i < length; i++)
            {
                sheet.Cell(i, 0).Value = rnd.Next(10);
                sheet.Cell(i, 1).Value = rnd.Next(10);
                sheet.Cell(i, 2).Value = rnd.Next(1, 3);
            }

            // add charts to worksheet
            Chart bubbleChart = sheet.Charts.AddChartAndFitInto(1, 4, 19, 11, ChartType.Bubble);
            bubbleChart.SeriesCollection.Add(new Series(sheet.Range(0, 1, length - 1, 1),
                                                        sheet.Range(0, 0, length - 1, 0),
                                                        sheet.Range(0, 2, length - 1, 2)));

            bubbleChart = sheet.Charts.AddChartAndFitInto(1, 12, 19, 19, ChartType.Bubble3DEffect);
            bubbleChart.SeriesCollection.Add(new Series(sheet.Range(0, 1, length - 1, 1),
                                                        sheet.Range(0, 0, length - 1, 0),
                                                        sheet.Range(0, 2, length - 1, 2)));
                
            // Save it as XLS
            spreadsheet.SaveAs("Output.xls");

            // Close the document
            spreadsheet.Close();

            // Cleanup
            spreadsheet.Dispose();

            // Open generated XLS file in default associated application
            Process.Start("Output.xls");
        }
    }
}
