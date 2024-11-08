using ModelProject.Model;
using System.Collections.Generic; 
public class ModelProvider
{
    private readonly List<DigitalModel> models = new();

    public void AddModel(DigitalModel model)
    {
        models.Add(model); 
    }
    
    
    public List<DigitalModel> GetAllModels()
    {
        return models; 
    }

  
}
