using System;
using System.Collections.Generic;
using System.Text;

namespace Tools.MVVM.ViewModels
{
    public abstract class EntityViewModelBase<TEntity> : ViewModelBase
        where TEntity : class
    {
        protected TEntity Entity { get; private set; }

        protected EntityViewModelBase(TEntity entity)
        {
            Entity = entity ?? throw new ArgumentNullException(nameof(entity));
        }
    }
}
