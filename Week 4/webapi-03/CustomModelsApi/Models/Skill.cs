namespace CustomModelsApi.Models
{
    /// <summary>
    /// Skill model for collection demonstration
    /// Part of complex Employee structure showing List<Skill> usage
    /// </summary>
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int ExperienceYears { get; set; }
    }
}
