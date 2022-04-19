using System;
namespace APICore.DataModelService
{
    public class ResponseModel
    {
        public string AddedCourseId { get; set; }
        public string RemovedCourseId { get; set; }
        public bool NewlyAdded { get; set; }
        public bool AlreadyAdded { get; set; }
        public bool IsDoneAdded { get; set; }
        public bool IsDoneRemoved { get; set; }
        public int ItemCounter { get; set; }
        public string Message { get; set; }
    }
}
