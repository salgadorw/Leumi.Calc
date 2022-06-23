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
    public partial class CalcValuesPath : IEquatable<CalcValuesPath>
    { 
        /// <summary>
        /// Gets or Sets ValuesId
        /// </summary>
        [Required]

        [DataMember(Name="valuesId")]
        public Guid ValuesId { get; set; }

        /// <summary>
        /// Gets or Sets PropertyName
        /// </summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum PropertyNameEnum
        {
            /// <summary>
            /// Enum ValueAEnum for valueA
            /// </summary>
            [EnumMember(Value = "valueA")]
            ValueAEnum = 0,
            /// <summary>
            /// Enum ValueBEnum for valueB
            /// </summary>
            [EnumMember(Value = "valueB")]
            ValueBEnum = 1        }

        /// <summary>
        /// Gets or Sets PropertyName
        /// </summary>
        [Required]

        [DataMember(Name="propertyName")]
        public PropertyNameEnum PropertyName { get; set; }

        /// <summary>
        /// Gets or Sets Value
        /// </summary>
        [Required]

        [DataMember(Name="value")]
        public double Value { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CalcValuesPath {\n");
            sb.Append("  ValuesId: ").Append(ValuesId).Append("\n");
            sb.Append("  PropertyName: ").Append(PropertyName).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
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
            return obj.GetType() == GetType() && Equals((CalcValuesPath)obj);
        }

        /// <summary>
        /// Returns true if CalcValuesPath instances are equal
        /// </summary>
        /// <param name="other">Instance of CalcValuesPath to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CalcValuesPath other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    ValuesId == other.ValuesId ||
                    ValuesId != null &&
                    ValuesId.Equals(other.ValuesId)
                ) && 
                (
                    PropertyName == other.PropertyName ||
                    PropertyName != null &&
                    PropertyName.Equals(other.PropertyName)
                ) && 
                (
                    Value == other.Value ||
                    Value != null &&
                    Value.Equals(other.Value)
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
                    if (ValuesId != null)
                    hashCode = hashCode * 59 + ValuesId.GetHashCode();
                    if (PropertyName != null)
                    hashCode = hashCode * 59 + PropertyName.GetHashCode();
                    if (Value != null)
                    hashCode = hashCode * 59 + Value.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(CalcValuesPath left, CalcValuesPath right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CalcValuesPath left, CalcValuesPath right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}