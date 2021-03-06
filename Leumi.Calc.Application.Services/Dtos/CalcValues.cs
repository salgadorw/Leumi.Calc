/*
 * Leumi Calculator API Challenge
 *
 * An API that perform simple math operations
 *
 * OpenAPI spec version: 1.0.0
 * Contact: rafael.salgado@hccm.pt
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Leumi.Calc.Application.Services.Dtos
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class CalcValues : IEquatable<CalcValues>
    { 
        /// <summary>
        /// Gets or Sets ValueA
        /// </summary>
        [Required]

        [DataMember(Name="valueA")]
        public double ValueA { get; set; }

        /// <summary>
        /// Gets or Sets ValueB
        /// </summary>
        [Required]

        [DataMember(Name="valueB")]
        public double ValueB { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CalcValues {\n");
           
            sb.Append("  ValueA: ").Append(ValueA).Append("\n");
            sb.Append("  ValueB: ").Append(ValueB).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((CalcValues)obj);
        }

        /// <summary>
        /// Returns true if CalcValues instances are equal
        /// </summary>
        /// <param name="other">Instance of CalcValues to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CalcValues other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                
                (
                    ValueA == other.ValueA ||
                    ValueA != null &&
                    ValueA.Equals(other.ValueA)
                ) && 
                (
                    ValueB == other.ValueB ||
                    ValueB != null &&
                    ValueB.Equals(other.ValueB)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                    
                    if (ValueA != null)
                    hashCode = hashCode * 59 + ValueA.GetHashCode();
                    if (ValueB != null)
                    hashCode = hashCode * 59 + ValueB.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(CalcValues left, CalcValues right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CalcValues left, CalcValues right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
