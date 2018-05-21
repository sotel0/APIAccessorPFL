using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;

namespace API_Accessor
{
    /// <summary>
    /// class to represent entire request
    /// </summary>
    public class ProductList
    {
        //empty constructor required to deserialize
        public ProductList() { }

        public Meta meta { get; set; }
        public Results results { get; set; }
    }

    /// <summary>
    /// contains meta informaion about the api request
    /// </summary>
    public class Meta
    {
        public string time { get; set; }
        public int statusCode { get; set; }
        public int duration { get; set; }
    }

    /// <summary>
    /// Results of the product request
    /// </summary>
    public class Results
    {
        public List<object> errors { get; set; }
        public List<object> messages { get; set; }
        public List<Product> data { get; set; }
    }

    /// <summary>
    /// Delivery information on the product
    /// </summary>
    public class DeliveredPrice
    {
        public string deliveryMethodCode { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public string country { get; set; }
        public string countryCode { get; set; }
        public string locationType { get; set; }
        public bool isDefault { get; set; }
        //public DateTime created { get; set; }
    }

    /// <summary>
    /// Information on time to produce the product
    /// </summary>
    public class ProductionSpeed
    {
        public int days { get; set; }
        public bool isDefault { get; set; }
    }

    /// <summary>
    /// Product information
    /// </summary>
    public class Product
    {
        public int id { get; set; }
        public string sku { get; set; }
        public int productID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string imageURL { get; set; }
        public List<object> images { get; set; }
        public int quantityDefault { get; set; }
        public int? quantityMinimum { get; set; }
        public int? quantityMaximum { get; set; }
        public int? quantityIncrement { get; set; }
        public string shippingMethodDefault { get; set; }
        public bool hasTemplate { get; set; }
        public object emailTemplateId { get; set; }
        public List<object> customValues { get; set; }
        public List<DeliveredPrice> deliveredPrices { get; set; }
        public List<ProductionSpeed> productionSpeeds { get; set; }
        public string productFormat { get; set; }
        public object productRestrictionType { get; set; }

        ///to retrieve the date time, enter desired format for parsing
        //private string lastUpdated { get; set; }
        //[IgnoreDataMember]
        //public DateTime LastUpdated
        //{
        //    get
        //    {
        //        return DateTime.ParseExact(lastUpdated, "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
        //    }
        //}
    }

}
