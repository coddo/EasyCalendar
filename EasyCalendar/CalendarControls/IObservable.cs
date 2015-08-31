namespace EasyCalendar.CalendarControls
{
    public interface IObservable
    {
        IObserver Observer { get; set; }
    }
}
