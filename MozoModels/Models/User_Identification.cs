using System;
namespace MozoModels.Models
{
    public class User_Identification:BaseEntity_Service
    {
        public string user_id { get; set; }
        public string add_doc_type { get; set; }
        public string add_doc_no { get; set; }
        public string add_doc { get; set; }
        public string id_doc_type { get; set; }
        public string id_doc_no { get; set; }
        public string id_doc { get; set; }
        public string pan_card_no { get; set; }
        public string pan_card { get; set; }
        public string dl_no { get; set; }
        public string dl { get; set; }
    }
}
