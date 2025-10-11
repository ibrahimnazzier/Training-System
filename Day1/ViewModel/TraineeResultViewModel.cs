using Day1.Models;

namespace Day1.ViewModel
{
    public class TraineeResultViewModel
    {
        public string Name { get; set; }

        public string color { get; set; }

        public string Image {  get; set; }
        public ICollection<crsResult> Crs { get; set; }

    }
}
