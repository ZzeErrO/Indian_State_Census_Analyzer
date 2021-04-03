using System;
using IndianStateCensusAnalyzer;
using System.Collections.Generic;
using NUnit.Framework;
using IndianStateCensusAnalyzer.DTO;
using static IndianStateCensusAnalyzer.CensusAnalyser;

namespace CensusAnalyserTest
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class UnitTest1
    {
        public class Tests
        {
            //CensusAnalyser.CensusAnalyser censusAnalyser;

            static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
            static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
            static string indianStateCensusFilePath = @"C:\Users\Prashik Jaware\source\repos\DesignPrinciples\Indian-State-Census-Analyzer\CensusAnalyserTest\CsvFiles\IndiaStateCensusData.csv";
            static string wrongHeaderIndianCensusFilePath = @"C:\Users\Prashik Jaware\source\repos\DesignPrinciples\Indian-State-Census-Analyzer\CensusAnalyserTest\CsvFiles\WrongIndiaStateCensusData.csv";
            static string delimiterIndianCensusFilePath = @"C:\Users\Prashik Jaware\source\repos\DesignPrinciples\Indian-State-Census-Analyzer\CensusAnalyserTest\CsvFiles\DelimiterIndiaStateCensusData.csv";
            static string wrongIndianStateCensusFilePath = @"C:\Users\Prashik Jaware\source\repos\DesignPrinciples\Indian-State-Census-Analyzer\CensusAnalyserTest\CsvFiles\WrongIndiaStateCensusData1.csv";
            static string wrongIndianStateCensusFileType = @"C:\Users\Prashik Jaware\source\repos\DesignPrinciples\Indian-State-Census-Analyzer\CensusAnalyserTest\CsvFiles\IndiaStateCensusData.txt";
            static string indianStateCodeFilePath = @"C:\Users\Prashik Jaware\source\repos\DesignPrinciples\Indian-State-Census-Analyzer\CensusAnalyserTest\CsvFiles\IndiaStateCode.csv";
            static string wrongIndianStateCodeFileType = @"C:\Users\Prashik Jaware\source\repos\DesignPrinciples\Indian-State-Census-Analyzer\CensusAnalyserTest\CsvFiles\IndiaStateCode.txt";
            static string delimiterIndianStateCodeFilePath = @"C:\Users\Prashik Jaware\source\repos\DesignPrinciples\Indian-State-Census-Analyzer\CensusAnalyserTest\CsvFiles\DelimiterIndiaStateCode.csv";
            static string wrongHeaderStateCodeFilePath = @"C:\Users\Prashik Jaware\source\repos\DesignPrinciples\Indian-State-Census-Analyzer\CensusAnalyserTest\CsvFiles\WrongIndiaStateCode1.csv";
            //US Census FilePath
            static string usCensusHeaders = "State Id,State,Population,Housing units,Total area,Water area,Land area,Population Density,Housing Density";
            static string usCensusFilepath = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\USCsvFiles\USCensusData.csv";
            static string wrongUSCensusFilePath = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\USCsvFiles\USData.csv";
            static string wrongUSCensusFileType = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\USCsvFiles\USCensusData.txt";
            static string wrongHeaderUSCensusFilePath = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\USCsvFiles\WrongHeaderUSCensusData.csv";
            static string delimeterUSCensusFilePath = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\USCsvFiles\DelimiterUSCensusData.csv";

            CensusAnalyser censusAnalyser;
            Dictionary<string, CensusDTO> totalRecord;
            Dictionary<string, CensusDTO> stateRecord;

            [SetUp]
            public void Setup()
            {
                censusAnalyser = new CensusAnalyser();
                totalRecord = new Dictionary<string, CensusDTO>();
                stateRecord = new Dictionary<string, CensusDTO>();
            }

            [Test]
            public void Test1()
            {
                Assert.Pass();
            }

            [Test]
            public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
            {
                totalRecord = censusAnalyser.LoadCensusData(indianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders);
                Assert.AreEqual(29, totalRecord.Count);
            }

            [Test]
            public void GivenWrongIndianCensusDataFile_WhenReaded_ShouldReturnCustomException()
            {
                var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders));
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
            }

            [Test]
            public void GivenWrongIndianCensusDataFileType_WhenReaded_ShouldReturnCustomException()
            {
                var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFileType, Country.INDIA, indianStateCensusHeaders));
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
            }
        }

    }
}