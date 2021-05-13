using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using ToDo.Application.Common.ViewModels;
using ToDo.Domain.Common;
using ToDo.Domain.Entities;
using Xunit;

namespace ToDo.Application.Tests.Common.ViewModels.BaseEntityViewModelTests
{
    public abstract class BaseEntityViewModelConstructShould<TEntity, TViewModel> 
        where TEntity : BaseEntity
        where TViewModel : BaseEntityViewModel
    {
        [Fact]
        public void PopulateId()
        {
            TEntity entity = Builder<TEntity>.CreateNew().Build();
            TViewModel viewModel = (TViewModel)Activator.CreateInstance(typeof(TViewModel), entity);
            Assert.Equal(entity.Id, viewModel.Id);
        }

        [Fact]
        public void PopulateCreatedBy()
        {
            TEntity entity = Builder<TEntity>.CreateNew().Build();
            TViewModel viewModel = (TViewModel)Activator.CreateInstance(typeof(TViewModel), entity);
            Assert.Equal(entity.CreatedBy, viewModel.CreatedBy);
        }

        [Fact]
        public void PopulateCreatedDate()
        {
            TEntity entity = Builder<TEntity>.CreateNew().Build();
            TViewModel viewModel = (TViewModel)Activator.CreateInstance(typeof(TViewModel), entity);
            Assert.Equal(entity.CreatedDate, viewModel.CreatedDate);
        }

        [Fact]
        public void PopulateUpdateBy()
        {
            TEntity entity = Builder<TEntity>.CreateNew().Build();
            TViewModel viewModel = (TViewModel)Activator.CreateInstance(typeof(TViewModel), entity);
            Assert.Equal(entity.UpdatedBy, viewModel.UpdatedBy);
        }

        [Fact]
        public void PopulateUpdatedDate()
        {
            TEntity entity = Builder<TEntity>.CreateNew().Build();
            TViewModel viewModel = (TViewModel)Activator.CreateInstance(typeof(TViewModel), entity);
            Assert.Equal(entity.UpdatedDate, viewModel.UpdatedDate);
        }
    }
}
