namespace NTTData_Cafe.Helpers
{
  public static class CommonHelper
  {
    /// <summary>
    /// Generate Unique Id
    /// </summary>
    /// <returns></returns>
    public static string GenerateUniqueId()
    {
      string guid = Guid.NewGuid().ToString("N"); 
      string uniqueId = "UI" + guid.Substring(0, 7).ToUpper();
      return uniqueId;
    }

    /// <summary>
    /// Calculate Days Worked
    /// </summary>
    /// <param name="startDate"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static int CalculateDaysWorked(this DateTime startDate)
    {
      if (startDate == default(DateTime))
      {
        throw new ArgumentException("Invalid start date.");
      }

      DateTime currentDate = DateTime.Today;

      TimeSpan daysWorked = currentDate - startDate;

      return daysWorked.Days;
    }
  }
}
