﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H.Core.Enumerations;

namespace H.Core.Models.Infrastructure
{
    public enum SubstrateType
    {
        StoredManure,
        FreshManure,
        FarmResidues
    }

    public class SubstrateFlowInformation
    {
        public AnimalType AnimalType { get; set; }
        public FarmResidueType FarmResidueType { get; set; }
        public SubstrateType SubstrateType { get; set; }

        /// <summary>
        /// (kg day^-1)
        /// </summary>
        public double TotalMassFlow { get; set; }

        /// <summary>
        /// (kg day^-1)
        /// </summary>
        public double VolatileSolidsFlow { get; set; }

        /// <summary>
        /// (kg day^-1)
        /// </summary>
        public double TotalSolidsFlow { get; set; }

        /// <summary>
        /// (kg day^-1)
        /// </summary>
        public double NitrogenFlow { get; set; }

        /// <summary>
        /// (kg day^-1)
        /// </summary>
        public double CarbonFlow { get; set; }
        public double OrganicNitrogenFlow { get; set; }
        public double TotalAmmonicalNitrogenFlow { get; set; }

        /// <summary>
        /// (kg day^-1)
        /// </summary>
        public double BiodegradableSolidsFlow { get; set; }

        /// <summary>
        /// (Nm^3 day^-1)
        /// </summary>
        public double MethaneProduction { get; set; }

        /// <summary>
        /// (kg VS day^-1)
        /// </summary>
        public double DegradedVolatileSolids { get; set; }

        /// <summary>
        /// (Nm^3 day^-1)
        /// </summary>
        public double BiogasProduction { get; set; }

        /// <summary>
        /// (Nm^3 day^-1)
        /// </summary>
        public double CarbonDioxideProduction { get; set; }
        public double TanFlowInDigestate { get; set; }
        public double OrganicNitrogenFlowInDigestate { get; set; }
        public double CarbonFlowInDigestate { get; set; }
    }
}
