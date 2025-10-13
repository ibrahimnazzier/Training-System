using Day1.Models;

namespace Day1.ViewModel
{
    public class TraineeResultViewModel
    {
        public string Name { get; set; }


        public string Image {  get; set; }


        public ICollection<CourseResultViewModel> Crs { get; set; }

    }
}
