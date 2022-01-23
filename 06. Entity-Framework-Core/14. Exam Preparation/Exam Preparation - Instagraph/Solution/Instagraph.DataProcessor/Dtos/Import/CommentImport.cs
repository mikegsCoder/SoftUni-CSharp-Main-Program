namespace Instagraph.DataProcessor.Dtos.Import
{
    [XmlType("comment")]
    public class CommentImport
    {
        [XmlElement("content")]
        [Required]
        [StringLength(250)]
        public string Content { get; set; }

        [Required]
        [XmlElement("user")]
        public string User { get; set; }

        [Required]
        [XmlElement("post")]
        public PostIdImport Post { get; set; }
    }
}
