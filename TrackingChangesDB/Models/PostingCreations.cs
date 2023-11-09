namespace TrackingChangesDB.Models
{
    public class PostingCreations
    {
        public string request_id { get; set; } = string.Empty;
        public string posting_instruction_batch_client_id { get; set; } = string.Empty;
        public string posting_instruction_batch_client_batch_id {  get; set; } = string.Empty;
        public string posting_instruction_batch_batch_details_tx_id { get; set; } = string.Empty;
        public string posting_instruction_batch_value_timestamp { get; set; } = string.Empty;
        public string status { get; set; } = string.Empty;

    }
}
