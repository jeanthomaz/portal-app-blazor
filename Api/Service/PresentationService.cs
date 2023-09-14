using Core.Entities;

namespace Api.Service
{
    public class PresentationService
    {
        private List<Presentation> presentations = new List<Presentation>();

        public List<Presentation> GetAllPresentations()
        {
            return presentations;
        }

        public void AddPresentation(Presentation presentation)
        {
            presentations.Add(presentation);
        }
    }
}