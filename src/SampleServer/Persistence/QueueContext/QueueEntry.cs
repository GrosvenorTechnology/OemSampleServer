using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleServer.Persistence.QueueContext
{
    public class QueueEntry
    {
        [Key]
        public Guid MessageId { get; set; } = Guid.NewGuid();

        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        [Required]
        [Index("LookUp", 0)]
        public string DeviceId { get; set; }

        [Required]
        [Index("LookUp", 1)]
        public int QueueType { get; set; }

        [Column(TypeName = "datetime2")]
        [Required]
        [Index("LookUp", 2)]
        public DateTime TimeStamp { get; set; }
        
        [Required]
        public string Body { get; set; }

        public QueueEntry()
        {
            //For loading from database
        }

        public QueueEntry(string deviceId, int queueType, string body, DateTime timestamp)
        {
            DeviceId = deviceId;
            QueueType = queueType;
            TimeStamp = timestamp;
            Body = body;
        }

    }

}
