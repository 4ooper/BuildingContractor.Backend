namespace BuildingContractor.Application.Licenses.Quieres.GetLicenseList
{
    public class LicenseListVm
    {
        public IList<LicenseLookupDto> licenses { get; set; }
        public int totalElements { get; set; }
        public int pagesCount { get; set; }
    }
}
