using Examine;
using Examine.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Composing;
using Umbraco.Core.Logging;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.Scoping;
using Umbraco.Examine;
using Umbraco.Web;
using Umbraco.Web.PublishedModels;

namespace owaincodes.Core.ExamineHelper
{
    public class IndexerComponent : IComponent
    {

        private readonly IExamineManager examineManager;
        private readonly IUmbracoContextFactory umbracoContextFactory;
        private readonly IProfilingLogger logService;
        private readonly IScopeProvider scopeProvider;
        
        public IndexerComponent(IExamineManager examineManager, IUmbracoContextFactory umbracoContextFactory, IProfilingLogger logService, IScopeProvider scopeProvider)
        {
            this.examineManager = examineManager ?? throw new ArgumentNullException(nameof(examineManager));
            this.umbracoContextFactory = umbracoContextFactory ?? throw new ArgumentNullException(nameof(umbracoContextFactory));
            this.logService = logService ?? throw new ArgumentNullException(nameof(logService));
            this.scopeProvider = scopeProvider ?? throw new ArgumentNullException(nameof(scopeProvider));
        }

        public void Initialize()
        {
            var externalIndex = examineManager.Indexes.FirstOrDefault(i => i.Name == Umbraco.Core.Constants.UmbracoIndexes.ExternalIndexName);
            if (externalIndex != null)
            {
                externalIndex.FieldDefinitionCollection.AddOrUpdate(new FieldDefinition(Constants.NodeName, FieldDefinitionTypes.FullTextSortable));
                externalIndex.FieldDefinitionCollection.AddOrUpdate(new FieldDefinition(Constants.DateUpdated, FieldDefinitionTypes.Long));
                externalIndex.FieldDefinitionCollection.AddOrUpdate(new FieldDefinition(Constants.Sort, FieldDefinitionTypes.Integer));
                externalIndex.FieldDefinitionCollection.AddOrUpdate(new FieldDefinition(Constants.Blogs.BlogDateSortableExamineField, FieldDefinitionTypes.Long));
                externalIndex.FieldDefinitionCollection.AddOrUpdate(new FieldDefinition(Constants.Blogs.PageTitle, FieldDefinitionTypes.FullTextSortable));
                externalIndex.FieldDefinitionCollection.AddOrUpdate(new FieldDefinition(Constants.Parent, FieldDefinitionTypes.FullTextSortable));
                externalIndex.FieldDefinitionCollection.AddOrUpdate(new FieldDefinition(Constants.CustomSort, FieldDefinitionTypes.Integer));
                externalIndex.FieldDefinitionCollection.AddOrUpdate(new FieldDefinition(Constants.CommonFields.PageTitle, FieldDefinitionTypes.FullTextSortable));
                externalIndex.FieldDefinitionCollection.AddOrUpdate(new FieldDefinition(Constants.CommonFields.CategoriesExamineField, FieldDefinitionTypes.FullTextSortable));
                externalIndex.FieldDefinitionCollection.AddOrUpdate(new FieldDefinition(Constants.FriendlyPath, FieldDefinitionTypes.FullTextSortable));
                ((BaseIndexProvider)externalIndex).TransformingIndexValues += RegisterExamineEventsComponent_TransformingIndexValues;
            }
        }

        public void Terminate()
        {
        }


        private void RegisterExamineEventsComponent_TransformingIndexValues(object sender, IndexingItemEventArgs e)
        {
            if (e.Index.Name != Umbraco.Core.Constants.UmbracoIndexes.ExternalIndexName) return;
            if (e.ValueSet.Category != IndexTypes.Content) return;

            var idString = e.ValueSet.Values["id"].FirstOrDefault()?.ToString();
            if (int.TryParse(idString, out var id))
            {
                using (var scope = scopeProvider.CreateScope(autoComplete: true))
                using (var umbracoContextReference = umbracoContextFactory.EnsureUmbracoContext())
                {
                    switch (e.ValueSet.ItemType)
                    {


                        case BlogPage.ModelTypeAlias:
                            var blogArticle = umbracoContextReference.UmbracoContext.Content.GetById(id);
                            IndexBlogSpecificProperties(e, blogArticle as BlogPage);
                            IndexCommonProperties(e, blogArticle);
                            break;
                        

                        default:
                            IPublishedContent content = umbracoContextReference.UmbracoContext.Content.GetById(id);

                            IndexCommonProperties(e, content);


                            break;
                    }

                }
            }
        }

        private void IndexBlogSpecificProperties(IndexingItemEventArgs e, BlogPage blog)
        {
            try
            {
              
                var publishedDate = blog.PublishedDate;
                e.ValueSet.Add(Constants.Blogs.BlogDateSortableExamineField, publishedDate.Ticks);
                e.ValueSet.Add(Constants.Blogs.PageTitle, blog.BlogTitle);
              
            }
            catch (Exception ex)
            {
                logService.Error(GetType(), ex, $"Error setting article Data - {blog.Id}");
            }
        }

        private void IndexCommonProperties(IndexingItemEventArgs e, IPublishedContent contentItem)
        {
            GenericIndexHelper.HandleName(e, contentItem, logService);
            GenericIndexHelper.HandleSort(e, contentItem, logService);
            GenericIndexHelper.HandleParent(e, contentItem, logService);
            GenericIndexHelper.HandleLastUpdatedDate(e, contentItem, logService);
            GenericIndexHelper.HandleKey(e, contentItem, logService);
            GenericIndexHelper.CleanPath(e, contentItem, logService);

        }
    }
   
}
