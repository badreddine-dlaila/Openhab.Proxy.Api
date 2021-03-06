/* 
 * openHAB REST API
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: 2.5
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Openhab.Client.Model
{
    /// <summary>
    /// ThingTypeDTO
    /// </summary>
    [DataContract]
    public partial class ThingTypeDTO :  IEquatable<ThingTypeDTO>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ThingTypeDTO" /> class.
        /// </summary>
        /// <param name="uID">uID.</param>
        /// <param name="label">label.</param>
        /// <param name="description">description.</param>
        /// <param name="category">category.</param>
        /// <param name="listed">listed (default to false).</param>
        /// <param name="supportedBridgeTypeUIDs">supportedBridgeTypeUIDs.</param>
        /// <param name="bridge">bridge (default to false).</param>
        /// <param name="channels">channels.</param>
        /// <param name="channelGroups">channelGroups.</param>
        /// <param name="configParameters">configParameters.</param>
        /// <param name="parameterGroups">parameterGroups.</param>
        /// <param name="properties">properties.</param>
        /// <param name="extensibleChannelTypeIds">extensibleChannelTypeIds.</param>
        public ThingTypeDTO(string uID = default(string), string label = default(string), string description = default(string), string category = default(string), bool? listed = false, List<string> supportedBridgeTypeUIDs = default(List<string>), bool? bridge = false, List<ChannelDefinitionDTO> channels = default(List<ChannelDefinitionDTO>), List<ChannelGroupDefinitionDTO> channelGroups = default(List<ChannelGroupDefinitionDTO>), List<ConfigDescriptionParameterDTO> configParameters = default(List<ConfigDescriptionParameterDTO>), List<ConfigDescriptionParameterGroupDTO> parameterGroups = default(List<ConfigDescriptionParameterGroupDTO>), Dictionary<string, string> properties = default(Dictionary<string, string>), List<string> extensibleChannelTypeIds = default(List<string>))
        {
            UID = uID;
            Label = label;
            Description = description;
            Category = category;
            // use default value if no "listed" provided
            if (listed == null)
            {
                Listed = false;
            }
            else
            {
                Listed = listed;
            }
            SupportedBridgeTypeUIDs = supportedBridgeTypeUIDs;
            // use default value if no "bridge" provided
            if (bridge == null)
            {
                Bridge = false;
            }
            else
            {
                Bridge = bridge;
            }
            Channels = channels;
            ChannelGroups = channelGroups;
            ConfigParameters = configParameters;
            ParameterGroups = parameterGroups;
            Properties = properties;
            ExtensibleChannelTypeIds = extensibleChannelTypeIds;
        }
        
        /// <summary>
        /// Gets or Sets UID
        /// </summary>
        [DataMember(Name="UID", EmitDefaultValue=false)]
        public string UID { get; set; }

        /// <summary>
        /// Gets or Sets Label
        /// </summary>
        [DataMember(Name="label", EmitDefaultValue=false)]
        public string Label { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets Category
        /// </summary>
        [DataMember(Name="category", EmitDefaultValue=false)]
        public string Category { get; set; }

        /// <summary>
        /// Gets or Sets Listed
        /// </summary>
        [DataMember(Name="listed", EmitDefaultValue=false)]
        public bool? Listed { get; set; }

        /// <summary>
        /// Gets or Sets SupportedBridgeTypeUIDs
        /// </summary>
        [DataMember(Name="supportedBridgeTypeUIDs", EmitDefaultValue=false)]
        public List<string> SupportedBridgeTypeUIDs { get; set; }

        /// <summary>
        /// Gets or Sets Bridge
        /// </summary>
        [DataMember(Name="bridge", EmitDefaultValue=false)]
        public bool? Bridge { get; set; }

        /// <summary>
        /// Gets or Sets Channels
        /// </summary>
        [DataMember(Name="channels", EmitDefaultValue=false)]
        public List<ChannelDefinitionDTO> Channels { get; set; }

        /// <summary>
        /// Gets or Sets ChannelGroups
        /// </summary>
        [DataMember(Name="channelGroups", EmitDefaultValue=false)]
        public List<ChannelGroupDefinitionDTO> ChannelGroups { get; set; }

        /// <summary>
        /// Gets or Sets ConfigParameters
        /// </summary>
        [DataMember(Name="configParameters", EmitDefaultValue=false)]
        public List<ConfigDescriptionParameterDTO> ConfigParameters { get; set; }

        /// <summary>
        /// Gets or Sets ParameterGroups
        /// </summary>
        [DataMember(Name="parameterGroups", EmitDefaultValue=false)]
        public List<ConfigDescriptionParameterGroupDTO> ParameterGroups { get; set; }

        /// <summary>
        /// Gets or Sets Properties
        /// </summary>
        [DataMember(Name="properties", EmitDefaultValue=false)]
        public Dictionary<string, string> Properties { get; set; }

        /// <summary>
        /// Gets or Sets ExtensibleChannelTypeIds
        /// </summary>
        [DataMember(Name="extensibleChannelTypeIds", EmitDefaultValue=false)]
        public List<string> ExtensibleChannelTypeIds { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ThingTypeDTO {\n");
            sb.Append("  UID: ").Append(UID).Append("\n");
            sb.Append("  Label: ").Append(Label).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Category: ").Append(Category).Append("\n");
            sb.Append("  Listed: ").Append(Listed).Append("\n");
            sb.Append("  SupportedBridgeTypeUIDs: ").Append(SupportedBridgeTypeUIDs).Append("\n");
            sb.Append("  Bridge: ").Append(Bridge).Append("\n");
            sb.Append("  Channels: ").Append(Channels).Append("\n");
            sb.Append("  ChannelGroups: ").Append(ChannelGroups).Append("\n");
            sb.Append("  ConfigParameters: ").Append(ConfigParameters).Append("\n");
            sb.Append("  ParameterGroups: ").Append(ParameterGroups).Append("\n");
            sb.Append("  Properties: ").Append(Properties).Append("\n");
            sb.Append("  ExtensibleChannelTypeIds: ").Append(ExtensibleChannelTypeIds).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return Equals(input as ThingTypeDTO);
        }

        /// <summary>
        /// Returns true if ThingTypeDTO instances are equal
        /// </summary>
        /// <param name="input">Instance of ThingTypeDTO to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ThingTypeDTO input)
        {
            if (input == null)
                return false;

            return 
                (
                    UID == input.UID ||
                    (UID != null &&
                    UID.Equals(input.UID))
                ) && 
                (
                    Label == input.Label ||
                    (Label != null &&
                    Label.Equals(input.Label))
                ) && 
                (
                    Description == input.Description ||
                    (Description != null &&
                    Description.Equals(input.Description))
                ) && 
                (
                    Category == input.Category ||
                    (Category != null &&
                    Category.Equals(input.Category))
                ) && 
                (
                    Listed == input.Listed ||
                    (Listed != null &&
                    Listed.Equals(input.Listed))
                ) && 
                (
                    SupportedBridgeTypeUIDs == input.SupportedBridgeTypeUIDs ||
                    SupportedBridgeTypeUIDs != null &&
                    SupportedBridgeTypeUIDs.SequenceEqual(input.SupportedBridgeTypeUIDs)
                ) && 
                (
                    Bridge == input.Bridge ||
                    (Bridge != null &&
                    Bridge.Equals(input.Bridge))
                ) && 
                (
                    Channels == input.Channels ||
                    Channels != null &&
                    Channels.SequenceEqual(input.Channels)
                ) && 
                (
                    ChannelGroups == input.ChannelGroups ||
                    ChannelGroups != null &&
                    ChannelGroups.SequenceEqual(input.ChannelGroups)
                ) && 
                (
                    ConfigParameters == input.ConfigParameters ||
                    ConfigParameters != null &&
                    ConfigParameters.SequenceEqual(input.ConfigParameters)
                ) && 
                (
                    ParameterGroups == input.ParameterGroups ||
                    ParameterGroups != null &&
                    ParameterGroups.SequenceEqual(input.ParameterGroups)
                ) && 
                (
                    Properties == input.Properties ||
                    Properties != null &&
                    Properties.SequenceEqual(input.Properties)
                ) && 
                (
                    ExtensibleChannelTypeIds == input.ExtensibleChannelTypeIds ||
                    ExtensibleChannelTypeIds != null &&
                    ExtensibleChannelTypeIds.SequenceEqual(input.ExtensibleChannelTypeIds)
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
                int hashCode = 41;
                if (UID != null)
                    hashCode = hashCode * 59 + UID.GetHashCode();
                if (Label != null)
                    hashCode = hashCode * 59 + Label.GetHashCode();
                if (Description != null)
                    hashCode = hashCode * 59 + Description.GetHashCode();
                if (Category != null)
                    hashCode = hashCode * 59 + Category.GetHashCode();
                if (Listed != null)
                    hashCode = hashCode * 59 + Listed.GetHashCode();
                if (SupportedBridgeTypeUIDs != null)
                    hashCode = hashCode * 59 + SupportedBridgeTypeUIDs.GetHashCode();
                if (Bridge != null)
                    hashCode = hashCode * 59 + Bridge.GetHashCode();
                if (Channels != null)
                    hashCode = hashCode * 59 + Channels.GetHashCode();
                if (ChannelGroups != null)
                    hashCode = hashCode * 59 + ChannelGroups.GetHashCode();
                if (ConfigParameters != null)
                    hashCode = hashCode * 59 + ConfigParameters.GetHashCode();
                if (ParameterGroups != null)
                    hashCode = hashCode * 59 + ParameterGroups.GetHashCode();
                if (Properties != null)
                    hashCode = hashCode * 59 + Properties.GetHashCode();
                if (ExtensibleChannelTypeIds != null)
                    hashCode = hashCode * 59 + ExtensibleChannelTypeIds.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
