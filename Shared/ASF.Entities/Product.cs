//====================================================================================================
// Base code generated with LeatherGoods
// Architecture Solutions Foundation
//
// Generated by academic at LeatherGoods V 1.0 
//====================================================================================================

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;


namespace ASF.Entities
{
    /// <summary>
    /// Represents a row of entity data.
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class Product : EntityBase
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("Id")]
        [Browsable(false)]
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("Title")]
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("Description")]
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("Dealer Id")]
        public int DealerId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("Image")]
        public byte[] Image { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("Price")]
        public double Price { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("Quantity Sold")]
        public int QuantitySold { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("Avg Stars")]
        public double AvgStars { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("Rowid")]
        public Guid Rowid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("Created On")]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("Created By")]
        public int? CreatedBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("Changed On")]
        public DateTime ChangedOn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("Changed By")]
        public int? ChangedBy { get; set; }

        
    }
}
