namespace PracaDomowa2;

public class Rental
{
    private static int _nextId = 1;
    public int Id { get; private set; }
    public int DeviceId { get; private set; }
    public int UserId { get; private set; }
    public decimal Penalty { get; private set; }
    
    public DateTime RentalDate { get; private set; }
    public DateTime DueDate { get; private set; }
    public DateTime? ReturnDate { get;  set; }

    public bool Returned => ReturnDate.HasValue;

    public Rental(int deviceId, int userId)
    {
        Id = _nextId++;
        DeviceId = deviceId;
        UserId = userId;
        RentalDate = DateTime.Now;
        DueDate = DateTime.Now.AddDays(BusinessRules.StandardRentalPeriodDays); 
        Penalty = BusinessRules.DailyPenaltyRate;
    }

    public void MarkAsReturned()
    {
        ReturnDate = DateTime.Now;
    }

    public decimal CalculatePenalty(decimal dailyRate)
    {
        DateTime compareDate = ReturnDate ?? DateTime.Now;

        if (compareDate <= DueDate)
            return 0;

        int delayDays = (compareDate - DueDate).Days;
        return delayDays * dailyRate;
    }

    public bool IsOverdue => !Returned && DateTime.Now > DueDate;
}