using Blazorise;
using Blazorise.Extensions;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

namespace Barbershop.Model.ViewModel;

public class ApplyServiceViewModel
{
    public User? AuthorizedUser { get; set; }
    public Service SelectedService { get; set; }
    public string SelectedDateString { get; set; }
    public int SelectedMasterId { get; set; }
    public int SelectedHour { get; set; }
    public List<string> AvailableServiceDates = [];
    public List<Master> AvailableMasters = [];
    public List<int> AvailableHours = [];

    public void checkDateIsValid(ValidatorEventArgs validation)
    {
        if (AvailableServiceDates.IsNullOrEmpty()) 
        {
            validation.Status = ValidationStatus.Error;
            return;
        }
        if (!(AvailableServiceDates.Any(dateString => dateString == SelectedDateString)))
        {
            validation.Status = ValidationStatus.Error;
            return;
        }
        DateTime parsedDate;
        if (!DateTime.TryParse(SelectedDateString, out parsedDate))
        {
            validation.Status = ValidationStatus.Error;
            return;
        }
        validation.Status = ValidationStatus.Success;
        return;
    }
    public void checkMasterIsValid(ValidatorEventArgs validation)
    {
        if (AvailableMasters.IsNullOrEmpty())
        {
            validation.Status = ValidationStatus.Error;
            return;
        }
        if (!(AvailableMasters.Any(master => master.Id == SelectedMasterId)))
        {
            validation.Status = ValidationStatus.Error;
            return;
        }
        validation.Status = ValidationStatus.Success;
        return;
    }
    public void checkHourIsValid(ValidatorEventArgs validation)
    {
        if (AvailableHours.IsNullOrEmpty())
        {
            validation.Status = ValidationStatus.Error;
            return;
        }
        if (!(AvailableHours.Any(hour => hour == SelectedHour)))
        {
            validation.Status = ValidationStatus.Error;
            return;
        }
        validation.Status = ValidationStatus.Success;
        return;
    }
}

/// <summary>
/// Checks if the provided string date in one of List<string>dates
/// and also that it can be converted to correct DateTime.
/// </summary>
