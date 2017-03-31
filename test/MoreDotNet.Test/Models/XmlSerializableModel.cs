namespace MoreDotNet.Test.Models
{
    using System.Xml.Serialization;

    [XmlRoot(nameof(XmlSerializableModel))]
    public class XmlSerializableModel
    {
        public XmlSerializableModel()
        {
            // Default constructor needed for deserialization.
        }

        public XmlSerializableModel(string value)
        {
            this.Value = value;
        }

        public string Value { get; set; }

        public override bool Equals(object obj)
        {
            return this.Value == (obj as XmlSerializableModel).Value;
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }
    }
}
