﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using H.CLI.Interfaces;
using H.CLI.UserInput;
using H.Core.Enumerations;

namespace H.CLI.TemporaryComponentStorage
{
    public class DairyTemporaryInput : TemporaryInputBase, IComponentTemporaryInput
    {
        public void ConvertToComponentProperties(string key, ImperialUnitsOfMeasurement? units, string value, int row, int col, string filePath)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            if (String.IsNullOrEmpty(value))
            {
                Console.WriteLine(String.Format(Properties.Resources.EmptyDataInput, row + 1, col + 1, filePath));
                throw new FormatException(String.Format(Properties.Resources.EmptyDataInput, row + 1, col + 1, filePath));
            }

            if (value.ToUpper() == "N/A")
            {
                return;
            }
            var propertyInfo = this.GetType().GetProperty(key);
            InputDataReflectionHandler(propertyInfo, units, key, value, filePath, col, row);

        }

        public override void InputDataReflectionHandler(PropertyInfo propertyInfo, ImperialUnitsOfMeasurement? units, string prop, string value, string filePath, int col, int row)
        {
            base.InputDataReflectionHandler(propertyInfo, units, prop, value, filePath, col, row);

            if (propertyInfo.PropertyType == typeof(Type))
            {
                base.ParseType(propertyInfo, units, prop, value, filePath, col, row);

                return;
            }

            if (propertyInfo.PropertyType == typeof(AnimalType))
            {
                try
                {
                    if (_inputHelper.IsNotApplicableInput(value))
                    {
                        this.GroupType = AnimalType.NotSelected;
                        return;
                    }

                    this.GroupType = (AnimalType)Enum.Parse(typeof(AnimalType), value, true);
                    return;
                }

                catch
                {
                    throw new FormatException(String.Format(Properties.Resources.InvalidDataInput, value, row + 1, col + 1, filePath));
                }
            }

            if (propertyInfo.PropertyType == typeof(DietAdditiveType))
            {
                try
                {
                    if (_inputHelper.IsNotApplicableInput(value))
                    {
                        this.ManagementPeriodStartDate = DateTime.Now;
                        this.ManagementPeriodEndDate = DateTime.Now;
                        return;
                    }

                    if (_inputHelper.IsNotApplicableInput(value))
                    {
                        this.DietAdditiveType = DietAdditiveType.None;
                        return;
                    }

                    this.DietAdditiveType = (DietAdditiveType)Enum.Parse(typeof(DietAdditiveType), value, true);
                    return;
                }

                catch
                {
                    throw new FormatException(String.Format(Properties.Resources.InvalidDietAdditiveType, value, row + 1, col + 1, filePath));
                }
            }
           
            if (propertyInfo.PropertyType == typeof(DateTime))
            {
                try
                {
                    //if (_inputHelper.IsNotApplicableInput(value))
                    //{
                    //    this.ManagementPeriodStartDate = DateTime.;
                    //    return;
                    //}

                    if (prop == nameof(ManagementPeriodStartDate))
                    {
                        this.ManagementPeriodStartDate = Convert.ToDateTime(value, CLILanguageConstants.culture);
                        return;
                    }

                    else
                        this.ManagementPeriodEndDate = Convert.ToDateTime(value, CLILanguageConstants.culture);
                    return;
                }

                catch (Exception)
                {
                    Console.WriteLine(String.Format(Properties.Resources.InvalidDate, value, row + 1, col + 1, filePath));
                    throw new FormatException(String.Format(Properties.Resources.InvalidDate, value, row + 1, col + 1, filePath));
                }
            }

            else
                propertyInfo.SetValue(this, Convert.ChangeType(value, propertyInfo.PropertyType, CLILanguageConstants.culture), null);
        }

        public void FinalSettings(IComponentKeys componentKeys)
        {
        }

        public string Name { get; set; }
        public string GroupName { get; set; }
        public AnimalType GroupType { get; set; }
        public Guid Guid { get; set; }
        public int GroupId { get; set; }
        public int NumberOfAnimals { get; set; }
        public double StartWeight { get; set; }
        public double EndWeight { get; set; }
        public double AverageDailyGain { get; set; }
        public double MilkProduction { get; set; }
        public double MilkFatContent { get; set; }
        public double MilkProtein { get; set; }
        public double FeedIntake { get; set; }
        public string ManagementPeriodName { get; set; }
        public DateTime ManagementPeriodStartDate { get; set; }
        public DateTime ManagementPeriodEndDate { get; set; }
        public int ManagementPeriodDays { get; set; }
        public DietAdditiveType DietAdditiveType { get; set; }
        public double MethaneConversionFactorOfDiet { get; set; }
        public double CrudeProtein { get; set; }
        public double Forage { get; set; }
        public double TDN { get; set; }
        public double Starch { get; set; }
        public double Fat { get; set; }
        public double ME { get; set; }
        public double NDF { get; set; }
        public double VolatileSolidAdjusted { get; set; }
        public double NitrogenExcretionAdjusted { get; set; }
        public HousingType HousingType { get; set; }
        public string PastureLocation { get; set; }
        public double ActivityCoefficient { get; set; }
        public double GainCoefficient { get; set; }
        public double GainCoefficientA { get; set; }
        public double GainCoefficientB { get; set; }
        public double MaintenanceCoefficient { get; set; }
        public ManureStateType ManureManagement { get; set; }
        public double MethaneProducingCapacityOfManure { get; set; }
        public double MethaneConversionFactorOfManure { get; set; }
        public double MethaneConversionFactorAdjusted { get; set; }
        public double N2ODirectEmissionFactor { get; set; }
        public double VolatilizationFraction { get; set; }
        public double EmissionFactorLeaching { get; set; }
        public double EmissionFactorVolatilization { get; set; }
        public double FractionLeaching { get; set; }
        public double AshContent { get; set; }
    }
}

