using Teste_tecnico_staffing.Entities.Categories;
using Teste_tecnico_staffing.Interface;

namespace Teste_tecnico_staffing.Handlers
{
    public abstract class BaseCategoryHandler : ICategoryHandler
    {
        public BaseCategoryHandler NextCategoryHandler { get; set;}
        public abstract BaseCategory Category { get; }

        public void SetNextCategoryHandler(BaseCategoryHandler categoryHandler) 
        {
            this.NextCategoryHandler = categoryHandler;
        }
        public string EvaluateRules(ITrade trade)
        {
            if (CategoryRule(trade))
            {
                return Category.CategoryName;
            }
            else
            {
                return NextCategoryHandler != null ? NextCategoryHandler.EvaluateRules(trade) : string.Empty;
            }
        }
        public abstract bool CategoryRule(ITrade trade);
    }
}
