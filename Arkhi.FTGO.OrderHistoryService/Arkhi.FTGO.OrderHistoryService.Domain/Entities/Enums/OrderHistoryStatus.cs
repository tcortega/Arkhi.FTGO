using System.ComponentModel;

namespace Arkhi.FTGO.OrderHistoryService.Domain.Entities.Enums
{
    public enum OrderHistoryStatus
    {
        Preparing,
        [Description("Awaiting Pickup")] AwaitingPickup,
        Delivering,
        Completed,
        Cancelled
    }
}