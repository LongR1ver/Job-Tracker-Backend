namespace Job_Application_Web.Models.Enums
{
    public enum ApplicationStatus
    {
        Saved = 0,
        Applied = 1,
        Screening = 2,
        OnlineAssessment = 3,
        Interview = 4,
        FinalInterview = 5,
        Offer = 6,
        Accepted = 7, // Accept the offer
        Rejected = 8,
        Withdrawn = 9,
        Closed = 10
    }
}
