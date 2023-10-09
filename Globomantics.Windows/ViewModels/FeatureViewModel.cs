using Globomantics.Domain;
using Globomantics.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globomantics.Windows.ViewModels
{
    public class FeatureViewModel : BaseTodoViewModel<Feature>
    {
        public FeatureViewModel(IRepository<Feature> repository) : base()
        {
                
        }
        public override Task SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
